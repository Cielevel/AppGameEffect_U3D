using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Effect.SpriteShape
{
    public class SpriteShapeEffect : MonoBehaviour
    {
        [SerializeField] private SpriteShapeController _spriteShapeController;
        [SerializeField] private Spline _spline;
        [SerializeField] private List<Transform> _points;

        private void Start()
        {
            _spriteShapeController = GetComponent<SpriteShapeController>();
            _spline = _spriteShapeController.spline;
            Debug.Log(_spline.GetPointCount());
        }

        private void Update()
        {
        }
    }
}
