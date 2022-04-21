using UnityEngine;

namespace Presenter
{
    public interface ITextureCreator
    {
        public Texture2D Texture { get; }
        public void Update(int gridSize);
    }
}