using UnityEngine;
using System.Collections.Generic;

namespace SpaceCon
{

    [RequireComponent(typeof(CircleCollider2D), typeof(GravityBody))]
    public class SatelliteTargetBody : MonoBehaviour
    {
        public float targetScale = 1f; //How large is the acceptable target deviation for satellites to be able to enter 
        List<Satellite> satellites = new List<Satellite>();


        //Components on self
        SatNet network;
        GravityBody gravityBody;
        CircleCollider2D trigger;

        float satelliteOrbitalVelocity;

        private void Reset()
        {
            trigger = this.RequireComponent<CircleCollider2D>(c =>
            {
                c.isTrigger = true;
                c.radius = targetScale * 0.5f;
            });
            network = this.RequireComponent<SatNet>();
        }

        private void Start()
        {
            trigger = this.RequireComponent<CircleCollider2D>(c =>
            {
                c.isTrigger = true;
                c.radius = targetScale * 0.5f;
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
                s.body = this;
                s.speed = gravityBody.OrbitalVelocityAtHeight((transform.position - s.transform.position).magnitude);
            });
#if UNITY_2017
            projectile.body.simulated = false;
#endif
            projectile.body.isKinematic = true;
            Destroy(projectile); //projectile is no longer wanted as we don't do "physics anymore"
            
            satellites.Add(satellite);

        }

        private void Exit(Satellite satellite)
        {
            satellites.Remove(satellite);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(LayerMask.NameToLayer("Satellite"));
            //Collider object register as attracted...
            if(collision.gameObject.layer == LayerMask.NameToLayer("Satellite"))
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