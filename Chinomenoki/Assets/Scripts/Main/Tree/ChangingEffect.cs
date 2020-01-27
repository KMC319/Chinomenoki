using UniRx;
using UnityEngine;
using Zenject;

namespace Main.Tree {
    [RequireComponent(typeof(ParticleSystem))]
    public class ChangingEffect : MonoBehaviour {
        [Inject] private TreeManager tree;
        private ParticleSystem particle;

        private void Awake() {
            particle = GetComponent<ParticleSystem>();
            tree.Level
                .Where(x => x >= 5)
                .Subscribe(x => {
                    OnEffect();
                })
                .AddTo(gameObject);
        }

        private void OnEffect() {
            particle.Play();
        }
    }
}
