using System;
using System.Collections.Generic;
using Data;
using UniRx;
using UnityEngine;
using UniRx.Async;
using UniRx.Async.Triggers;

namespace Main.Tree {
    [RequireComponent(typeof(Collider))]
    public class TreeManager : MonoBehaviour {
        public readonly ReactiveProperty<float> Exp = new ReactiveProperty<float>();
        public readonly ReactiveProperty<int> Level = new ReactiveProperty<int>(1);
        private bool isLevelUp;
        private List<LectureData> tookLectures = new List<LectureData>();
        [SerializeField] private GameObject bigTree;
            
        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.TryGetComponent(out LectureObj temp)) {
                tookLectures.Add(temp.ObjectData);
                GetExp(100).Forget();
                temp.Destroy().Forget();
            }
        }

        private void Update() {
            CheckLevel();
        }

        private async UniTaskVoid GetExp(float point) {
            var token = this.GetCancellationTokenOnDestroy();
            while (point > 0) {
                await UniTask.WaitUntil(() => !isLevelUp, cancellationToken: token);
                Exp.Value += 2;
                point -= 2;
                await UniTask.Yield();
            }
        }

        private void CheckLevel() {
            if (Exp.Value >= Level.Value * 100) {
                Exp.Value -= Level.Value * 100;
                Level.Value++;
                LevelUp(Level.Value).Forget();
            }
        }

        private async UniTaskVoid LevelUp(int level) {
            var token = this.GetCancellationTokenOnDestroy();
            isLevelUp = true;
            var time = 0f;
            var growTime = 0.3f;
            var startPos = transform.position;
            var goalPos =  Vector3.Scale(transform.position, new Vector3(1, 0.5f, 1));
            var startSca = transform.localScale;
            var goalSca = transform.localScale * 2f;
            if (level >= 5) {
                GrowUp().Forget();
                return;
            } 
            while (time <growTime) {
                time += Time.deltaTime;
                var amount = time / growTime;
                transform.position = Vector3.Lerp(startPos, goalPos, amount);
                transform.localScale = Vector3.Lerp(startSca, goalSca, amount);
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }

            isLevelUp = false;
        }

        private async UniTaskVoid GrowUp() {
            var token = this.GetCancellationTokenOnDestroy();
            await UniTask.Delay(TimeSpan.FromSeconds(0.2f), cancellationToken: token);
            bigTree.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
