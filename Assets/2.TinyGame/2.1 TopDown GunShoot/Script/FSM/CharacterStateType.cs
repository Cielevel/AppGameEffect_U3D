using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    public enum CharacterStateType
    {
        none,
        idle,
        walk,
        sprint,
        jump,
        fall,
        crouch,
        sit,
        drive,
        die,
        pick_up,
        emote_yes,
        emote_no,
        holding_right,
        holding_left,
        holding_both,
        holding_right_shoot,
        holding_left_shoot,
        holding_both_shoot,
        attack_melee_right,
        attack_melee_left,
        attack_kick_right,
        attack_kick_left,
        interact_right,
        interact_left,
    }

    public enum StatesClassification
    {
        none,
        move,
        attack,
        interact,
        holding,
    }
}
