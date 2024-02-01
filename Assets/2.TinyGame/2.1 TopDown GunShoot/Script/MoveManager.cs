using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using MyUtilities;
using UnityEditor;
using UnityEngine.UI;
using Unity.VisualScripting;

namespace TopDownGunShoot
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(FSMManager))]
    public class MoveManager : MonoBehaviour, VectorUtility, IUseFSMManager, IUseInputManager
    {
        [SerializeField] private CharacterController controller;


        [SerializeField, FoldoutGroup("Move Param")] private CharacterControllerConfig config;
        [SerializeField, FoldoutGroup("Move Param")] private bool isUseConfig = true;
        [Space]
        [SerializeField, FoldoutGroup("Move param")] private float moveSpeed;
        [SerializeField, FoldoutGroup("Move param")] private float rotateSpeed;
        [SerializeField, FoldoutGroup("Move param")] private float jumpHeight;

        private Vector3 moveVector = Vector3.zero;

        private FSMManager fsmManager;

        private void Awake()
        {
            (this as IUseFSMManager).InitialFSMManager();
        }

        private void Start()
        {
            if (controller == null)
                controller = GetComponent<CharacterController>();

            if (isUseConfig && config)
            {
                config.ConfigurationInject(controller);
            }

            (this as IUseInputManager).InitialInputControl();
        }

        private void Update()
        {
            HandleMovement();
            HandleFSM();
        }

        void IUseInputManager.InitialInputControl() // ��awke��awake�ڻ��ʼ��InputManager.Instance�Լ�InputSystem��
        {
            InputManager.Instance.OnMoveAction += MoveAction;
        }

        void IUseFSMManager.InitialFSMManager()
        {
            fsmManager = GetComponent<FSMManager>();
            fsmManager.AddState(CharacterStateType.idle, new IdleState(), StatesClassification.move);
            fsmManager.AddState(CharacterStateType.walk, new WalkState(), StatesClassification.move);
            fsmManager.AddState(CharacterStateType.walk, new SprintState(), StatesClassification.attack);
        }

        // �ƶ����������--�������ƽ̨
        private void MoveAction(object sender, Vector2 value) // value already normalized
        {
            // v2-->v3 --> y==z
            moveVector = this.Vector2ToVector3(value);
        }

        private void HandleMovement()
        {
            controller.SimpleMove(moveVector * moveSpeed); // �ƶ�

            if (moveVector != Vector3.zero) // �ƶ�ʱת�򣬷��ƶ�ʱ���ַ���
            {
                transform.forward = Vector3.Slerp(transform.forward, moveVector, Time.deltaTime * rotateSpeed);

            }
        }

        private void HandleFSM() // test --> FSM��ʹ�û���Ҫ������
        {
            fsmManager.SetState(moveVector != Vector3.zero ? CharacterStateType.walk : CharacterStateType.idle);
        }
    }
}