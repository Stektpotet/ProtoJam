using UnityEngine;
using System.Collections;

namespace SpaceCon
{
    public class ProjectileLauncher : MonoBehaviour
    {
        public float launcherOffset;

        public Projectile LaunchProjectile(GameObject prefab, float initialForce, Player p)
        {
            GameObject projectileObject = Instantiate(prefab);
            projectileObject.transform.position = transform.position + transform.up * launcherOffset;
            projectileObject.transform.rotation = transform.rotation;
            Projectile projectile = projectileObject.transform.RequireComponent<Projectile>( p =>
            {
                p.body = p.GetComponent<Rigidbody2D>();
                p.body.AddForce(initialForce * transform.up);
            });
            return projectile;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Vector3 v = transform.position + transform.up * launcherOffset;
            Gizmos.DrawLine(v, v + transform.up*0.25f);
        }
    }
}
