using UnityEngine;

namespace Main {
    public class PlayerMove : MonoBehaviour {
        private Rigidbody rigid;
        private Camera camera;

        private void Start() {
            rigid = GetComponent<Rigidbody>();
            camera = GetComponent<Camera>();
        }

        private void Update() {
            Move();
        }

        private void Move() {
            var yRotation = Mathf.Deg2Rad * (int) camera.transform.eulerAngles.y;
            var speed = 8f;
            var x = Input.GetAxis("Horizontal") * Mathf.Cos(yRotation) + Input.GetAxis("Vertical") * Mathf.Sin(yRotation);
            var z = Input.GetAxis("Vertical") * Mathf.Cos(yRotation) - Input.GetAxis("Horizontal") * Mathf.Sin(yRotation);

            if (Mathf.Abs(x) > 0 || Mathf.Abs(z) > 0) {
                rigid.velocity = new Vector3(x * speed, rigid.velocity.y, z * speed);
            } else {
                rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
            }
        }
    }
}
