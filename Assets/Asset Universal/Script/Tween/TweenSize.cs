﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

using Sirenix.OdinInspector;
using DG.Tweening;

public class TweenSize : Tweenable
{

    [FoldoutGroup("Params")] public Vector2 valueIn = new Vector2(100, 100);
    [FoldoutGroup("Params")] public Vector2 valueOut = new Vector2(50, 50);
    [Space]
    [FoldoutGroup("Params")] public float timeIn = 0.0f;
    [FoldoutGroup("Params")] public float timeOut = 0.0f;
    [Space]
    [FoldoutGroup("Params")] public Ease easeIn = Ease.OutCubic;
    [FoldoutGroup("Params")] public Ease easeOut = Ease.OutCubic;
    [Space]
    [FoldoutGroup("Params")] public float delayIn = 0.0f;
    [FoldoutGroup("Params")] public float delayOut = 0.0f;
    [Space]
    [FoldoutGroup("Params")] public bool startState = false;
    [FoldoutGroup("Params")] public bool activeWhenIn = false;
    [FoldoutGroup("Params")] public bool disactiveWhenOut = false;
    [FoldoutGroup("Params")] public bool destroyWhenOut = false;
    [Space]
    [FoldoutGroup("Params")] public bool x = true;
    [FoldoutGroup("Params")] public bool y = true;
    [FoldoutGroup("Params")] public bool relative = false;
    [Space]
    [FoldoutGroup("Params")] public bool ignoreTimeScale = true;
    [FoldoutGroup("Params")] public bool triggerOutWhenInComplete = false;

    [FoldoutGroup("Events")] public UnityEvent onInComplete;
    [FoldoutGroup("Events")] public UnityEvent onOutComplete;

    [Space, FoldoutGroup("Params")]
    public bool state = false;

    private Vector3 OriginValue
    {
        get
        {
            if (originValueSet == false)
            {
                originValueSet = true;

                originValue = RectTransform.sizeDelta;
            }

            return originValue;
        }
    }
    private Vector3 originValue;
    private bool originValueSet = false;

    private RectTransform RectTransform
    {
        get
        {
            if (rectTransform == null ) rectTransform = GetComponent<RectTransform>();
            return rectTransform;
        }
    }
    private RectTransform rectTransform;

    private Vector2 curValue;
    private Tween tween;
    private bool ignoreStartState = false;

    private void Start()
    {
        if ( ignoreStartState == false)
        {
            if (startState == true)
            {
                state = true;
                SetValue(valueIn);
            }
            else
            {
                state = false;
                SetValue(valueOut);
            }
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
                float t = timeIn;
                tween = DOTween.To(() => curValue, x => SetValue(x), valueIn, t)
                    .SetEase(easeIn)
                    .SetUpdate(ignoreTimeScale)
                    .SetDelay(delayIn)
                    .OnComplete(OnInComplete);
           
            }
            else
            {
                float t = timeOut;
                tween = DOTween.To(() => curValue, x => SetValue(x), valueOut, t)
                    .SetEase(easeOut)
                    .SetUpdate(ignoreTimeScale)
                    .SetDelay(delayOut)
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

    private void SetValue ( Vector3 value)
    {
        curValue = value;

        if (RectTransform)
        {
            Vector2 size = RectTransform.sizeDelta;
            if (x) size.x = relative ? (value.x + OriginValue.x) : (value.x);
            if (y) size.y = relative ? (value.y + OriginValue.y) : (value.y);
            RectTransform.sizeDelta = size;
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
        if (triggerOutWhenInComplete) Out();
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
