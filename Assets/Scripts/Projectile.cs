using UnityEngine;
using System.Collections;

namespace SpaceCon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        public GameObject rocket, satellite;
        //Components on self
        public Rigidbody2D body;
        public Vector2 Velocity { get { return body.velocity; } set { body.velocity = value; } }

        private void Start()
        {
            body = this.RequireComponent<Rigidbody2D>();
        }
        public void FixedUpdate()
        {
            body.AddForce(GravityMap.GetGravityAtPosition(transform.position));
        }
        public void Update()
        {
            Debug.DrawLine(transform.position, transform.position + (Vector3)(Velocity + GravityMap.GetGravityAtPosition(transform.position)), Color.red);
        }
    }
}
