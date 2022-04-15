using UnityEngine;

namespace Grid
{
    public struct HexTile
    {
        public Vector3[] Vertices { get; private set; }
        public int[] Triangles { get; private set; }
        public Vector2[] Uvs { get; private set; }

        public HexTile(Vector3[] vertices, int[] triangles, Vector2[] uvs)
        {
            Vertices = vertices;
            Triangles = triangles;
            Uvs = uvs;
        }
    }
}
