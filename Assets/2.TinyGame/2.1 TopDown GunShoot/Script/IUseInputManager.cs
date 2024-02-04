using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    public interface IUseInputManager
    {
        /// <summary>
        /// 在Start中初始化 输入对应的响应函数
        /// </summary>
        void InitialInputControl();
    }
}