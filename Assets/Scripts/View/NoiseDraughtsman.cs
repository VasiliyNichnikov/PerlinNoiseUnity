using FactoryTexture;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class NoiseDraughtsman : MonoBehaviour
    {
        [SerializeField, Range(64, 512)] private int _sizeGrid;

        [Space(10), Header("Gradients")] [SerializeField]
        private Vector2 _leftTop;

        [SerializeField] private Vector2 _rightTop;
        [SerializeField] private Vector2 _leftBottom;
        [SerializeField] private Vector2 _rightBottom;

        private Image _renderer;

        private void Start()
        {
            _renderer = GetComponent<Image>();
            Draw();
        }
        

        private void Draw()
        {
            ICreatorNoise creator = new PerlinNoiseCreator();
            INoiseTexture noise = creator.CreateAngularGradients(_sizeGrid);
            noise.Update(_leftTop, _rightTop, _leftBottom, _rightBottom);
            _renderer.material.mainTexture = noise.Texture;
        }
    }
}