using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorManager : MonoBehaviour // ��װanimator��һ��manager���Ա��ڸ���Ĳ���
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