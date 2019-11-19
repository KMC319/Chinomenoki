using UnityEngine;

namespace Main {
    public class CameraMove : MonoBehaviour {
        private CursorLockMode cursorMode;
        private Vector2 mouse;
        private float defaultSpeed = 4f;
        private Camera camera;


        private void Start() {
            cursorMode = CursorLockMode.Locked;
            SetCursorState();
            camera = GetComponent<Camera>();
        }


        private void Update() {
            Move();
        }

        private void SetCursorState() {
            Cursor.lockState = cursorMode;
            Cursor.visible = (CursorLockMode.Locked != cursorMode);
        }

        private void Move() {
            mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            if (mouse != Vector2.zero) {
                var angX = transform.localEulerAngles.x - mouse.y * defaultSpeed;
                if (mouse.y < 0 && angX > 70 && angX < 270) mouse.y = 0;
                if (mouse.y > 0 && angX < 290 && angX > 90) mouse.y = 0;
                camera.transform.eulerAngles = new Vector3(camera.transform.localEulerAngles.x - mouse.y * defaultSpeed, camera.transform.eulerAngles.y + mouse.x * defaultSpeed, camera.transform.eulerAngles.z);
            }
        }
    }
}
