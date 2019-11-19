using UnityEngine;

namespace Main {
    public interface ITakable {
        void Take(Transform parent);
        void Release();
    }
}