using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    [RequireComponent(typeof(FSMManager))]
    public class AttackBehavior : BaseBehavior, IUseFSMManager
    {
        private FSMManager fsmManager;

        private void Awake()
        {
            (this as IUseFSMManager).InitialFSMManager();
        }

        private void Start()
        {
            (this as IUseInputManager).InitialInputControl();
        }

        #region IBehavior
        public override void Behave()
        {
            // InputManager.Instance.OnMoveAction += MoveAction;
        }

        public override void OnBehaviorAdd()
        {
            OnBehaviorAdded();
        }
        protected override void OnBehaviorAdded()
        {
#if UNITY_EDITOR
            if (GetComponent<FSMManager>() == null)
                gameObject.AddComponent<FSMManager>();

            if (GetComponent<CharacterController>() == null)
                gameObject.AddComponent<CharacterController>();
#endif
        }
        #endregion

        #region IUseFSMManager
        void IUseFSMManager.InitialFSMManager()
        {
            fsmManager = GetComponent<FSMManager>();

            fsmManager.AddState(CharacterStateType.attack_kick_right, new AttackKickState(), StatesClassification.attack); // 
        }
        #endregion

        private void AttackAction(object sender, EventArgs eventArgs)
        {
            fsmManager.SetState(CharacterStateType.attack_kick_right);
        }
    }
}