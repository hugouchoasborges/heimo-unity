using System;

namespace garage
{
    public interface ICarPart
    {
        string Name { get; }
        string Description { get; }

        int Price { get; }
        bool Default { get; }

        CarPartType CarPartType { get; }
        string CarPartTypeStr => Enum.GetName(typeof(CarPartType), CarPartType);
    }

    public enum CarPartType
    {
        Painting = 0,
        Wheel = 1,
        FrontBumper = 2,
        RoofAttachment = 3,
    }
}
