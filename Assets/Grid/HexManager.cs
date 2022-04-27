using Control;
using UnityEngine;

namespace Grid
{
    public class HexManager : MonoBehaviour
    {
        [SerializeField]
        private GameState state = GameState.PlayerMove;

        [SerializeField, Header("Grid Settings")]
        private HexGridLayout gridLayout;

        [SerializeField]
        private Vector2 mousePos;

        private Controls controls;

        private UnityEngine.Camera cam;

        private Plane tilePlane = new(Vector3.left, Vector3.right, Vector3.forward);

        [SerializeField, Header("Player")]
        private GameObject playerPrefab;

        private GameObject player;

        [SerializeField]
        private Vector2Int playerTilePos;

        [SerializeField]
        private float playerSpeed;

        [SerializeField]
        private float playerTurnSpeed;

        [SerializeField]
        private float maxPlayerSpeed;

        private Vector3 playerVelocity;

        private void Awake()
        {
            cam = UnityEngine.Camera.main;
            controls ??= new Controls();
            // hack to make sure we're facing up...
            if (tilePlane.normal == Vector3.down)
            {
                tilePlane.Flip();
            }
            ResetBoard();
        }

        private void ResetBoard()
        {
            if (player != null)
            {
                Destroy(player.gameObject);
            }

            player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, transform);
            playerTilePos = Vector2Int.zero;
            player.transform.position = gridLayout.OffsetToWorld(playerTilePos);
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
            if (state == GameState.PlayerMove)
            {
                DoPlayerMove();
            }
            else
            {
                DoEnemyMove();
            }
        }

        private void DoEnemyMove()
        {

        }

        private void DoPlayerMove()
        {
            // Highlight tile
            var mouseRay = cam.ScreenPointToRay(mousePos);
            if (tilePlane.Raycast(mouseRay, out var distance))
            {
                var mouseWorld = mouseRay.GetPoint(distance);
                var highlightedCoord = gridLayout.WorldToOffset(mouseWorld);
                gridLayout.HighlightTile(highlightedCoord);
            }

            // Move
            if (controls.GameInteractions.Select.WasPerformedThisFrame() && gridLayout.highlightedTile != null)
            {
                playerTilePos = gridLayout.highlightedTile.offsetCoord;
            }
            var targetWorldPos = gridLayout.OffsetToWorld(playerTilePos);
            var position = player.transform.position;
            player.transform.position = Vector3.SmoothDamp(position, targetWorldPos, ref playerVelocity, playerSpeed, maxPlayerSpeed);
            var lookAt = Quaternion.LookRotation(targetWorldPos - position);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookAt, Time.deltaTime * playerTurnSpeed);
        }
    }
}
