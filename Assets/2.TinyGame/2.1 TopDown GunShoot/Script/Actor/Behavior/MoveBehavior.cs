using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using MyUtilities;

namespace TopDownGunShoot
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(FSMManager))]
    public class MoveBehavior : BaseBehavior, VectorUtility
    {
        public override BehaviorType behaviorType => BehaviorType.move;

        [SerializeField] private CharacterController controller;

        [SerializeField, FoldoutGroup("Move Param")] private CharacterControllerConfig config;
        [SerializeField, FoldoutGroup("Move Param")] private bool isUseConfig = true;
        [SerializeField, FoldoutGroup("Move param")] private float moveSpeed;
        [SerializeField, FoldoutGroup("Move param")] private float rotateSpeed;
        [SerializeField, FoldoutGroup("Move param")] private float jumpHeight;

        private Vector3 moveVector = Vector3.zero;

        public MoveBehavior(Transform transform, FSMManager fsmManger) : base(transform, fsmManger)
        {

        }

        private void Awake()
        {
            (this as IUseFSMManager).InitialFSMManager();
        }

        private void Start()
        {
            // if (controller == null)
            //     controller = GetComponent<CharacterController>();

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
            // if (GetComponent<FSMManager>() == null)
            //     gameObject.AddComponent<FSMManager>();

            // if (GetComponent<CharacterController>() == null)
            //     gameObject.AddComponent<CharacterController>();
#endif
        }
        #endregion

        #region IUseFSMManaer
        public override void InitialFSMManager()
        {
            // fsmManager = GetComponent<FSMManager>();
            fsmManager.AddState(CharacterStateType.idle, new IdleState(), StatesClassification.move);
            fsmManager.AddState(CharacterStateType.walk, new WalkState(), StatesClassification.move);
            fsmManager.AddState(CharacterStateType.walk, new SprintState(), StatesClassification.attack);
        }
        #endregion

        // 移动的输入控制--需适配多平台
        private void MoveAction(object sender, Vector2 value) // value already normalized
        {
            // v2-->v3 --> y==z
            moveVector = this.Vector2ToVector3(value);
        }

        private void HandleMovement()
        {
            controller.SimpleMove(moveVector * moveSpeed); // 移动

            if (moveVector != Vector3.zero) // 移动时转向，非移动时保持方向
            {
                transform.forward = Vector3.Slerp(transform.forward, moveVector, Time.deltaTime * rotateSpeed);
            }
        }

        private void HandleFSM() // test --> FSM的使用还需要更解耦
        {
            fsmManager.SetState(moveVector != Vector3.zero ? CharacterStateType.walk : CharacterStateType.idle);
        }
    }
}