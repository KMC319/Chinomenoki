using System.Linq;
using Data;
using Main.Tree;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;
using Zenject;

namespace Main {
    public class LectureObj : MonoBehaviour {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Canvas description;
        [Inject] private ImageDatabase imageDatabase;
        [Inject] private TreeManager tree;
        private Rigidbody rigid;
        public LectureData ObjectData { get; private set; }

        private bool isTook;
        public bool IsReleased { get; private set; }
        public bool IsActive { get; private set; }
        private Transform player;

        public void Init(LectureData data, Transform player) {
            ObjectData = data;
            spriteRenderer.sprite = imageDatabase.Data.First(x => x.Id == data.Id).Icon;
            this.player = player;
            IsActive = true;
        }

        private void Awake() {
            description.gameObject.SetActive(false);
            rigid = GetComponentInParent<Rigidbody>();
            rigid.useGravity = false;
        }

        private void Update() {
            description.gameObject.SetActive(isTook);
            transform.LookAt(player);
        }

        public void OnPickUp() {
            isTook = true;
        }

        public void Release() {
            isTook = false;
            IsReleased = true;
            rigid.useGravity = true;
        }

        public async UniTaskVoid Destroy() {
            var token = this.GetCancellationTokenOnDestroy();
            var time = 0.3f;
            while (time > 0) {
                time -= Time.deltaTime;
                transform.localScale = Vector3.Lerp(Vector3.zero, transform.localScale, time / 0.3f);
                transform.position = Vector3.Lerp(tree.transform.position, transform.position, time / 0.3f);
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }

            Destroy(gameObject);
        }
    }
}
