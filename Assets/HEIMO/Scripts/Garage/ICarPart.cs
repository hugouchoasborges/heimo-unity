using UnityEngine;

namespace garage
{
    internal interface ICarPart<TAsset> where TAsset : Object
    {
        string Name { get; }
        string Description { get; }

        int Price { get; }

        TAsset Asset { get; }

        void SetAsset(TAsset asset);
    }
}
