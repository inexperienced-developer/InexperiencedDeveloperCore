using System;

namespace ID.Core
{
    [Serializable]
    public abstract class ManagerData : IInitializable
    {
        public abstract void Init(ManagerParams param);
        public abstract void CleanUp();
        public abstract void OnUpdate(ManagerParams param);
    }
}
