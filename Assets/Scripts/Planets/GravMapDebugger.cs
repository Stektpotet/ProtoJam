#if UNITY_EDITOR
using UnityEngine;
using System.Collections;

public class GravMapDebugger : MonoBehaviour
{
    float x_d = 0.25f;
    public int x=10;
    float y_d = 0.25f;
    public int y = 10;
    private void OnDrawGizmosSelected()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            for (int y_p = -y; y_p <= y * 2; y_p++)
            {
                for (int x_p = -x; x_p <= x * 2; x_p++)
                {
                    var pos = new Vector3(x_p * x_d, y_p * y_d);
                    var grav = (Vector3)SpaceCon.GravityMap.GetGravityAtPosition(pos);
                    Gizmos.color = Color.Lerp(Color.green, Color.red, grav.magnitude * 3);
                    Gizmos.DrawLine(pos, pos + grav);
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
#endif