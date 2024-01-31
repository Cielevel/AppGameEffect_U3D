using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

using Sirenix.OdinInspector;
using DG.Tweening;

public class TweenPosition : Tweenable
{

    [FoldoutGroup("Params")] public Vector3 valueIn = Vector2.zero;
    [FoldoutGroup("Params")] public Vector3 valueOut = Vector2.zero;
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
    [FoldoutGroup("Params")] public StartStateType startState = StartStateType.None;
    [FoldoutGroup("Params")] public bool activeWhenIn = false;
    [FoldoutGroup("Params")] public bool disactiveWhenOut = false;
    [FoldoutGroup("Params")] public bool destroyWhenOut = false;
    [Space]
    [FoldoutGroup("Params")] public bool x = true;
    [FoldoutGroup("Params")] public bool y = true;
    [FoldoutGroup("Params")] public bool z = true;
    [FoldoutGroup("Params")] public bool local = true;
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
            if (originValue == null) SetOriginValue();
            return originValue.Value;
        }
    }
    private Vector3? originValue;

    private RectTransform RectTransform
    {
        get
        {
            if (rectTransform == null ) rectTransform = GetComponent<RectTransform>();
            return rectTransform;
        }
    }
    private RectTransform rectTransform;

    private Vector3 curValue;
    private Tween tween;

    private void Start()
    {
        SetOriginValue();

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
                    .SetDelay(delayIn)
                    .OnComplete(OnInComplete);
           
            }
            else
            {
                tween = DOTween.To(() => curValue, x => SetValue(x), valueOut, timeOut)
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

    private void SetOriginValue()
    {
        if (originValue == null)
        {
            if (RectTransform) originValue = rectTransform.anchoredPosition;
            else originValue = local ? transform.localPosition : transform.position;
        }
    }

    private void SetValue ( Vector3 value)
    {
        curValue = value;

        if (RectTransform)
        {
            Vector2 pos = rectTransform.anchoredPosition;
            if (x) pos.x = relative ? (value.x + OriginValue.x) : (value.x);
            if (y) pos.y = relative ? (value.y + OriginValue.y) : (value.y);
            rectTransform.anchoredPosition = pos;
        }
        else
        {
            Vector3 pos = local? transform.localPosition : transform.position;
            if (x) pos.x = relative ? (value.x + OriginValue.x) : (value.x);
            if (y) pos.y = relative ? (value.y + OriginValue.y) : (value.y);
            if (z) pos.z = relative ? (value.z + OriginValue.z) : (value.z);

            if ( local ) transform.localPosition = pos;
            else transform.position = pos;
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

        if (onInComplete != null ) onInComplete.Invoke();
        if (triggerOutWhenInComplete) Out();
    }

    private void OnOutComplete()
    {
        state = false;

        if (onOutComplete != null) onOutComplete.Invoke();

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
