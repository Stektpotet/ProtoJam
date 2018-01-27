using UnityEngine;
using RotaryHeart.Lib.UnityGLDebug;
using System.Collections.Generic;

namespace SpaceCon
{

    public class SatNode : MonoBehaviour
    {
        SatNode[] ConnectedNodes { get { return connections.ToArray(); } }

        List<SatNode> connections = new List<SatNode>();
        public void Connect(SatNode node)
        {
            Debug.Log("Connecting!");
            connections.Add(node);
            node.connections.Add(this);
        }
        public void Disconnect(SatNode node)
        {
            connections.Remove(node);
            node.connections.Remove(this);
        } 
        public bool IsConnectedTo(SatNode node)
        {
            return connections.Contains(node);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            foreach (SatNode n in connections)
            {
                Gizmos.DrawLine(transform.position, n.transform.position);
            }
        }
    }
}
