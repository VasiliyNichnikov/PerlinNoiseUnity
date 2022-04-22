namespace FactorySprite
{
    public class PerlinNoiseCreator : ICreatorNoise
    {
        public INoiseSprite CreateAngularGradients(int sizeGrid)
        {
            return new PerlinNoiseSprite(sizeGrid);
        }
    }
}