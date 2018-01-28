using UnityEngine;
using System.Collections;
namespace SpaceCon
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class SatHub : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var contender = collision.GetComponent<SatNode>();
            if( contender != null)
            {
                contender.SetInRange(true);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            var contender = collision.GetComponent<SatNode>();
            if (contender != null)
            {
                contender.SetInRange(false);
            }
        }
    }
}