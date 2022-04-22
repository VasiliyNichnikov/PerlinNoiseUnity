using Model;
using UnityEngine;

namespace FactoryTexture
{
    public interface ICreatorNoise
    {
        public INoiseTexture CreateAngularGradients(int sizeGrid);
    }
}