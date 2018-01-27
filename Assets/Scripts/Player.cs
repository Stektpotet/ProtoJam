using UnityEngine;
using System.Collections;

namespace SpaceCon
{
    [RequireComponent(typeof(ProjectileLauncher))]
    public class Player : MonoBehaviour
    {

        public GameObject prefab; //multiple later on...

        //Components on self
        ProjectileLauncher launcher;

        public KeyCode launchKey;
        //Input mappings?

        public float chargeMultiplier;

        private bool charging;
        private float charge;
        public float maxCharge; //static?
        private void Start()
        {
            launcher = this.RequireComponent<ProjectileLauncher>();
        }

        private void Update()
        {
            if(Input.GetKeyDown(launchKey))
            {
                charge = 0.1f;
            }
            else if(Input.GetKey(launchKey)) //while player holds launchkey, charge the launch power.
            {
                charge += chargeMultiplier * Time.deltaTime;
            }
            else if (Input.GetKeyUp(launchKey))
            {
                launcher.LaunchProjectile(prefab, charge);
                charge = 0;
            }
        }
    }
}
