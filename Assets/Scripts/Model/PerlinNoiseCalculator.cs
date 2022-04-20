using UnityEngine;

namespace Model
{
    public class PerlinNoiseCalculator: IPerlinNoise
    {
        private int _gridSize;
        private float[,] _octave;
        private IAngularGradients _gradients;
        
        public PerlinNoiseCalculator(int gridSize, IAngularGradients gradiends)
        {
            _gridSize = gridSize;
            _gradients = gradiends;
            InitializationOctave();
        }
        
        public float[,] GetResultOfCalculations()
        {
            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    _octave[x, y] = CalculateCellValue(x, y);
                }
            }

            return _octave;
        }

        private void InitializationOctave()
        {
            _octave = new float[_gridSize, _gridSize];
            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    _octave[x, y] = 0.0f;
                }
            }
        }

        private float CalculateCellValue(int x, int y)
        {
            Vector2 vLeftTop = Utilities.GetVectorByPointsNormalized(x, y, _gradients.LeftTop);
            Vector2 vRightTop = Utilities.GetVectorByPointsNormalized(x, y, _gradients.RightTop);
            
            Vector2 vLeftBottom = Utilities.GetVectorByPointsNormalized(x, y, _gradients.LeftBottom);
            Vector2 vRightBottom = Utilities.GetVectorByPointsNormalized(x, y, _gradients.RightBottom);

            float scalarProductLeftTop = Utilities.ScalarProduct(vLeftTop, _gradients.LeftTop);
            float scalarProductRightTop = Utilities.ScalarProduct(vRightTop, _gradients.RightTop);
            float scalarProductLeftBottom = Utilities.ScalarProduct(vLeftBottom, _gradients.LeftBottom);
            float scalarProductRightBottom = Utilities.ScalarProduct(vRightBottom, _gradients.RightBottom);
            
            float t = Utilities.Smoothstep(0.5f);

            float lerpTopAxisX = Utilities.Interpolation(scalarProductLeftTop, scalarProductRightTop, t);
            float lerpBottomAxisX = Utilities.Interpolation(scalarProductLeftBottom, scalarProductRightBottom, t);

            float lerpAxisY = Utilities.Interpolation(lerpTopAxisX, lerpBottomAxisX, t);
            return lerpAxisY;
        }
    }
}
