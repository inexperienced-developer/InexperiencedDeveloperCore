using UnityEngine;

namespace InexperiencedDeveloper.Core
{
    public abstract class Manager : MonoBehaviour, IInitializable
    {
        public abstract void Init();
        public abstract void CleanUp();
    }
}
