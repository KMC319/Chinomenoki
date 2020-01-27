using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace Main.UI {
    [RequireComponent(typeof(Text))]
    public class DisplayCurriculumDescription  : MonoBehaviour {
        private LectureObj lectureObj;
        private Text text;

        private void Awake() {
            Init().Forget();
        }

        private async UniTaskVoid Init() {
            var token = this.GetCancellationTokenOnDestroy();
            lectureObj = GetComponentInParent<LectureObj>();
            text = GetComponent<Text>();
            await UniTask.WaitUntil(() => lectureObj.IsActive, cancellationToken: token);
            text.text = lectureObj.ObjectData.Description;
        }
    }
}
