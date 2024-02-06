using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TopDownGunShoot
{
    [CreateAssetMenu(fileName = "Shared Behavior", menuName = "Data/Behavior/Shared Behavior")]
    public class CharacterSharedBehavior : ScriptableObject
    {
        public List<SharedBehaviorData> behaviors = new List<SharedBehaviorData>();
    }

    [Serializable]
    public class SharedBehaviorData
    {
        [ShowInInspector, ReadOnly]
        public BehaviorType behaviorType => behavior != null ? behavior.behaviorType : BehaviorType.none;

        [SerializeReference]
        public BaseBehavior behavior;
    }
}