using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ID.Core
{
    public interface IInitializable
    {
        void Init(ManagerParams param);
        void CleanUp();
    }
}

