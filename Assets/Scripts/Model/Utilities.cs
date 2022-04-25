using UnityEngine;

namespace Model
{
    public static class Utilities
    {
        public static float ScalarProduct(Vector2 a, Vector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        public static float Smoothstep(float t)
        {
            return t * t * t * (t * (t * 6 - 15) + 10);
        }

        public static float Interpolation(float a, float b, float t)
        {
            return a + t * (b - a);
        }

        public static Vector2 GetVectorByPointsNormalized(float x1, float y1, Vector2 point2)
        {
            return GetVectorByPointsNormalized(x1, y1, point2.x, point2.y).normalized;
        }

        public static Vector2 GetVectorByPointsNormalized(float x1, float y1, float x2, float y2)
        {
            return new Vector2(x2 - x1, y2 - y1);
        }

        public static float[,] InitializeTwoDimensionalArrayFloat(int sizeGrid)
        {
            float[,] array = new float[sizeGrid, sizeGrid];
            
            for (int y = 0; y < sizeGrid; y++)
            {
                for (int x = 0; x < sizeGrid; x++)
                {
                    array[x, y] = 0.0f;
                }
            }

            return array;
        }
    }
}