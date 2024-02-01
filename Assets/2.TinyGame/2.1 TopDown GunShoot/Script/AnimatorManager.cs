using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorManager : MonoBehaviour // 封装animator到一个manager，以便于更多的操作
    {
        public Animator animator { get; private set; }

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Play(CharacterStateType state)
        {
            animator.Play(state.ToString());
        }
    }
}