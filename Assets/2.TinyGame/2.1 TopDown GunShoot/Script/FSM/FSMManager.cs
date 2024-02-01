using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TopDownGunShoot
{
    public class FSMManager : MonoBehaviour // һ��FSM��Ӧһ����ɫ�������ڽ�ɫ�ĸ��ڵ㣬�������Manger���в�����
    {
        [SerializeField, FoldoutGroup("Basic Component")] private AnimatorManager animeManager;

        private Dictionary<CharacterStateType, BaseState> allStates;
        //private Dictionary<CharacterStateType, float> attackDurations; // ������Ҫ��ý��������ڹ���ʱ���������Ķ���

        private BaseState currentState;
        private CharacterStateType currStateType = CharacterStateType.none;
        private StatesClassification statesClassification = StatesClassification.none; // ��Ҫ������sub state����fsm�ڲ��жϣ�

        private void Awake() // ��ʼ��
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
                animeManager = GetComponent<AnimatorManager>();
        }

        private float GetAnimationDurationByType(CharacterStateType stateType) // �������ƻ�ȡ��������ʱ�������� ���Ź���������������������
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
        /// ���״̬
        /// </summary>
        /// <param name="stateType"></param>
        /// <param name="state"></param>
        public void AddState(CharacterStateType stateType, BaseState state, StatesClassification classification) // FSMManger��������Manger��ӵ�е���Ϣ���磺animator��
        {
            if (!allStates.ContainsKey(stateType))
            {
                switch(classification) // ������в�ͬ�ĳ�ʼ��
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
        /// ����x��״̬
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