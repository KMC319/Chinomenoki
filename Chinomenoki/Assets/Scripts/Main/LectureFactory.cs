using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Zenject;

namespace Main {
    public class LectureFactory : MonoBehaviour {
        [SerializeField] private Throwable lectureObj;
        [SerializeField] private Transform parent;
        [SerializeField] private AreaName area;
        [SerializeField] private Vector3 offset;
        [SerializeField] private Direction direction;
        [SerializeField] private int skip;
        [SerializeField] private int upper;
        [Inject] private List<LectureData> curriculumData;
        [Inject] private Camera player;
        [Inject] private DiContainer container;

        private void Start() {
            var temp = curriculumData.Where(x => x.AreaName == area)
                .Skip(skip)
                .ToArray();
            if (upper > 0) {
                temp = temp.Take(upper).ToArray();
            }

            var count = 0;
            foreach (var lectureData in temp) {
                var pos = Vector3.zero;
                switch (direction) {
                    case Direction.Vertical:
                        break;
                    case Direction.Horizontal:
                        pos = parent.position
                              + offset
                              + (count % 5) * Vector3.right * 0.5f
                              + (count / 5) * Vector3.down * 0.7f;
                        break;
                    case Direction.Forward:
                        pos = parent.position
                              + offset
                              + (count % 5) * Vector3.forward * 0.5f
                              + (count / 5) * Vector3.down * 0.7f;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var obj = container.InstantiatePrefab(lectureObj,
                    pos,
                    Quaternion.identity,
                    null);
                obj.GetComponentInChildren<LectureObj>().Init(lectureData, player.transform);
                count++;
            }
        }

        private void OnDrawGizmos() {
            Gizmos.DrawWireSphere(parent.position + offset, 0.25f);
        }

        private enum Direction {
            Vertical, Horizontal, Forward
        }
    }
}
