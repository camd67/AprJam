using System;
using Cinemachine;
using UnityEngine;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        // Modified by smoothdamp. Don't touch!
        private float zoomVector;

        [SerializeField]
        private float zoomSpeed;

        [SerializeField]
        private float zoomTime;

        [SerializeField]
        private Vector2 minMaxZoom;

        [SerializeField]
        private CinemachineVirtualCamera cam;

        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private float rotateSpeed;

        private CameraControls cameraControls;

        private float targetZoom;

        private void Awake()
        {
            cameraControls = new CameraControls();
            targetZoom = cam.m_Lens.FieldOfView;
        }

        private void OnEnable()
        {
            cameraControls.CameraMovement.Enable();
        }

        private void OnDisable()
        {
            cameraControls?.Disable();
        }

        private void Update()
        {
            var moveVector = cameraControls.CameraMovement.Move.ReadValue<Vector3>();
            transform.Translate(moveSpeed * Time.deltaTime * moveVector);

            var rotateVector = cameraControls.CameraMovement.Rotate.ReadValue<float>();
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime * rotateVector, 0), Space.Self);

            targetZoom += cameraControls.CameraMovement.Zoom.ReadValue<float>() * Time.deltaTime * zoomSpeed;


            // cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, cam.m_Lens.FieldOfView + zoomVector, lerpProgress);
            targetZoom = Mathf.Clamp(targetZoom, minMaxZoom.x, minMaxZoom.y);
            cam.m_Lens.FieldOfView = Mathf.SmoothDamp(cam.m_Lens.FieldOfView, targetZoom, ref zoomVector, zoomTime);
        }

    }
}
