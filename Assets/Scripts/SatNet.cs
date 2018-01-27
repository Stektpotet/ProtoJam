using UnityEngine;
using System.Collections.Generic;

namespace SpaceCon
{
    [RequireComponent(typeof(LineRenderer))]
    public class SatNet : MonoBehaviour
    {

        List<Satellite> nodes = new List<Satellite>();
        private void Start()
        {
            
        }

        public void Connect(Satellite node)
        {
            nodes.Add(node);
            
        }
        public void Disconnect(Satellite node)
        {
            nodes.Remove(node);
        }
    }
}