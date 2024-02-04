using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    [CreateAssetMenu(fileName = "Shared Behavior", menuName = "Data/Behavior/Shared Behavior")]
    public class CharacterSharedBehavior : ScriptableObject
    {
        public List<SharedBehaviorData> sharedBehaviors = new List<SharedBehaviorData>();
    }

    [Serializable]
    public class SharedBehaviorData
    {
        public BehaviorType behaviorType;

        [SerializeReference]
        public BaseBehavior behavior;
    }

    public enum BehaviorType
    {
        move,
        attack,
        interact,
    }
}