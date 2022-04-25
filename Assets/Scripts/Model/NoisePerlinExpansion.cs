using UnityEngine;

namespace Model
{
    public class NoisePerlinExpansion: INoise
    {
        private readonly int _sizeMap;
        private float[,] _map;
        private readonly Vector2[,] _gradients;
        private readonly int _sizeGrid;


        public NoisePerlinExpansion(Vector2[,] gradients, int sizeMap, int sizeGrid)
        {
            _sizeMap = sizeMap;
            _sizeGrid = sizeGrid;
            _gradients = gradients;
            _map = Utilities.InitializeTwoDimensionalArrayFloat(sizeMap);
            // Добавить проверку, что в данную карту влезает выделенное кол-во блоков
            // Добавить проверку, что размер карты и сетки не меньше 1
        }
        
        public float[,] GetResultOfCalculations()
        {
            throw new System.NotImplementedException();
        }


        // private Vector2Int GetLocalPositionPointInGrid(int x, int y)
        // {
        //     
        // }

        private Vector2Int GetPositionLeftUpGradientInGrid(int x, int y)
        {
            float divisionX = x / _sizeGrid;
            float divisionY = y / _sizeGrid;

            int positionX = Mathf.FloorToInt(divisionX);
            int positionY = Mathf.FloorToInt(divisionY);

            if (x % _sizeGrid == 0 && x != 0)
                positionX -= 1;
            if (y % _sizeGrid == 0 && y != 0)
                positionY -= 1;

            return new Vector2Int(positionX, positionY);
        }
    }
}