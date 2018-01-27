using UnityEngine;
using System.Collections.Generic;

namespace SpaceCon
{
    [RequireComponent(typeof(LineRenderer))]
    public class SatNet : MonoBehaviour
    {
        public List<Satellite> nodes = new List<Satellite>();
        private void Start()
        {

        }
    }
}