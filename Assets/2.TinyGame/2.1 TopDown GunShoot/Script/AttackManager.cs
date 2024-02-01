using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    [RequireComponent(typeof(FSMManager))]
    public class AttackManager : MonoBehaviour, IUseFSMManager, IUseInputManager
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

        void IUseInputManager.InitialInputControl()
        {
            InputManager.Instance.OnAttackAction += AttackAction;
        }

        void IUseFSMManager.InitialFSMManager()
        {
            fsmManager = GetComponent<FSMManager>();

            fsmManager.AddState(CharacterStateType.attack_kick_right, new AttackKickState(), StatesClassification.attack); // д╛хоср╫елъ
        }

        private void AttackAction(object sender, EventArgs eventArgs)
        {
            fsmManager.SetState(CharacterStateType.attack_kick_right);
        }
    }
}