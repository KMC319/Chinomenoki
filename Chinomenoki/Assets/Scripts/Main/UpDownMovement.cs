using UnityEngine;

namespace Main {
    public class UpDownMovement : MonoBehaviour, ITakable {
        private float count;
        private bool isUp;
        private bool isTook;
        private Vector3 pos;

        private void Start() {
            count = Random.Range(-60f, 60f);
            pos = transform.position;
        }

        private void Update() {
            if (isTook) return;
            var offset = Mathf.Cos(count);
            transform.position = pos + Vector3.up * offset * 0.1f;
            count+= Time.deltaTime * 3f;
        }

        public void Take(Transform parent) {
            isTook = true;
        }

        public void Release() {
        }
    }
}
