using System;
using UnityEngine;

namespace ID.Core
{
    [Obsolete("Use ManagerData. Moving toward a different method of managers.")]
    public abstract class Manager : MonoBehaviour, IInitializable
    {
        public abstract void Init();
        public abstract void CleanUp();
    }
}
