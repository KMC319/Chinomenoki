using System.Collections.Generic;
using Data;
using UnityEngine;
using Zenject;

namespace Installer {
    public class DatabaseInstaller : MonoInstaller {
        [SerializeField] private ImageDatabase imageDatabase;
        [SerializeField] private TextAsset data;
        public override void InstallBindings() {
            var curriculumData = CsvLoader.LoadCurriculum(data);
            Container.Bind<ImageDatabase>().FromInstance(imageDatabase).AsSingle();
            Container.BindInstance(curriculumData).AsSingle();
        }
    }
}
