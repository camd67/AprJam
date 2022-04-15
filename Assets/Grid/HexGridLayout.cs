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

        void OnEnable()
        {
            LayoutGrid();
        }

        private void LayoutGrid()
        {
            for (var y = 0; y < gridSize.y; y++)
            {
                for (var x = 0; x < gridSize.x; x++)
                {
                    var tile = new GameObject($"Hex {x},{y}", typeof(HexRenderer));
                    tile.transform.position = GetPositionForHexFromCoordinate(new Vector2Int(x, y));

                    var hexRenderer = tile.GetComponent<HexRenderer>();
                    hexRenderer.outerSize = outerSize;
                    hexRenderer.innerSize = innerSize;
                    hexRenderer.hexHeight = hexHeight;
                    hexRenderer.SetMaterial(material);
                    hexRenderer.DrawMesh();

                    tile.transform.SetParent(transform, true);
                }
            }
        }

        public Vector3 GetPositionForHexFromCoordinate(Vector2Int pos)
        {
            var shouldOffset = pos.x % 2 == 0;
            var height = Mathf.Sqrt(3) * outerSize;
            var width = 2f * outerSize;
            var horizontalDistance = width * (3f / 4f);
            var verticalDistance = height;
            var offset = shouldOffset ? height / 2 : 0;
            var xPosition = pos.x * horizontalDistance;
            var yPosition = pos.y * verticalDistance + offset;
            return new Vector3(xPosition, 0, -yPosition);
        }
    }
}
