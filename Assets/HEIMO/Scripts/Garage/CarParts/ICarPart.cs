namespace garage
{
    public interface ICarPart
    {
        string Name { get; }
        string Description { get; }

        int Price { get; }
        bool Vendable { get; }
    }
}
