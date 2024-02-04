using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TopDownGunShoot
{
    [Serializable]
    public class BehaviorRef
    {
        [SerializeReference]
        protected BaseBehavior behavior;

        private GameObject gameObject;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="action"></param>
        BehaviorRef(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        [FoldoutGroup("Behavior Config"), ShowInInspector]
        protected bool Can_Move
        {
            get { return can_Move; }
            private set
            {
                if (value && behavior == null)
                {
                    behavior.OnBehaviorAdd();
                }

                if (!value && behavior != null)
                {
                    behavior = null;
                }
            }
        }
        private bool can_Move = true;
    }
}