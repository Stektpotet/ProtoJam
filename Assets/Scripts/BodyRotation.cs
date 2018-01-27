using UnityEngine;
using System.Collections;

namespace SpaceCon
{
    public class BodyRotation : MonoBehaviour
    {
        [Range(0.1f, 10f)]
        public float spin;
        private void Update()
        {
            transform.Rotate(Vector3.forward, spin * Time.deltaTime);
        }

    }

}