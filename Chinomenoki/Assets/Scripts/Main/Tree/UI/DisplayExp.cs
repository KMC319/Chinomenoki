using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

namespace Main.Tree.UI {
    [RequireComponent(typeof(Image))]
    public class DisplayExp : MonoBehaviour {
        private Image image;

        [Inject] private TreeManager tree;

        private void Awake() {
            image = GetComponent<Image>();
            tree.Exp
                .Subscribe(x => image.fillAmount = x / (tree.Level.Value*100f))
                .AddTo(gameObject);
        }
    }
}
