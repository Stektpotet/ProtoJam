using UnityEngine;
using System.Collections;

namespace SpaceCon
{
    [RequireComponent(typeof(SatNode))]
    public class Satellite : MonoBehaviour
    {
        //Satellites of different type have different range?
        public SatNode Node { get { if (_node == null) _node = GetComponent<SatNode>(); return _node; } }
        private SatNode _node;

        public SatelliteTargetBody body; //the body the satellite is orbiting
        public float speed; // orbital speed around body
        private void Update()
        {
            transform.RotateAround(body.transform.position, Vector3.forward, speed * Time.deltaTime);
        }
    }
}