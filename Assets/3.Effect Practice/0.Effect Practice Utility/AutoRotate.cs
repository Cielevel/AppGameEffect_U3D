using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EffectPractice.Utility
{
    public class AutoRotate : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private RotateAxis _axis;
        [SerializeField] private float _rotateSpeed = 3;

        private Vector3 _vec = Vector3.one;

        private void Start()
        {
            _vec = _axis switch
            {
                RotateAxis.X => Vector3.right,
                RotateAxis.Y => Vector3.up,
                RotateAxis.Z => Vector3.forward,
                _ => Vector3.zero,
            };
        }

        private void Update()
        {
            _target.eulerAngles += _vec * _rotateSpeed * Time.deltaTime;
        }

        enum RotateAxis
        {
            X, Y, Z
        }
    }
}