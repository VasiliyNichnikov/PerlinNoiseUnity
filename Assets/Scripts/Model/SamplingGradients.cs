using UnityEngine;

namespace Model
{
    public class SamplingGradients : IAngularGradients
    {
        public Vector2 LeftTop { get; }
        public Vector2 RightTop { get; }
        public Vector2 LeftBottom { get; }
        public Vector2 RightBottom { get; }
        
        public SamplingGradients(Vector2 leftTop, Vector2 rightTop, Vector2 leftBottom, Vector2 rightBottom)
        {
            LeftTop = leftTop;
            RightTop = rightTop;
            LeftBottom = leftBottom;
            RightBottom = rightBottom;
        }
    }
}