//using UnityEngine;
//using System.Collections.Generic;

//namespace SpaceCon
//{
//    public static class LineDrawer
//    {
//        public static List<Vector3> points = new List<Vector3>();
//        public static Color color;
//    }


//    public class GLDrawer : MonoBehaviour
//    {
//        void OnPostRender()
//        {
//            for (int i = 0; i+1 < LineDrawer.points.Count; i+=2)
//            {
//                RenderLines(LineDrawer.color, LineDrawer.points[i], LineDrawer.points[i+1]);
//            }
//            LineDrawer.points.Clear();
//        }
       
//        static Material lineMaterial;
//        static void CreateLineMaterial()
//        {
//            if (!lineMaterial)
//            {
//                // Unity has a built-in shader that is useful for drawing
//                // simple colored things.
//                Shader shader = Shader.Find("Hidden/Internal-Colored");
//                lineMaterial = new Material(shader)
//                { hideFlags = HideFlags.HideAndDontSave };
//                // Turn on alpha blending
//                lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
//                lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
//                // Turn backface culling off
//                lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
//                // Turn off depth writes
//                lineMaterial.SetInt("_ZWrite", 0);
//            }
//        }
//        private void RenderLines(Color color, Vector3 start, params Vector3[] points)
//        {
//            CreateLineMaterial();

//            GL.PushMatrix();
//            lineMaterial.SetPass(0);
//            GL.Begin(GL.LINES);

//            GL.Color(color);
//            GL.Vertex(start);
//            for (int i = 0; i < points.Length; i++)
//            {
//                GL.Color(color);
//                GL.Vertex(points[i]);
//            }
//            GL.End();
//            GL.PopMatrix();
//        }
//    }
//}