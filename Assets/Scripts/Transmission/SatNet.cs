using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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
            UpdateConnections();
        }
        
        void UpdateConnections()
        {
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                if (nodes[i] != null)
                {
                    nodes[i].Disconnect();
                    nodes[i].Connect(transform.position);
                }
                else
                {
                    nodes.RemoveAt(i);
                }
            }
        }
        public void ExitOrbit(SatNode node)
        {
            nodes.Remove(node);
        }
    }
}