using UnityEngine;
using System.Collections.Generic;

namespace SpaceCon
{
    public static class GravityMap
    {
        public static List<GravityBody> bodies = new List<GravityBody>();
        public static Vector2 GetGravityAtPosition(Vector2 position)
        {
            Vector2 totalGee = Vector2.zero;
            foreach (GravityBody gb in bodies)
            {
                totalGee += gb.GeeForce(position);
            }
            return totalGee;
        }
    }
}
