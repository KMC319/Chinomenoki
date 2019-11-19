using UnityEngine;

namespace Main {
    public class TakableObject : MonoBehaviour , ITakable {
        private Rigidbody rigid;
        private bool isTook;

        private void Awake() {
            rigid = GetComponent<Rigidbody>();
            rigid.useGravity = false;
        }

        private void Update() {
            if(!isTook) return;
            transform.LookAt(transform.parent);
        }

        public void Take(Transform parent) {
            transform.SetParent(parent);
            rigid.useGravity = false;
            isTook = true;
        }

        public void Release() {
            rigid.useGravity = true;
            transform.SetParent(null);
            isTook = false;
            rigid.velocity = -Vector3.forward * 10f;
        }
    }
}
