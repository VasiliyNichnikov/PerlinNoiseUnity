using UnityEngine;

namespace Model
{
    public interface IAngularGradients
    {
        public Vector2 LeftTop { get; }
        public Vector2 RightTop { get; }
        public Vector2 LeftBottom { get; }
        public Vector2 RightBottom { get; } 
    }
}