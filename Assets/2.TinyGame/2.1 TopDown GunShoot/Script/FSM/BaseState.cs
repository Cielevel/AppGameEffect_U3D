using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    public abstract class BaseState
    {
        protected AnimatorManager animeManager;
        protected CharacterStateType stateType; // 每个状态独有的stateType
        protected float duration = 0;
        protected float durationTimer = 0;

        public abstract StatesClassification StatesClassification { get; }

        public BaseState() { }
        public BaseState(AnimatorManager animManager, CharacterStateType stateType)
        {
            this.animeManager = animManager;
            this.stateType = stateType;
        }

        public void Initial(AnimatorManager animManager, CharacterStateType stateType)
        {
            this.animeManager = animManager;
            this.stateType = stateType;
        }

        public void Initial(AnimatorManager animManager, CharacterStateType stateType, float duration)
        {
            this.animeManager = animManager;
            this.stateType = stateType;
            this.duration = duration;
        }

        public virtual void OnEnter()
        {
            animeManager.Play(stateType);
            durationTimer = duration;
        }
        public abstract void OnUpdate();
        public abstract void OnExit();
    }
}