using System.Collections.Generic;
using UnityEngine;

namespace ID.Extensions
{
    public static class LayerMaskExtensions
    {
        //Checks to see which layers a LayerMask includes
        public static List<int> HasLayers(this LayerMask layerMask)
        {
            List<int> hasLayers = new List<int>();

            for (int i = 0; i < 32; i++)
            {
                if (layerMask != (layerMask | (1 << i))) continue;
                hasLayers.Add(i);
            }
            return hasLayers;
        }
    }
}

