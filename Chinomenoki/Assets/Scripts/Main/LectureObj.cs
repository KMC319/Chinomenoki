using UnityEngine;

namespace Main {
    public class LectureObj : MonoBehaviour, ITakable {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Canvas description;
        private Rigidbody rigid;
        private bool isTook;
        private Transform player;

        public void Init(Sprite sprite, Transform player) {
            spriteRenderer.sprite = sprite;
            this.player = player;
        }
        
        private void Awake() {
            rigid = GetComponent<Rigidbody>();
            description.gameObject.SetActive(false);
        }

        private void Update() {
            if (isTook) {
                transform.position = player.position + player.forward*1.5f;
            }
            transform.LookAt(player);
        }

        public void Take(Transform parent) {
            rigid.Sleep();
            isTook = true;
            description.gameObject.SetActive(true);
        }

        public void Release() {
            rigid.WakeUp();
            rigid.useGravity = true;
            isTook = false;
            rigid.velocity = -transform.forward * 15f;
            description.gameObject.SetActive(false);
        }
    }
}
