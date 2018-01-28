using UnityEngine;
using RotaryHeart.Lib.UnityGLDebug;
using System.Collections.Generic;

namespace SpaceCon
{

    [RequireComponent(typeof(LineRenderer))]
    public class SatNode : MonoBehaviour
    {
        LineRenderer lineRenderer;

        public float radius = 1.5f;
        [SerializeField]
        SatNode Parent;
        [SerializeField]
        SatNode Child;
        void AddChild(SatNode node)
        {
            if(Child != null)
            {
                node.Child = Child;
            }
            Child = node;
            Child.Parent = this;
        }

        private void Update()
        {
            lineRenderer.SetPosition(0, (Parent == null) ? transform.position : Parent.transform.position);
            lineRenderer.SetPosition(1, transform.position);
            lineRenderer.SetPosition(2, Vector3.zero); //HACK
            
        }

        private void Start()
        {
            lineRenderer = this.RequireComponent<LineRenderer>();
            lineRenderer.enabled = true;
        }

        public void Connect()
        {
            Debug.Log("0");
            var collisions = Physics2D.OverlapCircleAll(transform.position, radius, LayerMask.GetMask("Satellite"));
            if(collisions != null)
            {

            }
            if (collisions != null && collisions.Length > 0)
            {
                Debug.Log("1");
                var nearest = collisions[0].GetComponent<SatNode>();
                if (nearest == null)
                {
                    Debug.Log("2");
                    return;
                }
                //Check 1st
                var prevNearestChild = nearest.Child;
                {
                    if (nearest.Parent == null)
                    {
                        Debug.Log("2_1");
                        AddChild(nearest);
                        return;
                    }
                    if (nearest.Child == null)
                    {
                        Debug.Log("2_2");
                        nearest.AddChild(this);
                    }
                    Debug.Log("3");
                }
                if (collisions.Length < 2) return;
                
                var nearest2 = collisions[1].GetComponent<SatNode>();
                if (nearest2 == null)
                {
                    Debug.Log("4");
                    return;
                }
                //Check 2st
                {
                    AddChild(nearest2);
                    if (nearest.Child != this && prevNearestChild == nearest2)
                    {
                        Debug.Log("5");
                        nearest.AddChild(this);
                        return;
                    }
                }
            }
            Debug.Log("NOTHING");
            //Now it's in the network
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
