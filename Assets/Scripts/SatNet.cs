using UnityEngine;
using System.Collections.Generic;

namespace SpaceCon
{
    [RequireComponent(typeof(LineRenderer))]
    public class SatNet : MonoBehaviour
    {

        List<Satellite> nodes = new List<Satellite>();

        public void Connect(Satellite node)
        {
            foreach (var n in nodes)
            {

            }
            nodes.Add(node);
        }
        public void Disconnect(Satellite node)
        {
            nodes.Remove(node);
        }
    }
}