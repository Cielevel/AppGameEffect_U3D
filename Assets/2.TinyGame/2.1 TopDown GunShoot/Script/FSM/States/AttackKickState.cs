using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    public class AttackKickState : BaseState
    {
        public override StatesClassification StatesClassification => StatesClassification.attack;

        public override void OnEnter()
        {
            //base.OnEnter();
            // kick有左脚有右脚，当前默认右脚
        }

        public override void OnUpdate()
        {
            duration -= Time.deltaTime;

            if (durationTimer <= 0)
            {
                OnExit();
            }
        }

        public override void OnExit()
        {

        }
    }
}