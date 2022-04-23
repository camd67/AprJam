using Control;
using UnityEngine;

namespace Grid
{
    public class HexManager : MonoBehaviour
    {
        [SerializeField]
        private HexGridLayout gridLayout;

        [SerializeField]
        private Vector2 mousePos;

        private Controls controls;

        private UnityEngine.Camera cam;

        private Plane tilePlane = new(Vector3.left, Vector3.right, Vector3.forward);

        private void Awake()
        {
            cam = UnityEngine.Camera.main;
            controls ??= new Controls();
            // hack to make sure we're facing up...
            if (tilePlane.normal == Vector3.down)
            {
                tilePlane.Flip();
            }
        }

        private void OnEnable()
        {
            controls.GameInteractions.Enable();
        }

        private void OnDisable()
        {
            controls.GameInteractions.Disable();
        }

        void Update()
        {
            mousePos = controls.GameInteractions.Pointer.ReadValue<Vector2>();
            var mouseRay = cam.ScreenPointToRay(mousePos);
            if (tilePlane.Raycast(mouseRay, out var distance))
            {
                var mouseWorld = mouseRay.GetPoint(distance);
                var highlightedCoord = gridLayout.WorldToOffset(mouseWorld);
                gridLayout.HighlightTile(highlightedCoord);

            }
        }
    }
}
