using UnityEngine;
using System.Collections;

public class ParticleSystem : MonoBehaviour
{
    private int delay = 3;

    private void Start()
    {
        Destroy(gameObject, delay);
    }

}