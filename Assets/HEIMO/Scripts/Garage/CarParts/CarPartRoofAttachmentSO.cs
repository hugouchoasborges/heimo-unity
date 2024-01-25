using garage.settings;
using player;
using UnityEngine;

namespace garage
{
    public class CarPartRoofAttachmentSO : AbstractCarPartSO<Material>
    {
        public override Material Asset => asset;

        // Mesh
        [SerializeField] private Mesh _mesh;
        public Mesh Mesh => _mesh;


#if UNITY_EDITOR
        protected override void ApplyToRunningPlayer(PlayerController playerController)
        {
            playerController.ApplyRoofAttachment(Asset, Mesh);
            PlayerInventorySO.Instance.SetRoofAttachmentInUse(this);
        }

        public void SetAsset(Material material, Mesh mesh)
        {
            SetAsset(mesh.name, material);

            _mesh = mesh;
        }
#endif
    }
}
