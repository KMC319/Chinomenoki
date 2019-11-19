using System.Collections.Generic;
using System.Linq;
using Data;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;

namespace Main {
    public class GameManager : MonoBehaviour {
        [SerializeField] private TextAsset data;
        [SerializeField] private LectureObj lectureObj;
        [SerializeField] private CameraMove player;
        [SerializeField] private ImageDatabase imageDatabase;

        private List<LectureData> curriculumData;
        
        private async void Start() {
            curriculumData = CsvLoader.LoadCurriculum(data);
            var cancel = this.GetCancellationTokenOnDestroy();
            for (int i = 1; i <= curriculumData.Max(x => x.SemesterNumber); i++) {
                var temp = curriculumData.Where(x => x.SemesterNumber == i).ToArray();
                var count = -temp.Length / 2;
                foreach (var lectureData in temp) {
                    var offset = Quaternion.Euler(0, 30 * count, 0) * (Vector3.right * player.transform.forward.x + Vector3.forward * player.transform.forward.z);
                    var obj = Instantiate(lectureObj,player.transform.position + 2 * offset, Quaternion.identity);
                    obj.Init(imageDatabase.Data.First(x => x.Id == lectureData.Id).Icon, player.transform);
                    count++;
                }

                await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.P), cancellationToken: cancel);
            }
        }
    }
}
