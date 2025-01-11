using System;
using UnityEngine;

namespace ID.Core
{
    public abstract class ManagerData : IInitializable
    {
        public abstract void Init();
        public abstract void CleanUp();
        public abstract void OnUpdate();
    }
}
