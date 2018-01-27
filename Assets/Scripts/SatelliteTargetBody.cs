using UnityEngine;
using System.Collections.Generic;

namespace SpaceCon
{

    [RequireComponent(typeof(CircleCollider2D), typeof(GravityBody))]
    public class SatelliteTargetBody : MonoBehaviour
    {
        float targetScale = 1f; //How large is the acceptable target deviation for satellites to be able to enter 
        List<Satellite> satellites = new List<Satellite>();
        
        //Components on self
        GravityBody gravityBody;
        CircleCollider2D trigger;

        float satelliteOrbitalVelocity;

        private void Reset()
        {
            trigger = this.RequireComponent<CircleCollider2D>(c =>
            {
                c.isTrigger = true;
                c.radius = targetScale;
            });
        }

        private void Start()
        {
            trigger = this.RequireComponent<CircleCollider2D>(c =>
            {
                c.isTrigger = true;
                c.radius = targetScale;
            });

            gravityBody = this.RequireComponent<GravityBody>(gb =>
            {
                satelliteOrbitalVelocity = gb.OrbitalVelocityAtHeight(targetScale);
            });
        }

        //Take control of physics again!
        private void Enter(Projectile projectile)
        {
            Satellite satellite = projectile.RequireComponent<Satellite>(s =>
            {
                s.speed = gravityBody.OrbitalVelocityAtHeight((transform.position - s.transform.position).magnitude);
            });
            Destroy(projectile); //projectile is no longer wanted as we don't do "physics anymore"

            satellites.Add(satellite);
        }

        private void Exit(Satellite satellite)
        {
            satellites.Remove(satellite);
        }



        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Collider object register as attracted...
            if(collision.gameObject.layer == 1 << 8)
            {
                Enter(collision.GetComponent<Projectile>());
            }

        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, targetScale);
        }
    }
}