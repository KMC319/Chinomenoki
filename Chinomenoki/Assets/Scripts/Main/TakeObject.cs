using System.Linq;
using UnityEngine;

namespace Main {
    public class TakeObject : MonoBehaviour {
        private Camera camera;
        private ITakable[] currentTakeObjects;

        private void Start() {
            camera = GetComponent<Camera>();
            currentTakeObjects = new ITakable[0];
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
                Debug.DrawRay(ray.origin, ray.direction * 60f, Color.red, 3.0f); //可視化
                if (Physics.Raycast(ray, out var hit, 100) ) {
                    var takables = hit.transform.GetComponents<ITakable>();
                    foreach (var takable in takables) {
                        takable.Take(transform);
                    }
                    currentTakeObjects = takables;
                }
            }

            if (currentTakeObjects.Any() && Input.GetKeyUp(KeyCode.Mouse0)) {
                foreach (var takable in currentTakeObjects) {
                    takable.Release();
                }

                currentTakeObjects = new ITakable[0];
            }
        }
    }
}
