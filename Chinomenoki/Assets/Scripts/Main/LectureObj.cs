using UnityEngine;

namespace Main {
    public class LectureObj : MonoBehaviour, ITakable {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private Rigidbody rigid;
        private bool isTook;
        private Transform player;

        public void Init(Sprite sprite, Transform player) {
            spriteRenderer.sprite = sprite;
            this.player = player;
        }
        
        private void Awake() {
            rigid = GetComponent<Rigidbody>();
            rigid.useGravity = false;
        }

        private void Update() {
            transform.LookAt(player);
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
