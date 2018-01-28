﻿using UnityEngine;
using System.Collections.Generic;

namespace SpaceCon
{
    //The Handler of capturing satellites
    [RequireComponent(typeof(CircleCollider2D), typeof(GravityBody))]
    public class SatelliteTargetBody : MonoBehaviour
    {
        public float TargetScale { get { return trigger.radius * 2; } } //How large is the acceptable target deviation for satellites to be able to enter

        //Components on self
        SatNet network;
        GravityBody gravityBody;
        public CircleCollider2D trigger;

        float satelliteOrbitalVelocity;


        private void Reset()
        {
            network = this.RequireComponent<SatNet>();
        }

        private void Start()
        {
            gravityBody = this.RequireComponent<GravityBody>(gb =>
            {
                satelliteOrbitalVelocity = gb.OrbitalVelocityAtHeight(TargetScale);
            });

            network = this.RequireComponent<SatNet>();
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
            //projectile.body.simulated = true;
#endif
            projectile.body.isKinematic = true;
            projectile.body.velocity = Vector2.zero;
            projectile.rocket.SetActive(false);
            projectile.satellite.SetActive(true);
            Destroy(projectile); //projectile is no longer wanted as we don't do "physics anymore"

            network.EnterOrbit(satellite.Node);
            satellite.gameObject.layer = LayerMask.NameToLayer("Satellite");
        }

        //private void Exit(Satellite satellite)
        //{
        //    network.Disconnect(satellite);
        //}

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Collider object register as attracted...
            if(collision.gameObject.layer == LayerMask.NameToLayer("Projectile"))
            {
                Enter(collision.GetComponent<Projectile>());
            }
        }

        private void OnDrawGizmos()
        {
            if (trigger != null)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireSphere(transform.position, TargetScale);
            }
        }
    }
}
