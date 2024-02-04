using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    public class GameActor : GameActorBase // 基本的Actor（所有角色--Plyaer，NPC 适用）
    {
        protected override void Move(Vector2 direction)
        {
            // moveBehavior?.Behave();
        }

        protected override void Attack()
        {
            // attackBehavior?.Behave();
        }

        protected override void Interact()
        {
            // interactBehavior?.Behave();
        }

        protected override void Dead(CauseOfDeath cause)
        {

        }
    }
}