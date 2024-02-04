using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    public enum CauseOfDeath
    {
        /// <summary>
        /// 死于普通伤害--冷兵器
        /// </summary>
        Damage,
        /// <summary>
        /// 死于爆炸
        /// </summary>
        Explosion,
        /// <summary>
        /// 死于霰弹枪
        /// </summary>
        Shotgun,
    }
}