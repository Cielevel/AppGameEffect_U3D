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
        public event EventHandler<Vector2> OnMoveAction; // 移动--主动调用并传递vector2
        public event EventHandler<bool> OnSwtichWeaponAction; // 切换武器

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            InitializeInputSystem();
        }

        private void Update()
        {
            HandleMoveInput();
        }

        private void InitializeInputSystem()
        {
            inputs = new InputSystem();

            inputs.MainCharater.Interact.performed += Interact;
            inputs.MainCharater.Attack.performed += Attack;
            //inputs.MainCharater.Move.performed += Move;
            inputs.MainCharater.SwitchWeapon.performed += SwitchWeapon;

            inputs.Enable();
        }

        private void CloseInputSystem()
        {
            inputs.Disable();
        }

        private void HandleMoveInput() // move无法通过performed来实现被动监听，需要update主动监听
        {
            Vector2 value = inputs.MainCharater.Move.ReadValue<Vector2>();

            OnMoveAction?.Invoke(this, value.normalized);
        }

        private void Attack(InputAction.CallbackContext context)
        {
            Debug.Log("Attack");
        }

        private void SwitchWeapon(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            Debug.Log(value);
        }

        private void Interact(InputAction.CallbackContext context)
        {
            Debug.Log("Interact");
        }
    }
}
