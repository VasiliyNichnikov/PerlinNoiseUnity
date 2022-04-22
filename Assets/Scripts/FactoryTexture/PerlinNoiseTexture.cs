using Model;
using UnityEngine;

namespace FactoryTexture
{
    public class PerlinNoiseTexture : INoiseTexture
    {
        public Texture2D Texture => _noise;

        private Texture2D _noise;
        private int _sizeGrid;

        public PerlinNoiseTexture(int sizeGrid)
        {
            _sizeGrid = sizeGrid;
            _noise = new Texture2D(sizeGrid, sizeGrid);
        }
        
        public void Update(Vector2 leftTop,
            Vector2 rightTop,
            Vector2 leftBottom, 
            Vector2 rightBottom)
        {
            IAngularGradients gradients = new SamplingGradients(leftTop, rightTop, leftBottom, rightBottom);
            
            INoise perlinNoise = new NoisePerlin(gradients, _sizeGrid);
            ChangePixelValues(perlinNoise);
        }

        private void ChangePixelValues(INoise noise)
        {
            float[,] values = noise.GetResultOfCalculations();

            for (int y = 0; y < _noise.height; y++)
            {
                for (int x = 0; x < _noise.width; x++)
                {
                    float value = values[x, y];
                    Color color = new Color(value, value, value);
                    _noise.SetPixel(x, y, color);
                }
            }

            _noise.Apply();
        }
    }
}