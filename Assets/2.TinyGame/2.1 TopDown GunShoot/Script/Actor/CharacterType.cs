// log:
// -2024/2/7-
// TODO 角色的种类将可能决定一些伤害系数，如具有克制关系的角色（如：驱魔师-->吸血鬼、鬼魂）

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    public enum CharacterType
    {
        Human,
        Vampires,
        Ghost,
    }
}