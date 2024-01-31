using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDownGunShoot
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        private InputSystem inputs;

        public event EventHandler OnInteractAction; // 交互
        public event EventHandler OnAttackAction; // 攻击
        public event EventHandler<Vector2> OnMoveAction; // 移动
        public event EventHandler<bool> OnSwtichWeaponAction; // 切换武器

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            InitializeInputSystem();
        }

        private void InitializeInputSystem()
        {
            inputs = new InputSystem();

            inputs.MainCharater.Interact.performed += Interact;
            inputs.MainCharater.Attack.performed += Attack;
            inputs.MainCharater.Move.performed += Move;
            inputs.MainCharater.SwitchWeapon.performed += SwitchWeapon;

            inputs.Enable();
        }

        private void CloseInputSystem()
        {
            inputs.Disable();
        }

        private void Move(InputAction.CallbackContext context)
        {
            Vector2 value = context.ReadValue<Vector2>();

            OnMoveAction?.Invoke(this, value);
        }

        private void Attack(InputAction.CallbackContext context)
        {

        }

        private void SwitchWeapon(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            Debug.Log(value);
        }

        private void Interact(InputAction.CallbackContext context)
        {

        }
    }
}
