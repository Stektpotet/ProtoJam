using UnityEngine;
using System.Collections.Generic;

namespace SpaceCon
{

    [RequireComponent(typeof(LineRenderer))]
    public class SatNode : MonoBehaviour
    {
        Vector2 planetPosition;

        LineRenderer lineRenderer;
        private bool _inRange = true;

        public float radius = 2f;
        [SerializeField]
        SatNode Parent;
        [SerializeField]
        SatNode Child;

        void SetParent(SatNode node)
        {
           // if (Child == node) return; //My child cannot be my parent

            Parent = node; //Finally set node as my parent
            Child = Parent.Child;
            if(Child != null) Child.Parent = this;
            Parent.Child = this;
        }

        private void Update()
        {
            lineRenderer.SetPosition(0, (Parent == null) ? transform.position : Parent.transform.position);
            lineRenderer.SetPosition(1, transform.position);
            if (!_inRange)
            {
                lineRenderer.SetPosition(2, transform.position);
            }
        }

        private void Start()
        {
            
            lineRenderer = this.RequireComponent<LineRenderer>();
            lineRenderer.enabled = true;

            lineRenderer.SetPosition(2, Vector3.up); //HACK
        }

        public void SetInRange(bool inRange)
        {
            _inRange = inRange;
            if(inRange)
            {
                lineRenderer.SetPosition(2, Vector3.up);
            }
        }

        private void OnDestroy()
        {
            Disconnect();
        }

        public Vector3 GetOrbitDirection()
        {
            return Vector3.Cross(((Vector3)planetPosition - transform.position), Vector3.forward).normalized;
        }

        private bool IsInFrontOfMe(Vector3 position)
        {
            var p = Vector3.Dot(GetOrbitDirection(), (position - transform.position).normalized);
            return p < 0.5f;
        }

        public void Connect(Vector2 planetPos)
        {
            planetPosition = planetPos;

            gameObject.layer = 2;
            var collisions = Physics2D.OverlapCircleAll(transform.position, radius, LayerMask.GetMask("Satellite"));
            gameObject.layer = LayerMask.NameToLayer("Satellite");
            if(collisions == null)
            {
                return;
                //wat?
            }
            if (collisions != null && collisions.Length > 0)
            {
                float nearest = float.MaxValue;
                Collider2D nearest_transform = null;
                int count = 0;
                foreach (var col in collisions)
                {
                    var cont = (transform.position - col.transform.position).magnitude;
                    if (cont < nearest)
                    {
                        if (IsInFrontOfMe(col.transform.position))
                        {
                            nearest = cont;
                            nearest_transform = col;
                        };

                    }
                    if (++count > 4) break;
                }
                if (nearest_transform == null) return;

                var nearest_collider = nearest_transform.GetComponent<SatNode>();
                if (nearest_collider != null)
                {
                    SetParent(nearest_collider);
                }
            }
            //Now it's in the network
        }
        


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, radius);
            Gizmos.DrawLine(transform.position, transform.position + GetOrbitDirection() * 4f);
        }
        public void Disconnect()
        {
            if (Parent != null) { Parent.Child = null; }
            if (Child != null) { Child.Parent = null; }
            //Parent = null;
            //Child = null;
        }
    }
}
