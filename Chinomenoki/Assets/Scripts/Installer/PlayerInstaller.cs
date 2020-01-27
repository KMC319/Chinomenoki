using UnityEngine;
using Zenject;

namespace Installer {
    public class PlayerInstaller : MonoInstaller{
        [SerializeField] private bool canUseSteamVR;
        [SerializeField] private Camera vRCam;
        [SerializeField] private Camera noVrCam;
        public override void InstallBindings() {
            var player = canUseSteamVR ? vRCam : noVrCam;
            Container.Bind<Camera>().FromInstance(player).AsCached();
        }
    }
}
