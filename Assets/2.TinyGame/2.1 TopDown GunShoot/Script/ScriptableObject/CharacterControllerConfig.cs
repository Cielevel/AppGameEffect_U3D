using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    [CreateAssetMenu(fileName = "new Config", menuName = "Data/Config/CharacterCongrollerData")]
    public class CharacterControllerConfig : ScriptableObject
    {
        [Range(0, 180)] public float slopLimit = 45;
        [Min(0)] public float stepOffset = 0.3f;
        [Space]
        [Min(0.0001f)] public float skinWidth = 0.08f;
        [Space]
        [Min(0)] public float minMoveDistance = 0.001f;
        [Space]
        public Vector3 center = Vector3.zero;
        [Min(0)] public float radius = 0.5f;
        [Min(0)] public float height = 2;

        public void ConfigurationInject(CharacterController characterController)
        {
            characterController.slopeLimit = slopLimit;
            characterController.stepOffset = stepOffset;
            characterController.skinWidth = skinWidth;
            characterController.minMoveDistance = minMoveDistance;
            characterController.center = center;
            characterController.radius = radius;
            characterController.height = height;
        }
    }
}