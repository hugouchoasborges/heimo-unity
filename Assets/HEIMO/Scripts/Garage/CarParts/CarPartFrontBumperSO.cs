using garage.settings;
using player;
using UnityEngine;

namespace garage
{
    public class CarPartFrontBumperSO : AbstractCarPartSO
    {
        // Assets
        [SerializeField] private Material _material;
        [SerializeField] private Mesh _mesh;
        public Material Material => _material;
        public Mesh Mesh => _mesh;


#if UNITY_EDITOR
        protected override void ApplyToRunningPlayer(PlayerController playerController)
        {
            playerController.ApplyFrontBumper(Material, Mesh);
            PlayerInventorySO.Instance.SetFrontBumperInUse(this);
        }

        public void SetAsset(Material material, Mesh mesh)
        {
            name = material.name;
            _material = material;
            _mesh = mesh;
        }
#endif
    }
}
