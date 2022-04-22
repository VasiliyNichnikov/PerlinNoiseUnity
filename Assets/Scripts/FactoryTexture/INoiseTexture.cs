using Model;
using UnityEngine;

namespace FactoryTexture
{
    public interface INoiseTexture
    {
        public Texture2D Texture { get; }
        public void Update(
            Vector2 leftTop, 
            Vector2 rightTop,
            Vector2 leftBottom, 
            Vector2 rightBottom);
    }
}