using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace Grid
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class HexRenderer : MonoBehaviour
    {
        public static Vector2 CubeToAxial(Vector3 cube)
        {
            return new(cube.x, cube.y);
        }

        public static Vector2Int CubeToAxial(Vector3Int cube)
        {
            return new(cube.x, cube.y);
        }

        public static Vector3 AxialToCube(Vector2 axial)
        {
            return new Vector3(axial.x, axial.y, -axial.x - axial.y);
        }

        public static Vector3Int AxialToCube(Vector2Int axial)
        {
            return new(axial.x, axial.y, -axial.x - axial.y);
        }

        public static Vector2Int AxialToOffset(int q, int r)
        {
            var row = r + (q + (q & 1)) / 2;
            return new Vector2Int(q, row);
        }

        public static Vector2Int AxialToOffset(Vector2Int axial)
        {
            return AxialToOffset(axial.x, axial.y);
        }

        public static Vector2Int OffsetToAxial(Vector2Int offset)
        {
            return OffsetToAxial(offset.x, offset.y);
        }

        public static Vector2Int OffsetToAxial(int x, int y)
        {
            var r = y - (x + (x & 1)) / 2;
            return new Vector2Int(x, r);
        }

        public static Vector3Int CubeRound(Vector3 cube)
        {
            var q = Mathf.Round(cube.x);
            var r = Mathf.Round(cube.y);
            var s = Mathf.Round(cube.z);

            var qDiff = Mathf.Abs(q - cube.x);
            var rDiff = Mathf.Abs(r - cube.y);
            var sDiff = Mathf.Abs(s - cube.z);

            // who has the largest diff? Figure it out and normalize that one
            if (qDiff > rDiff && qDiff > sDiff)
            {
                q = -r - s;
            }
            else if (rDiff > sDiff)
            {
                r = -q - s;
            }
            else
            {
                s = -q - r;
            }

            return new Vector3Int((int)q, (int)r, (int)s);
        }

        public static Vector2Int AxialRound(Vector2 axial)
        {
            return CubeToAxial(CubeRound(AxialToCube(axial)));
        }

        private Mesh mesh;
        private MeshFilter meshFilter;
        private MeshRenderer meshRenderer;
        [SerializeField]
        private Material material;

        private List<HexTile> faces;

        [SerializeField, Header("Hex Sizes")]
        public float innerSize;

        [SerializeField]
        public float outerSize;

        [SerializeField]
        public float hexHeight;

        [SerializeField]
        public Vector2Int axialCoord;

        [SerializeField]
        public Vector3Int cubeCoord;

        [SerializeField]
        public Vector2Int offsetCoord;

        private void Awake()
        {
            meshFilter = GetComponent<MeshFilter>();
            meshRenderer = GetComponent<MeshRenderer>();

            mesh = new Mesh
            {
                name = "HexGrid"
            };
            meshFilter.mesh = mesh;
            meshRenderer.material = material;
        }

        private void OnEnable()
        {
            DrawMesh();
        }

        // private void OnValidate()
        // {
        //     if (Application.isPlaying)
        //     {
        //         DrawMesh();
        //     }
        // }

        public void SetMaterial(Material mat)
        {
            meshRenderer.material = mat;
            material = mat;
        }

        public void SetCoords(Vector2Int offset)
        {
            offsetCoord = offset;
            axialCoord = OffsetToAxial(offset);
            cubeCoord = new Vector3Int(axialCoord.x, axialCoord.y, -axialCoord.x - axialCoord.y);
        }

        public void DrawMesh()
        {
            DrawTiles();
            CombineTiles();
        }

        private void DrawTiles()
        {
            // https://www.redblobgames.com/grids/hexagons/
            faces = new List<HexTile>();
            // top faces
            for (var point = 0; point < 6; point++)
            {
                faces.Add(CreateTile(innerSize, outerSize, hexHeight / 2f, hexHeight / 2f, point));
            }
            // bottom faces
            for (var point = 0; point < 6; point++)
            {
                faces.Add(CreateTile(innerSize, outerSize, -hexHeight / 2f, -hexHeight / 2f, point, true));
            }
            // outer faces
            for (var point = 0; point < 6; point++)
            {
                faces.Add(CreateTile(outerSize, outerSize, hexHeight / 2f, -hexHeight / 2f, point, true));
            }
            // inner faces
            for (var point = 0; point < 6; point++)
            {
                faces.Add(CreateTile(innerSize, innerSize, hexHeight / 2f, -hexHeight / 2f, point));
            }
        }

        private HexTile CreateTile(
            float innerRadians,
            float outerRadians,
            float heightA,
            float heightB,
            int point,
            bool isReversed = false)
        {
            var connectingPoint = point < 5 ? point + 1 : 0;
            var pointA = GetPoint(innerRadians, heightB, point);
            var pointB = GetPoint(innerRadians, heightB, connectingPoint);
            var pointC = GetPoint(outerRadians, heightA, connectingPoint);
            var pointD = GetPoint(outerRadians, heightA, point);

            var verts = new[] { pointA, pointB, pointC, pointD };
            if (isReversed)
            {
                verts = verts.Reverse().ToArray();
            }
            var tris = new[] { 0, 1, 2, 2, 3, 0 };
            var uvs = new Vector2[] { new(0, 0), new(1, 0), new(1, 1), new(0, 1) };
            return new HexTile(verts, tris, uvs);
        }

        private Vector3 GetPoint(float size, float height, int index)
        {
            // our hex needs to add up to 360 degrees
            // there are 6 sides in a hex so...
            float angleDeg = 60 * index;
            float angleRadians = Mathf.Deg2Rad * angleDeg;
            return new Vector3(size * Mathf.Cos(angleRadians), height, size * MathF.Sin(angleRadians));
        }

        private void CombineTiles()
        {
            var verts = new List<Vector3>();
            var tris = new List<int>();
            var uvs = new List<Vector2>();

            for (var i = 0; i < faces.Count; i++)
            {
                verts.AddRange(faces[i].Vertices);
                uvs.AddRange(faces[i].Uvs);

                // we want 4 triangles per hex
                var offset = 4 * i;
                foreach (var triangle in faces[i].Triangles)
                {
                    tris.Add(triangle + offset);
                }
            }

            mesh.vertices = verts.ToArray();
            mesh.triangles = tris.ToArray();
            mesh.uv = uvs.ToArray();
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
        }

    }
}
