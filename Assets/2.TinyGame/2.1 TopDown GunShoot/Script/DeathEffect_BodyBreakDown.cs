using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    /// <summary>
    /// 角色的一种死亡动画，需要预配置rigidbody[]
    /// </summary>
    public class DeathEffect_BodyBreakDown : MonoBehaviour // 测试与调试中-2024/2/4
    {
        [SerializeField] private Rigidbody[] rbs_bodies;
        private Collider[] cols_bodies; // 可能是其他Collider，初始化的方法可被重写

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

        // 身体破碎开-->关闭animator-->开启每个部位的rb-->从breakpoint为每个rb施加力--同时播放一些粒子以及在地上留下一些痕迹
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
}