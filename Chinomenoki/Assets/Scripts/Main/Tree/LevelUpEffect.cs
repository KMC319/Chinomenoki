using UniRx;
using UnityEngine;
using Zenject;

namespace Main.Tree {
    [RequireComponent(typeof(ParticleSystem))]
    public class LevelUpEffect : MonoBehaviour {
        [Inject] private TreeManager tree;
        private int currentLevel;
        private ParticleSystem particle;

        private void Awake() {
            particle = GetComponent<ParticleSystem>();
            currentLevel = tree.Level.Value;
            tree.Level
                .Where(x => x > currentLevel)
                .Subscribe(x => {
                    currentLevel = x;
                    OnEffect();
                })
                .AddTo(gameObject);
        }

        private void OnEffect() {
            particle.Play();
        }
    }
}
