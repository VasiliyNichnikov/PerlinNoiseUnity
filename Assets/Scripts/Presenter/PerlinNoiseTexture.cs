using Model;
using UnityEngine;

namespace Presenter
{
    public class PerlinNoiseTexture : ITextureCreator
    {
        public Texture2D Texture => _noise;

        private Texture2D _noise;

        public PerlinNoiseTexture(int gridSize = 128)
        {
            Update(gridSize);
        }

        public void Update(int gridSize)
        {
            _noise = new Texture2D(gridSize, gridSize);

            var gradients = GetGradients();
            IPerlinNoise perlinNoise = new PerlinNoiseCalculator(gridSize, gradients);

            ChangePixelValues(perlinNoise);
        }
        
        // TODO добавить градиент в view
        private IAngularGradients GetGradients()
        {
            Vector2 leftTop = new Vector2(1, 0);
            Vector2 rightTop = new Vector2(0, -1);
            Vector2 leftBottom = new Vector2(0, 1);
            Vector2 rightBottom = new Vector2(-1, 0);
            IAngularGradients gradients = new SamplingGradients(leftTop, rightTop, leftBottom, rightBottom);
            return gradients;
        }

        private void ChangePixelValues(IPerlinNoise perlinNoise)
        {
            float[,] values = perlinNoise.GetResultOfCalculations();

            for (int y = 0; y < _noise.height; y++)
            {
                for (int x = 0; x < _noise.width; x++)
                {
                    MonoBehaviour.print(values[x, y]);
                    Color color = Color.black;
                    _noise.SetPixel(x, y, color);
                }
            }
        }
    }
}