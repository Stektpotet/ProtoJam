using UnityEngine;
using System.Collections.Generic;

namespace SpaceCon
{
    //SatNet - Holder of Satellite nodes, used for managing data revolving around points per transmissions etc.
    //[RequireComponent(typeof(LineRenderer))]
    public class SatNet : MonoBehaviour
    {

        public List<SatNode> nodes = new List<SatNode>();
        public void EnterOrbit(SatNode node)
        {
            nodes.Add(node);
            node.Connect();
        }

        private void FixedUpdate()
        {
            UpdateConnections();
        }

        public void UpdateConnections()
        {
            
        }

        public void Disconnect(Satellite satellite)
        {
            UpdateConnections();
        }
    }
}