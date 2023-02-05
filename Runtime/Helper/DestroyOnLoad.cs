using UnityEngine;

namespace InexperiencedDeveloper.Helper
{
    public class DestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            Destroy(gameObject);
        }
    }
}

