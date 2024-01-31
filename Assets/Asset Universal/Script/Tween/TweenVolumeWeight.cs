using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.Rendering;

using Sirenix.OdinInspector;
using DG.Tweening;

public class TweenVolumeWeight : Tweenable
{

    [FoldoutGroup("Params")] public float valueIn = 1.0f;
    [FoldoutGroup("Params")] public float valueOut = 0.0f;
    [Space]
    [FoldoutGroup("Params")] public float timeIn = 1.0f;
    [FoldoutGroup("Params")] public float timeOut = 1.0f;
    [Space]
    [FoldoutGroup("Params")] public Ease easeIn = Ease.OutCubic;
    [FoldoutGroup("Params")] public Ease easeOut = Ease.OutCubic;
    [Space]
    [FoldoutGroup("Params")] public float delayIn = 0.0f;
    [FoldoutGroup("Params")] public float delayOut = 0.0f;
    [Space]
    [FoldoutGroup("Params")] public StartStateType startState = StartStateType.None;
    [FoldoutGroup("Params")] public bool activeWhenIn = false;
    [FoldoutGroup("Params")] public bool destroyWhenOut = false;
    [FoldoutGroup("Params")] public bool disactiveWhenOut = false;
    [Space]
    [FoldoutGroup("Params")] public bool relative = false;
    [FoldoutGroup("Params")] public bool multiplier = false;
    [Space]
    [FoldoutGroup("Params")] public bool ignoreTimeScale = true;

    [FoldoutGroup("Events")] public UnityEvent onInComplete;
    [FoldoutGroup("Events")] public UnityEvent onOutComplete;

    [Space, FoldoutGroup("Params")]
    public bool state = false;

    private float OriginValue
    {
        get
        {
            if (originValueSetted == false)
            {
                originValueSetted = true;

                if (volume)
                {
                    originValue = volume.weight;
                }
            }
            return originValue;
        }
    }
    private float originValue;
    private bool originValueSetted = false;


    private Volume Volume
    {
        get
        {
            if (volume == null) volume = GetComponent<Volume>();
            return volume;
        }
    }
    private Volume volume;

    private float curValue;
    private Tween tween;
    private bool ignoreStartState = false;

    private void Start()
    {
        if (startState == StartStateType.In)
        {
            state = true;
            SetValue(valueIn);
        }
        else if (startState == StartStateType.Out)
        {
            state = false;
            SetValue(valueOut);
        }
    }

    public override bool State
    {
        get
        {
            return state;
        }
        set
        {
            ignoreStartState = true;

            if ( state == value)
            {
                return;
            }

            if (activeWhenIn == true) gameObject.SetActive(true);

            state = value;

            tween?.Kill();

            if (state == true)
            {
                tween = DOTween.To(() => curValue, x => SetValue(x), valueIn, timeIn)
                    .SetEase(easeIn)
                    .SetUpdate(ignoreTimeScale)
                    .OnComplete(OnInComplete);
           
            }
            else
            {
                tween = DOTween.To(() => curValue, x => SetValue(x), valueOut, timeOut)
                    .SetEase(easeOut)
                    .SetUpdate(ignoreTimeScale)
                    .OnComplete(OnOutComplete);

                
            }
        }
    }

    [FoldoutGroup("Actions"), Button("In")]
    public override void In()
    {
        if ( state == false )
        {
            SetValue(valueOut);
            State = true;
        }
    }

    [FoldoutGroup("Actions"), Button("Out")]
    public override void Out()
    {
        if ( state == true )
        {
            SetValue(valueIn);
            State = false;
        }
    }

    public override void ForceIn()
    {
        ForceSetState(false);
        In();
    }

    public override void ForceOut()
    {
        ForceSetState(true);
        Out();
    }

    private void SetValue ( float value)
    {
        curValue = value;

        if (Volume)
        {
            if (relative) Volume.weight = value + OriginValue;
            else
            if ( multiplier) Volume.weight = value * OriginValue;
            else
            {
                Volume.weight = value;
            }
        }
    }

    //强制设置状态
    public void ForceSetState(bool state)
    {
        this.state = state;
        SetValue( state ? valueIn : valueOut);
    }

    private void OnInComplete()
    {
        state = true;

        onInComplete.Invoke();
    }

    private void OnOutComplete()
    {
        state = false;

        onOutComplete.Invoke();

        if (destroyWhenOut == true) GameObject.Destroy(gameObject);
        if (disactiveWhenOut == true) gameObject.SetActive(false);
    }

    public float TimeIn
    {
        get { return timeIn; }
        set { timeIn = value; }
    }

    public float TimeOut
    {
        get { return timeOut; }
        set { timeOut = value; }
    }
}
