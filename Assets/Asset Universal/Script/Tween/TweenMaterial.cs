using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

using Sirenix.OdinInspector;
using DG.Tweening;
using TMPro;

public class TweenMaterial : Tweenable
{
    [FoldoutGroup("Params")] public Material valueIn;
    [FoldoutGroup("Params")] public Material valueOut;

    [FoldoutGroup("Params")] public StartStateType startState = StartStateType.None;

    private Renderer Renderer
    {
        get
        {
            if (renderer == null) renderer = GetComponent<MeshRenderer>();
            return renderer;
        }
    }
    private new Renderer renderer;

    private Image Image
    {
        get
        {
            if (image  == null) image = GetComponent<Image>();
            return image;
        }
    }
    private Image image;

    private TextMeshProUGUI TextUGUI
    {
        get
        {
            if (textUGUI == null) textUGUI = GetComponent<TextMeshProUGUI>();
            return textUGUI;
        }
    }
    private TextMeshProUGUI textUGUI;

    private bool state = false;

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

    private void SetValue ( Material mat)
    {
        if (Renderer)
        {
            Renderer.material = mat;
        }
        if ( Image )
        {
            Image.material = mat;
        }
        if (TextUGUI)
        {
            TextUGUI.fontSharedMaterial = mat;
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
            if ( state == value) return;
            state = value;

            if (state == true)
            {
                SetValue(valueIn);
            }
            else
            {
                SetValue(valueOut);
            }
        }
    }



    [FoldoutGroup("Actions"), HorizontalGroup("Actions/Buttons"), Button("In")]
    public override void In()
    {
        if ( state == false )
        {
            State = true;
        }
    }

    [FoldoutGroup("Actions"), HorizontalGroup("Actions/Buttons"), Button("Out")]
    public override void Out()
    {

        if ( state == true )
        {
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
        Renderer.material = state ? valueIn : valueOut;
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
}
