using System;
using FactorySprite;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class NoiseDraughtsman : MonoBehaviour, IView
    {
        public Vector2 LeftTop => _leftTop;
        public Vector2 RightTop => _rightTop;
        public Vector2 LeftBottom => _leftBottom;
        public Vector2 RightBottom => _rightBottom;
        
        [SerializeField, Range(64, 512), Space(10)] private int _sizeGrid;

        [Header("Gradients (Range from 0 to 1 on the axes)")] [SerializeField]
        private Vector2 _leftTop;
        [SerializeField] private Vector2 _rightTop;
        [SerializeField] private Vector2 _leftBottom;
        [SerializeField] private Vector2 _rightBottom;

        private Image _renderer;
        

        private void Start()
        {
            Draw();
        }

        public void Draw()
        {
            _renderer = GetComponent<Image>();
            
            ICreatorNoise creator = new PerlinNoiseCreator();
            INoiseSprite noise = creator.CreateAngularGradients(_sizeGrid);
            _renderer.sprite = noise.Sprite;
            noise.Update(_leftTop, _rightTop, _leftBottom, _rightBottom);
        }
    }
}