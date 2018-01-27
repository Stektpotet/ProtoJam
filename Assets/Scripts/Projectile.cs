using UnityEngine;
using System.Collections;

namespace SpaceCon
{
    public class Projectile : MonoBehaviour
    {
        public Vector2 Velocity { get; set; }
        public void FixedUpdate()
        {
            transform.position += (Vector3)(Velocity);
            transform.position += (Vector3)GravityMap.GetGravityAtPosition(transform.position);
        }

        //"Collision" to register as within a gravitational body's gravity field.
        
        
    }
}
