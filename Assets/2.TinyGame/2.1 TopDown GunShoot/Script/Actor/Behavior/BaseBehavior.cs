using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    [SerializeField]
    public abstract class BaseBehavior : IUseFSMManager
    {
        protected Transform transform;
        protected GameObject gameObject;
        protected FSMManager fsmManager;

        public BaseBehavior(Transform transform, FSMManager fsmManager)
        {
            this.transform = transform;
            gameObject = transform.gameObject;

            this.fsmManager = fsmManager;
        }
        /// <summary>
        /// 在Behavior添加进去时，调用public void OnBehaviorAdd
        /// </summary>
        public abstract void OnBehaviorAdd(); // 用于一些通用自动化配置
        /// <summary>
        /// 在Behavior添加进去后，调用这个void IBehavior.OnBehaviorAdded
        /// </summary>
        protected abstract void OnBehaviorAdded(); // 用于一些通用自动化配置

        public abstract void Behave();

        public abstract void InitialFSMManager();
    }
}