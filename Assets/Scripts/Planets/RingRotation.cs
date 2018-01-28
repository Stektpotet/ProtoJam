using UnityEngine;
using System.Collections;

namespace SpaceCon
{
    public class RingRotation : MonoBehaviour
    {
        [Range(0.1f, 20f)]
        public float spin;
        private void Update()
        {
            transform.Rotate(Vector3.down, spin * Time.deltaTime);
        }

    }

}