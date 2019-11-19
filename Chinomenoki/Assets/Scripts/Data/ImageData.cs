using System;
using UnityEngine;

namespace Data {
    [Serializable]
    public class ImageData {
        [SerializeField] private int id;
        [SerializeField] private Sprite icon;
        public int Id => id;
        public Sprite Icon => icon;
    }
}
