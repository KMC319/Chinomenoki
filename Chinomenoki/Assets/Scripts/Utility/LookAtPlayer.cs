using UnityEngine;
using Zenject;

namespace Utility {
    public class LookAtPlayer : MonoBehaviour {
        [Inject] private Camera player;
        private void Update() {
            transform.LookAt(player.transform);
        }
    }
}
