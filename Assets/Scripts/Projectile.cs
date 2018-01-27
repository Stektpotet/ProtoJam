using UnityEngine;
using System.Collections;

namespace SpaceCon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {

        //Instantiate explosion with earth
        public GameObject explosion;

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
        //"Collision" to register as within a gravitational body's gravity field.


        public void OnCollisionEnter2D(Collision2D col)    //Fuckings explode!!! 
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Earth"))
            {
                Debug.Log("Explosion"); 
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
