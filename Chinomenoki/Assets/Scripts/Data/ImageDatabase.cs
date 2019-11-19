using UnityEngine;

namespace Data {
    [CreateAssetMenu]
    public class ImageDatabase : ScriptableObject {
        [SerializeField] private ImageData[] data;
        public ImageData[] Data => data;
    }
}