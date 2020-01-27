using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Main.Tree.UI {
    [RequireComponent(typeof(Text))]
    public class DisplayLevel : MonoBehaviour {
        private Text text;
        [Inject] private TreeManager tree;

        private void Awake() {
            text = GetComponent<Text>();
            tree.Level
                .Subscribe(x => text.text = $"ランク{x}")
                .AddTo(gameObject);
        }
    }
}
