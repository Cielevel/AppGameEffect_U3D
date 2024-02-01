using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

using Sirenix.OdinInspector;
using DG.Tweening;
using TMPro;

public class TweenAlpha : Tweenable
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
    [FoldoutGroup("Params")] public bool multiplier = false;
    [Space]
    [FoldoutGroup("Params")] public StartStateType startState = StartStateType.None;
    [FoldoutGroup("Params")] public bool activeWhenIn = false;
    [FoldoutGroup("Params")] public bool disactiveWhenOut = false;
    [FoldoutGroup("Params")] public bool triggerOutWhenInComplete = false;
    [FoldoutGroup("Params")] public bool destroyWhenOut = false;
    [Space]
    [FoldoutGroup("Params")] public bool ignoreTimeScale = true;
    [Space]
    [FoldoutGroup("Events")] public UnityEvent onInComplete;
    [FoldoutGroup("Events")] public UnityEvent onOutComplete;

    private CanvasGroup CanvasGroup
    {
        get
        {
            if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
            return canvasGroup;
        }
    }
    private CanvasGroup canvasGroup;

    private Image Image
    {
        get
        {
            if (image == null) image = GetComponent<Image>();
            return image;
        }
    }
    private Image image;

    private SpriteRenderer SpriteRenderer
    {
        get
        {
            if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
            return spriteRenderer;
        }
    }
    private SpriteRenderer spriteRenderer;

    private TextMeshProUGUI Text
    {
        get
        {
            if (text == null) text = GetComponent<TextMeshProUGUI>();
            return text;
        }
    }
    private TextMeshProUGUI text;

    private TextMeshPro TextMesh
    {
        get
        {
            if (textMesh == null) textMesh = GetComponent<TextMeshPro>();
            return textMesh;
        }
    }
    private TextMeshPro textMesh;

    private bool state = false;

    private Tween tween;

    private float originValue;
    private float curValue;


    private void Awake()
    {
        if (CanvasGroup) originValue = CanvasGroup.alpha;
        else if (Image) originValue = Image.color.a;
        else if (SpriteRenderer) originValue = SpriteRenderer.color.a;
        else if (Text) originValue = Text.color.a;
        else if (TextMesh) originValue = TextMesh.color.a;
    }

    private void Start()
    {
        if ( startState == StartStateType.In)
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
            state = value;

            tween?.Kill();

            if (activeWhenIn == true && state == true) gameObject.SetActive(true);

            //inactive 状态 直接设置值
            if ( gameObject.activeInHierarchy == false)
            {
                ForceSetState(state);
                return;
            }

            if (state == true)
            {
                tween = DOTween.To(() => curValue, x => SetValue(x), valueIn, timeIn)
                  .SetEase(easeIn)
                  .SetDelay(delayIn)
                  .SetUpdate(ignoreTimeScale)
                  .OnComplete(OnInComplete);
            }
            else
            {
                tween = DOTween.To(() => curValue, x => SetValue(x), valueOut, timeOut)
                  .SetEase(easeOut)
                  .SetDelay(delayOut)
                  .SetUpdate(ignoreTimeScale)
                  .OnComplete(OnOutComplete);
            }
        }
    }

    [FoldoutGroup("Actions"), HorizontalGroup("Actions/Button"), Button("In")]
    public override void In()
    {
        if ( state == false )
        {

            SetValue(valueOut);
            State = true;
        }
    }

    [FoldoutGroup("Actions"), HorizontalGroup("Actions/Button"), Button("Out")]
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

    //强制设置状态
    public void ForceSetState( bool state)
    {
        this.state = state;
        SetValue(state ? valueIn : valueOut);
    }

    public void SetValue ( float value)
    {
        curValue = value;

        if (CanvasGroup)
        {
            CanvasGroup.alpha = multiplier ? (curValue * originValue) : (curValue);
            return;
        }

        else if(Image)
        {
            Color c = image.color;
            c.a = multiplier ? (curValue * originValue) : (curValue);
            Image.color = c;
            return;
        }

        else if(SpriteRenderer)
        {
            Color c = spriteRenderer.color;
            c.a = multiplier ? (curValue * originValue) : (curValue);
            SpriteRenderer.color = c;
            return;
        }

        else if(Text)
        {
            Color c = text.color;
            c.a = multiplier ? (curValue * originValue) : (curValue);
            Text.color = c;
            return;
        }

        else if (TextMesh)
        {
            Color c = textMesh.color;
            c.a = multiplier ? (curValue * originValue) : (curValue);
            TextMesh.color = c;
            return;
        }
    }

    public void Switch()
    {
        if ( state == true)
        {
            Out();
        }
        else
        {
            In();
        }
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

        if (destroyWhenOut == true) GameObject.Destroy(gameObject);
        if (disactiveWhenOut == true) gameObject.SetActive(false);

        onOutComplete.Invoke();
    }
}
