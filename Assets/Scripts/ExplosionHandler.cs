using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    public LayerMask collisionMask;
    //SOUND

    //Instantiate explosion with earth
    public GameObject explosion;

    public void OnCollisionEnter2D(Collision2D col)    //Fuckings explode!!! 
    {
        if (((1 << col.gameObject.layer) & collisionMask.value) == 1 << col.gameObject.layer)
        {
            Debug.Log("Explosion");
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 3);
            Destroy(gameObject);
        }
    }
}
