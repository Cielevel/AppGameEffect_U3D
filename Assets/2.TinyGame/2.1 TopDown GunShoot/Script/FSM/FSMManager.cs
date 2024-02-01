using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TopDownGunShoot
{
    public class FSMManager : MonoBehaviour // 一个FSM对应一个角色，挂载在角色的父节点，将被多个Manger持有并调用
    {
        [SerializeField, FoldoutGroup("Basic Component")] private AnimatorManager animeManager;

        private Dictionary<CharacterStateType, BaseState> allStates;
        //private Dictionary<CharacterStateType, float> attackDurations; // 攻击需要多久结束，用于攻击时屏蔽其他的动作

        private BaseState currentState;
        private CharacterStateType currStateType = CharacterStateType.none;
        private StatesClassification statesClassification = StatesClassification.none; // 需要交付给sub state处理？fsm内部判断？

        private void Awake() // 初始化
        {
            InitialInAwake();
        }

        private void Update()
        {
            currentState?.OnUpdate();
        }

        private void InitialInAwake()
        {
            InitialParams();
        }

        private void InitialParams() // 1
        {
            allStates = new Dictionary<CharacterStateType, BaseState>();

            if (!animeManager)
                animeManager = GetComponentInChildren<AnimatorManager>();
        }

        private float GetAnimationDurationByType(CharacterStateType stateType) // 根据名称获取动画播放时长（用于 播放攻击动画屏蔽其他动画）
        {
            var runtimeAnimator = animeManager.animator.runtimeAnimatorController;

            foreach (var clip in runtimeAnimator.animationClips)
            {
                if (clip.name.Equals(stateType.ToString()))
                {
                    return clip.length;
                }
            }

            return 0f;
        }

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="stateType"></param>
        /// <param name="state"></param>
        public void AddState(CharacterStateType stateType, BaseState state, StatesClassification classification) // FSMManger持有其他Manger不拥有的信息（如：animator）
        {
            if (!allStates.ContainsKey(stateType))
            {
                switch (classification) // 按类进行不同的初始化
                {
                    case StatesClassification.move:
                        state.Initial(animeManager, stateType);
                        break;
                    case StatesClassification.attack:
                        state.Initial(animeManager, stateType, GetAnimationDurationByType(stateType));
                        break;
                    case StatesClassification.interact:
                        state.Initial(animeManager, stateType);
                        break;
                    case StatesClassification.holding:
                        state.Initial(animeManager, stateType);
                        break;
                    default:
                        state.Initial(animeManager, stateType);
                        break;
                }

                allStates.Add(stateType, state);
            }
        }

        /// <summary>
        /// 设置x新状态
        /// </summary>
        /// <param name="stateType"></param>
        public void SetState(CharacterStateType stateType)
        {
            if (currStateType == stateType) return;

            currentState?.OnExit();

            currentState = allStates[stateType];
            currStateType = stateType;
            currentState.OnEnter();
        }
    }
}