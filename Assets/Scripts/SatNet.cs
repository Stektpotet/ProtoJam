using UnityEngine;
using System.Collections.Generic;

namespace SpaceCon
{
    //SatNet - Holder of Satellite nodes, used for managing data revolving around points per transmissions etc.
    [RequireComponent(typeof(LineRenderer))]
    public class SatNet : MonoBehaviour
    {
        const float MAX_SAT_DIST = 10f;

        List<SatNode> nodes = new List<SatNode>();

        public void Connect(Satellite satellite)
        {
            nodes.Add(satellite.Node);
        }

        private void FixedUpdate()
        {
            UpdateConnections();
        }

        public void UpdateConnections()
        {
            foreach (SatNode n in nodes)
            {
                foreach (SatNode other in nodes)
                {
                    //Validate other is not self
                    if (n == other || n.IsConnectedTo(other)) continue; //no point in connecting to yourself
                    //Evaluate distance, if out of range, don't connect
                    if ((n.transform.position - other.transform.position).magnitude > MAX_SAT_DIST) { continue; }
                    //Evaluate line of sight 
                    RaycastHit2D intersectHit = Physics2D.Linecast(n.transform.position, other.transform.position, 1 << LayerMask.NameToLayer("GravityBody"));
                    if (intersectHit.fraction != 0) { continue; }
                    n.Connect(other);
                }
            }
        }

        public void Disconnect(Satellite satellite)
        {
            nodes.Remove(satellite.Node);
            UpdateConnections();
        }
    }
}