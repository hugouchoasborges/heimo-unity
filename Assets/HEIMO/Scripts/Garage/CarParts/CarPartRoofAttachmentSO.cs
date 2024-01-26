using garage.settings;
using player;
using UnityEngine;

namespace garage
{
    public class CarPartRoofAttachmentSO : AbstractCarPartSO
    {
        [SerializeField] private Material _material;
        [SerializeField] private Mesh _mesh;

        public Material Material => _material;
        public Mesh Mesh => _mesh;


#if UNITY_EDITOR
        protected override void ApplyToRunningPlayer(PlayerController playerController)
        {
            playerController.ApplyRoofAttachment(Material, Mesh);
            PlayerInventorySO.Instance.SetRoofAttachmentInUse(this);
        }

        public void SetAsset(Material material, Mesh mesh)
        {
            _material = material;
            _mesh = mesh;
            name = Mesh.name;
            carPartType = CarPartType.RoofAttachment;
        }
#endif
    }
}
