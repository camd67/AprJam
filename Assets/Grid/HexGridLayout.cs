using System;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class HexGridLayout : MonoBehaviour
    {
        [SerializeField, Header("Grid settings")]
        private Vector2Int gridSize;

        [SerializeField, Header("Hex Config")]
        private float innerSize;

        [SerializeField]
        private float outerSize;

        [SerializeField]
        private float hexHeight;

        [SerializeField]
        private Material material;

        [SerializeField]
        private Material highlightMat;

        [SerializeField]
        private Material rangeMat;

        /// <summary>
        /// Tile lookup, stored in axial coords
        /// </summary>
        private Dictionary<Vector2Int, HexRenderer> tileLookup;

        /// <summary>
        /// The currently highlighted tile. Usually null and gets changed a lot
        /// </summary>
        public HexRenderer highlightedTile;

        public readonly HashSet<HexRenderer> rangeTiles = new();

        void OnEnable()
        {
            LayoutGrid();
        }

        private void LayoutGrid()
        {
            var gridHolder = new GameObject("Grid Holder");
            gridHolder.transform.SetParent(transform);
            tileLookup = new Dictionary<Vector2Int, HexRenderer>();
            for (var y = 0; y < gridSize.y; y++)
            {
                for (var x = 0; x < gridSize.x; x++)
                {
                    var tile = new GameObject($"Hex {x},{y}", typeof(HexRenderer))
                    {
                        transform =
                        {
                            position = OffsetToWorld(new Vector2Int(x, y))
                        }
                    };

                    var hexRenderer = tile.GetComponent<HexRenderer>();
                    var offsetPos = new Vector2Int(x, y);
                    tileLookup[offsetPos] = hexRenderer;
                    hexRenderer.SetCoords(offsetPos);
                    hexRenderer.outerSize = outerSize;
                    hexRenderer.innerSize = innerSize;
                    hexRenderer.hexHeight = hexHeight;
                    hexRenderer.SetMaterial(material);
                    hexRenderer.DrawMesh();

                    tile.transform.SetParent(gridHolder.transform, true);
                }
            }
        }

        public Vector3 OffsetToWorld(Vector2Int pos)
        {
            var x = outerSize * 3f / 2f * pos.x;
            var y = outerSize * Mathf.Sqrt(3f) * (pos.y - 0.5f * (pos.x & 1));
            return new Vector3(x, 0, y);
        }

        public Vector2Int WorldToOffset(Vector3 point)
        {
            var q = 2f / 3f * point.x / outerSize;
            var r = (-1f / 3f * point.x + Mathf.Sqrt(3) / 3 * point.z) / outerSize;
            return HexRenderer.AxialToOffset(HexRenderer.AxialRound(new Vector2(q, r)));
        }

        public void HighlightTile(Vector2Int highlightedCoord)
        {
            if (highlightedCoord.x < 0 || highlightedCoord.x > gridSize.x || highlightedCoord.y < 0 || highlightedCoord.y > gridSize.y)
            {
                if (highlightedTile != null)
                {
                    if (rangeTiles.Contains(highlightedTile))
                    {
                        highlightedTile.SetMaterial(rangeMat);
                    }
                    else
                    {
                        highlightedTile.SetMaterial(material);
                    }
                    highlightedTile = null;
                }
            }

            if (tileLookup.TryGetValue(highlightedCoord, out var tile))
            {
                if (highlightedTile != tile)
                {
                    // reset old tile no matter what
                    if (highlightedTile != null)
                    {
                        if (rangeTiles.Contains(highlightedTile))
                        {
                            highlightedTile.SetMaterial(rangeMat);
                        }
                        else
                        {
                            highlightedTile.SetMaterial(material);
                        }
                    }
                    // set new tile and remember it
                    tile.SetMaterial(highlightMat);
                    highlightedTile = tile;
                }
            }
        }

        public void HighlightTilesInRange(Vector2Int center, int distance)
        {
            // clear out old tiles
            foreach (var tile in rangeTiles)
            {
                tile.SetMaterial(material);
            }
            rangeTiles.Clear();

            // highlight new tiles
            var axialCenter = HexRenderer.OffsetToAxial(center);
            var q = axialCenter.x;
            var r = axialCenter.y;
            // Run our loop as if we were at (0,0) and then add our q,r offsets right before conversion to offset
            for (var i = -distance; i <= distance; i++)
            {
                var bottomBound = Math.Max(-distance, -i - distance);
                var upperBound = Math.Min(distance, -i + distance);
                for (var j = bottomBound; j <= upperBound; j++)
                {
                    var offset = HexRenderer.AxialToOffset(q + i, r + j);
                    if (tileLookup.TryGetValue(offset, out var tile))
                    {
                        rangeTiles.Add(tile);
                        tile.SetMaterial(rangeMat);
                    }
                }
            }
        }
    }
}
