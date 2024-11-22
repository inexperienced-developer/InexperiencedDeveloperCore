using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InexperiencedDeveloper.Core
{
    public interface IInitializable
    {
        void Init();
        void CleanUp();
    }
}

