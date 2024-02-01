using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBreakDown : MonoBehaviour
{
    [SerializeField] private Rigidbody[] rbs_bodies;
    private Collider[] cols_bodies; // ����������Collider����ʼ���ķ����ɱ���д

    [SerializeField] private Transform breakPoint;

    [SerializeField] private Animator animator;

    [SerializeField] private float force = 1;

    private void Start()
    {
        InitialColliders();
    }

    protected virtual void InitialColliders()
    {
        cols_bodies = new Collider[rbs_bodies.Length];
        for (int i = 0; i < rbs_bodies.Length; i++)
        {
            cols_bodies[i] = rbs_bodies[i].GetComponent<Collider>();
            cols_bodies[i].enabled = false;
        }
    }

    // �������鿪-->�ر�animator-->����ÿ����λ��rb-->��breakpointΪÿ��rbʩ����--ͬʱ����һЩ�����Լ��ڵ�������һЩ�ۼ�
    [Button]
    private void BreakDown()
    {
        animator.enabled = false;

        for (int i = 0; i < rbs_bodies.Length; i++)
        {
            cols_bodies[i].enabled = true;
            rbs_bodies[i].isKinematic = false;
            rbs_bodies[i].useGravity = true;
            rbs_bodies[i].AddForce(rbs_bodies[i].transform.position - breakPoint.position * force, ForceMode.Impulse);
        }
    }
}
