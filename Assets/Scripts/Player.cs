using UnityEngine;
using System.Collections;

namespace SpaceCon
{
    [RequireComponent(typeof(ProjectileLauncher))]
    public class Player : MonoBehaviour
    {
        //Components on self
        ProjectileLauncher launcher;

        public KeyCode launchKey;
        //Input mappings?

        public float chargeMultiplier;

        private bool charging;
        private float charge;
        private void Start()
        {
            launcher = this.RequireComponent<ProjectileLauncher>();
        }

        private void Update()
        {
            if(Input.GetKey(launchKey)) //while player holds launchkey, charge the launch power.
            {
                charge += chargeMultiplier * Time.deltaTime;
            }
            else if (Input.GetKeyUp(launchKey))
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                go.transform.localScale = new Vector3(0.1f, 0.1f);
                launcher.LaunchProjectile(go, charge);
                charge = 0;
            }
        }
    }
}
