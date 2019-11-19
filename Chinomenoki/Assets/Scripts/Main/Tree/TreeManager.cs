using UnityEngine;

namespace Main.Tree {
    [RequireComponent(typeof(Collider))]
    public class TreeManager : MonoBehaviour {
        private void OnCollisionEnter(Collision other) {
            if (other.gameObject.TryGetComponent(out LectureObj temp)) {
                Destroy(temp.gameObject);
            }
        }
    }
}
