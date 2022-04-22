using System;
using UnityEngine;

namespace Model
{
    public class NoisePerlin : INoise
    {
        private readonly int _sizeGrid;
        private float[,] _octave;
        private readonly IAngularGradients _gradients;

        public NoisePerlin(IAngularGradients gradients, int sizeGrid)
        {
            _sizeGrid = sizeGrid;
            _gradients = gradients;
            InitializationOctave();
        }

        public float[,] GetResultOfCalculations()
        {
            float minimum = Mathf.Infinity, maximum = -Mathf.Infinity;

            for (int y = 0; y < _sizeGrid; y++)
            {
                for (int x = 0; x < _sizeGrid; x++)
                {
                    float value = CalculateCellValue(x, y);
                    _octave[x, y] = value;
                    
                    if (value < minimum)
                        minimum = value;
                    if (value > maximum)
                        maximum = value;
                }
            }

            NormalizationOfOctave(minimum, maximum);
            return _octave;
        }

        private void InitializationOctave()
        {
            _octave = new float[_sizeGrid, _sizeGrid];
            for (int y = 0; y < _sizeGrid; y++)
            {
                for (int x = 0; x < _sizeGrid; x++)
                {
                    _octave[x, y] = 0.0f;
                }
            }
        }

        private float CalculateCellValue(int x, int y)
        {
            Vector2 vLeftTop = Utilities.GetVectorByPointsNormalized(x, y, 0, 0);
            Vector2 vRightTop = Utilities.GetVectorByPointsNormalized(x, y, _sizeGrid, 0);

            Vector2 vLeftBottom = Utilities.GetVectorByPointsNormalized(x, y, 0, _sizeGrid);
            Vector2 vRightBottom = Utilities.GetVectorByPointsNormalized(x, y, _sizeGrid, _sizeGrid);

            float scalarProductLeftTop = Utilities.ScalarProduct(vLeftTop, _gradients.LeftTop);
            float scalarProductRightTop = Utilities.ScalarProduct(vRightTop, _gradients.RightTop);
            float scalarProductLeftBottom = Utilities.ScalarProduct(vLeftBottom, _gradients.LeftBottom);
            float scalarProductRightBottom = Utilities.ScalarProduct(vRightBottom, _gradients.RightBottom);
            
            
            float tX = Utilities.Smoothstep((float)x / _sizeGrid);
            float tY = Utilities.Smoothstep((float)y / _sizeGrid);

            float lerpTopAxisX = Utilities.Interpolation(scalarProductLeftTop, scalarProductRightTop, tX);
            float lerpBottomAxisX = Utilities.Interpolation(scalarProductLeftBottom, scalarProductRightBottom, tX);

            float lerpAxisY = Utilities.Interpolation(lerpTopAxisX, lerpBottomAxisX, tY);
            return lerpAxisY;
        }

        private void NormalizationOfOctave(float minimum, float maximum)
        {
            float difference = (maximum - minimum);
            for (int y = 0; y < _sizeGrid; y++)
            {
                for (int x = 0; x < _sizeGrid; x++)
                {
                    float value = _octave[x, y];
                    float normalized = (value - minimum) / difference;
                     _octave[x, y] = normalized;
                }
            }
        }
    }
}