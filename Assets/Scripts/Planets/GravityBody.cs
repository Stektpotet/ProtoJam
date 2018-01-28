using UnityEngine;
using System.Collections;
namespace SpaceCon
{
    public class GravityBody : MonoBehaviour
    {
        public const float G = .25f;

        [SerializeField]
        private float mass = 10;

        public float sphereOfInfluenceRadius = 1;

        private void Start()
        {
            GravityMap.bodies.Add(this); //inject myself into gravitymap
        }

        public Vector2 GeeForce(Vector2 position, float m = 1) //mass might as well be constant, for now...
        {
            Vector2 relation = (position - (Vector2)transform.position);
            return ((G * m * mass) / -relation.sqrMagnitude) * relation.normalized;
        }

        public float OrbitalVelocityAtHeight(float height)
        {
            return Mathf.Sqrt( 100f / height);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, sphereOfInfluenceRadius);
        }
    }
}
