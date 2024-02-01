using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUtilities
{
    public interface VectorUtility { }

    public static class Vector3Utility
    {
        public static Vector3 Vector2ToVector3(this VectorUtility self, Vector2 v2)
        {
            return new Vector3(v2.x, 0, v2.y);
        }
    }
}