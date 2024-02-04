using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TopDownGunShoot
{
    public abstract class GameActorBase : MonoBehaviour, IUseInputManager // GameActor的功能设计
    {
        [SerializeField] protected BehaviorRef moveBehaviorRef;
        [SerializeField] protected BehaviorRef attackBehaviorRef;
        [SerializeField] protected BehaviorRef InteractBehaviorRef;

        /// <summary>
        /// 向指定方向移动
        /// </summary>
        /// <param name="direction">移动方向</param>
        protected abstract void Move(Vector2 direction);

        protected abstract void Attack();

        protected abstract void Interact();

        /// <summary>
        /// 死亡（多种死亡方式）
        /// </summary>
        protected abstract void Dead(CauseOfDeath cause);

        #region On Awake and Start
        protected virtual void Awake()
        {

        }
        protected virtual void Start()
        {
            InitialInputControl();
        }
        #endregion

        public void InitialInputControl()
        {

        }
    }
}