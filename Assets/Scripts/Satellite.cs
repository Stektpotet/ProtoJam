using UnityEngine;
using System.Collections;

namespace SpaceCon
{

    public class Satellite : MonoBehaviour
    {

        GravityBody body;
        public float speed;
        private void Update()
        {
            transform.RotateAround(body.transform.position, Vector3.forward, speed * Time.deltaTime);
        }
        
    }

}