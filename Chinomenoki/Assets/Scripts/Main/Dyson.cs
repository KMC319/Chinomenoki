using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Main {
    public class Dyson : MonoBehaviour {
        private List<Rigidbody> targets = new List<Rigidbody>();

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.TryGetComponent(out LectureObj temp) && temp.IsReleased) {
                targets.Add(temp.GetComponentInParent<Rigidbody>());
            }
        }

        private void Update() {
            targets = targets.Where(x => x != null).ToList();
            foreach (var target in targets) {
                target.AddForce((transform.position - target.position).normalized * 5);
            }
        }
    }
}
