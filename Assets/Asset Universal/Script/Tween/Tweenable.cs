using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class Tweenable : MonoBehaviour
{
    public abstract bool State { get; set; }

    public abstract void In();
    public abstract void Out();
    public abstract void ForceIn();
    public abstract void ForceOut();

    public enum StartStateType
    {
        None,
        In,
        Out
    }
}
