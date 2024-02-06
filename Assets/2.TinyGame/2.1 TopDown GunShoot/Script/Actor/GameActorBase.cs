using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TopDownGunShoot
{
    public abstract class GameActorBase : MonoBehaviour, IUseInputManager // GameActor的功能设计
    {
        [ShowInInspector] protected virtual CharacterType characterType => CharacterType.Human; // 当前Actor的角色类型 默认为人类
        [Space]
        [SerializeField, FoldoutGroup("Behavior Setting")] protected List<BehaviorType> ownedBehaviorTypes = new List<BehaviorType>(); // * 拥有的所有行为的种类 = sharedBehavior + ownBehavior
        protected HashSet<BehaviorType> ownedBehaviorTypeSet = new HashSet<BehaviorType>(); // 上述list将转化为HashSet以便于高效查询
        protected Dictionary<BehaviorType, BaseBehavior> ownedBehaviorTypeDict = new Dictionary<BehaviorType, BaseBehavior>(); // 用字典存储所有的行为，Key为行为具体类型，以便于获取和调用
        [Space]
        [SerializeField, FoldoutGroup("Behavior Setting")] protected CharacterSharedBehavior sharedBehavior;
        [SerializeField, FoldoutGroup("Behavior Setting")] protected CharacterOwnBehavior ownBehavior;

        #region Actor依赖组件
        protected FSMManager fsmManager { get; private set; }
        protected AnimatorManager animeManager { get; private set; }
        #endregion

        private Animator animator;

        #region Behavior的调用
        /// <summary>
        /// 向指定方向移动
        /// </summary>
        /// <param name="direction">移动方向</param>
        protected abstract void Move(Vector2 direction);

        protected abstract void Attack();

        protected abstract void Interact();
        #endregion

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
            fsmManager.OnUpdate();
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

        protected virtual void InitialActorBehaviors() // 初始化所有的行为，并标注出所有可用的行为（可用行为将调用行为接口）
        {
            var allBehaviors = sharedBehavior.behaviors.Concat(ownBehavior.behaviors);
            ownedBehaviorTypeDict = allBehaviors.ToDictionary(b => b.behaviorType, b => b.behavior);
            // ownedBehaviorTypes.Clear(); // * 暂时并不选择去清空，需要在Inspector中查看 -2024/2/6-

        }

        public virtual void InitialInputControl() // * 初始化input对该actor的控制（非player无需初始化）
        {

        }

        #region Inspector Method
#if UNITY_EDITOR
        [Button, FoldoutGroup("Behavior Setting"), Tooltip("将该角色拥有的所有behavior的type初始化到list中，用于窗口视察")]
        void InitialOwnedBehaviors() // 将该角色拥有的所有behavior的type初始化到list中
        {
            if (sharedBehavior != null) { sharedBehavior.behaviors.ForEach((b) => { ownedBehaviorTypes.Add(b.behaviorType); }); }
            if (ownBehavior != null) { ownBehavior.behaviors.ForEach((b) => { ownedBehaviorTypes.Add(b.behaviorType); }); }
        }
#endif
        #endregion
    }
}