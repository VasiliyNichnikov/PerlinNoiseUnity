using UnityEngine;

namespace FactorySprite
{
    public interface INoiseSprite
    {
        public Sprite Sprite { get; }
        public void Update(
            Vector2 leftTop, 
            Vector2 rightTop,
            Vector2 leftBottom, 
            Vector2 rightBottom);
    }
}