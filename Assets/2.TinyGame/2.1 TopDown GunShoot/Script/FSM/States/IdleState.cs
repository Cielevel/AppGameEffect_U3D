using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TopDownGunShoot
{
    public class IdleState : BaseState
    {
        public override StatesClassification StatesClassification => StatesClassification.move;

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {

        }

        public override void OnExit()
        {

        }
    }
}