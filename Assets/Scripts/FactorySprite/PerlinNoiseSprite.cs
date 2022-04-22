using Model;
using UnityEngine;

namespace FactorySprite
{
    public class PerlinNoiseSprite : INoiseSprite
    {
        public Sprite Sprite => Sprite.Create(_noise, new Rect(0.0f, 0.0f, _noise.width, _noise.height), new Vector2(0.5f, 0.5f));

        private Texture2D _noise;
        private int _sizeGrid;

        public PerlinNoiseSprite(int sizeGrid)
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