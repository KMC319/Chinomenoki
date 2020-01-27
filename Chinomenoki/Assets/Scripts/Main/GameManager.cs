using System.Collections.Generic;
using System.Linq;
using Data;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;
using Zenject;

namespace Main {
    public class GameManager : MonoBehaviour {
        private void Update() {
            if (Input.GetKeyDown(KeyCode.R)) {
                Scene loadScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(loadScene.name);
            }
        }
    }
}
