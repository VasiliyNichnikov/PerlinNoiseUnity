namespace FactoryTexture
{
    public class PerlinNoiseCreator : ICreatorNoise
    {
        public INoiseTexture CreateAngularGradients(int sizeGrid)
        {
            return new PerlinNoiseTexture(sizeGrid);
        }
    }
}