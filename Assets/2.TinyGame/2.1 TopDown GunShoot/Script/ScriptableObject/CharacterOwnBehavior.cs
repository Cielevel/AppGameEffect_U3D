using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    [CreateAssetMenu(fileName = "Own Behavior", menuName = "Data/Behavior/Own Behavior")]
    public class CharacterOwnBehavior : ScriptableObject
    {
        public List<SharedBehaviorData> behaviors = new List<SharedBehaviorData>();
    }
}