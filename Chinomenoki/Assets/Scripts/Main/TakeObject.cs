using UnityEngine;

namespace Main {
    public class TakeObject : MonoBehaviour {
        private Camera camera;
        private ITakable currentTakeObject;

        private void Start() {
            camera = GetComponent<Camera>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
                Debug.DrawRay(ray.origin, ray.direction * 60f, Color.red, 3.0f); //可視化
                RaycastHit hit;
                ITakable takable;
                if (Physics.Raycast(ray, out hit, 100) && hit.transform.TryGetComponent(out takable)) {
                    takable.Take(transform);
                    currentTakeObject = takable;
                }
            }

            if (currentTakeObject != null && Input.GetKeyUp(KeyCode.Mouse0)) {
                currentTakeObject.Release();
                currentTakeObject = null;
            }
        }
    }
}
