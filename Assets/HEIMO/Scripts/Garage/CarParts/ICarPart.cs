using UnityEngine;

namespace garage
{
    public interface ICarPart
    {
        string Name { get; }
        string Description { get; }

        int Price { get; }
    }
}
