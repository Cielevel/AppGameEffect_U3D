//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/2.TinyGame/2.1 TopDown GunShoot/Input System/Input System.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace TopDownGunShoot
{
    public partial class @InputSystem : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputSystem()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input System"",
    ""maps"": [
        {
            ""name"": ""Main Charater"",
            ""id"": ""ffb5c351-7581-47e7-9074-70a362842dbd"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4292a50e-a67f-4191-89c3-62fe08137e39"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""4debdadb-5b30-4c43-9c9f-e7821ffdacfa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""9a294ad9-e9be-43a3-9ee3-da10fe1186b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Value"",
                    ""id"": ""9c813630-271b-4bea-8b32-8ac4fb4f6af1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""e0d6dc53-19d2-4ba8-ab8e-34dea1fe2f6e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c1e3d01f-906e-483c-b6b2-cdac8d5f1253"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f940a206-cd1a-4f92-8073-5960ef96d283"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7439597f-e695-4c46-804d-b0b6b922415a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7d9e64f5-04ee-4eca-9cdc-a36caffb2a6f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""4969779c-0af2-4e91-b93f-f66a89b30588"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""248d2000-e5b3-41f7-bfb9-d2540d04de8c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9aab55ae-a021-4316-a08c-55c8e0538df7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8f666891-065e-48c1-b813-5d9b3f9fa02f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""82fd57dd-cf03-40df-8abc-1df618bb6d13"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""961ea4e0-e4cf-493c-a695-20ca3293b10c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ae113ae4-c874-4ada-a802-da5212a9a9c3"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8bf2f02a-1719-4341-89b8-240599676c95"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""38973483-23ca-4e37-9111-7d9da4cf7ac0"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""74f76289-9d67-4e76-b99c-7731a25463e0"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ba15921c-7ab6-4919-9963-2300aa7eae07"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bb872a7-0f77-494a-964e-546cab9e0ce2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""75b0804b-3742-415f-95a0-cb8a14897c07"",
                    ""path"": ""1DAxis(minValue=-0.5,maxValue=0.5)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f05225dd-e24f-43ab-a090-01ce578c5b70"",
                    ""path"": ""<Mouse>/scroll/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c5c7c25a-65f4-4ec6-8935-c8840c5207f2"",
                    ""path"": ""<Mouse>/scroll/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Main Charater
            m_MainCharater = asset.FindActionMap("Main Charater", throwIfNotFound: true);
            m_MainCharater_Move = m_MainCharater.FindAction("Move", throwIfNotFound: true);
            m_MainCharater_Interact = m_MainCharater.FindAction("Interact", throwIfNotFound: true);
            m_MainCharater_Attack = m_MainCharater.FindAction("Attack", throwIfNotFound: true);
            m_MainCharater_SwitchWeapon = m_MainCharater.FindAction("SwitchWeapon", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Main Charater
        private readonly InputActionMap m_MainCharater;
        private IMainCharaterActions m_MainCharaterActionsCallbackInterface;
        private readonly InputAction m_MainCharater_Move;
        private readonly InputAction m_MainCharater_Interact;
        private readonly InputAction m_MainCharater_Attack;
        private readonly InputAction m_MainCharater_SwitchWeapon;
        public struct MainCharaterActions
        {
            private @InputSystem m_Wrapper;
            public MainCharaterActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_MainCharater_Move;
            public InputAction @Interact => m_Wrapper.m_MainCharater_Interact;
            public InputAction @Attack => m_Wrapper.m_MainCharater_Attack;
            public InputAction @SwitchWeapon => m_Wrapper.m_MainCharater_SwitchWeapon;
            public InputActionMap Get() { return m_Wrapper.m_MainCharater; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MainCharaterActions set) { return set.Get(); }
            public void SetCallbacks(IMainCharaterActions instance)
            {
                if (m_Wrapper.m_MainCharaterActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_MainCharaterActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_MainCharaterActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_MainCharaterActionsCallbackInterface.OnMove;
                    @Interact.started -= m_Wrapper.m_MainCharaterActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_MainCharaterActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_MainCharaterActionsCallbackInterface.OnInteract;
                    @Attack.started -= m_Wrapper.m_MainCharaterActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_MainCharaterActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_MainCharaterActionsCallbackInterface.OnAttack;
                    @SwitchWeapon.started -= m_Wrapper.m_MainCharaterActionsCallbackInterface.OnSwitchWeapon;
                    @SwitchWeapon.performed -= m_Wrapper.m_MainCharaterActionsCallbackInterface.OnSwitchWeapon;
                    @SwitchWeapon.canceled -= m_Wrapper.m_MainCharaterActionsCallbackInterface.OnSwitchWeapon;
                }
                m_Wrapper.m_MainCharaterActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @SwitchWeapon.started += instance.OnSwitchWeapon;
                    @SwitchWeapon.performed += instance.OnSwitchWeapon;
                    @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                }
            }
        }
        public MainCharaterActions @MainCharater => new MainCharaterActions(this);
        public interface IMainCharaterActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnSwitchWeapon(InputAction.CallbackContext context);
        }
    }
}
