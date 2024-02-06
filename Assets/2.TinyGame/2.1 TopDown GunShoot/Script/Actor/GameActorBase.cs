using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TopDownGunShoot
{
    public abstract class GameActorBase : MonoBehaviour, IUseInputManager // GameActor的功能设计
    {
        [ShowInInspector] protected virtual CharacterType characterType => CharacterType.Human; // 当前Actor的角色类型 默认为人类
        [Space]
        [SerializeField, FoldoutGroup("Behavior Setting")] protected List<BehaviorType> ownedBeaviorTypes = new List<BehaviorType>(); // * 拥有的所有行为的种类 = sharedBehavior + ownBehavior
        protected HashSet<BehaviorType> ownedBehaviorTypeSet = new HashSet<BehaviorType>(); // 上述list将转化为HashSet以便于高效查询
        [Space]
        [SerializeField, FoldoutGroup("Behavior Setting")] protected CharacterSharedBehavior sharedBehavior;
        [SerializeField, FoldoutGroup("Behavior Setting")] protected CharacterOwnBehavior ownBehavior;

        #region Actor依赖组件
        protected FSMManager fsmManager { get; private set; }
        protected AnimatorManager animeManager { get; private set; }
        #endregion

        private Animator animator;

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
            InitialOnAwake();
        }
        protected virtual void Start()
        {
        }
        #endregion

        protected virtual void Update()
        {

        }

        protected virtual void InitialOnAwake() // 有严格顺序
        {
            InitialActorComponents();
            InitialInputControl();
            InitialActorBehaviors();
        }

        /// <summary>
        /// 初始化所有必要内部组件和行为
        /// </summary>
        protected virtual void InitialActorComponents()
        {
            animator = GetComponentInChildren<Animator>();

            // 初始化顺序：AnimatorManager-->FSMManager-->Behaviors

            animeManager = new AnimatorManager(animator);
            fsmManager = new FSMManager(animeManager);
        }

        protected virtual void InitialActorBehaviors()
        {
            ownedBehaviorTypeSet = new HashSet<BehaviorType>(ownedBeaviorTypes);
            // ownedBeaviorTypes.Clear(); // * 暂时并不选择去清空，需要在Inspector中查看 -2024/2/6-
        }

        public void InitialInputControl()
        {

        }

        #region Inspector Method
#if UNITY_EDITOR
        [Button, FoldoutGroup("Behavior Setting"), Tooltip("将该角色拥有的所有behavior的type初始化到list中")]
        void InitialOwnedBehaviors() // 将该角色拥有的所有behavior的type初始化到list中
        {
            if (sharedBehavior != null) { sharedBehavior.behaviors.ForEach((b) => { ownedBeaviorTypes.Add(b.behaviorType); }); }
            if (ownBehavior != null) { ownBehavior.behaviors.ForEach((b) => { ownedBeaviorTypes.Add(b.behaviorType); }); }
        }
#endif
        #endregion
    }
}