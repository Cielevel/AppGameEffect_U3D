using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyUtilities
{
    public class AutoCall : MonoBehaviour
    {
        [SerializeField] private UnityEvent onAwakeEvents;
        [SerializeField] private UnityEvent onStartEvents;

        void Awake()
        {
            onAwakeEvents?.Invoke();
        }

        void Start()
        {
            onStartEvents?.Invoke();
        }
    }
}