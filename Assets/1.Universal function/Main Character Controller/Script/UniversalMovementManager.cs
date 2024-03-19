using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInputSystem;

namespace UniversalFunction
{
    /// <summary>
    /// 通用移动控制器父类，提供一系列通用方法或接口
    /// </summary>
    public class UniversalMovementManager : MonoBehaviour
    {
        [SerializeField] private CharacterInputSystem _inputSystem;

        protected virtual void Awake()
        {

        }

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {

        }
    }
}