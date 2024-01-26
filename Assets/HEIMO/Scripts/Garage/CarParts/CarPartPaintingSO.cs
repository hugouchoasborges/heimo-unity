using garage.settings;
using player;
using UnityEngine;

namespace garage
{
    public class CarPartPaintingSO : AbstractCarPartSO
    {
        [SerializeField] private Material _material;
        public Material Material => _material;

        public void SetAsset(Material material)
        {
            name = material.name;
            _material = material;
            carPartType = CarPartType.Painting;
        }

#if UNITY_EDITOR
        protected override void ApplyToRunningPlayer(PlayerController playerController)
        {
            playerController.ApplyPainting(Material);
            PlayerInventorySO.Instance.SetPaintingInUse(this);
        }
#endif
    }
}
