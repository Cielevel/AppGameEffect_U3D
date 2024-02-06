// log:
// -2024/2/6-
// ==> 1.脚本不再是MonoBehaviour，改为了GameActor的一个内部组件
// ==> 2.因为不再是MonoBehaviour，脚本的Unity组件引用通过构造函数初始化

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    /// <summary>
    /// 每个角色的Animator管理器，用于管理组件Animator，播放动画以及其他操作
    /// </summary>
    public class AnimatorManager // 封装animator到一个manager，以便于更多的操作
    {
        [SerializeField] private AnimationPlayType animationPlayType;
        private Action<CharacterStateType> playAnime; // 用于选择一个方式进行Animation的播放

        public Animator animator { get; private set; }

        /// <summary>
        /// 枚举变量名字string的hashcode
        /// </summary>
        private Dictionary<CharacterStateType, int> animationHashCodes; // animation的hashcode表，用于减少字符串转hashcode的操作

        public AnimatorManager(Animator animator)
        {
            this.animator = animator;
        }

        void Start()
        {
            playAnime += animationPlayType switch
            {
                AnimationPlayType.By_Play => PlayAnime_Play,
                AnimationPlayType.By_Trigger => PlayAnime_Trigger,
                _ => PlayAnime_Play,
            };

            InitialAnimationHashCode();
        }

        private void InitialAnimationHashCode()
        {
            animationHashCodes = new Dictionary<CharacterStateType, int>();

            var stateTypes = (CharacterStateType[])Enum.GetValues(typeof(CharacterStateType));
            for (int i = 0; i < stateTypes.Length; i++)
            {
                animationHashCodes.TryAdd(stateTypes[i], Animator.StringToHash(stateTypes[i].ToString()));
            }
        }

        // 顿帧


        public void Play(CharacterStateType state)
        {
            playAnime?.Invoke(state);
        }

        public void PlayAnime_Play(CharacterStateType state) // 直接播放
        {
            animator.Play(animationHashCodes[state]);
        }

        public void PlayAnime_Trigger(CharacterStateType state) // Trigger播放--更流畅的衔接（在Unity Animator中）
        {
            animator.SetTrigger(animationHashCodes[state]);
        }
    }

    enum AnimationPlayType
    {
        By_Play,
        By_Trigger
    }
}