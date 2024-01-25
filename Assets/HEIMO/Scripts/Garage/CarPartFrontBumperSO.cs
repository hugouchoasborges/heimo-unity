using player;
using UnityEngine;

namespace garage
{
    public class CarPartFrontBumperSO : AbstractCarPartSO<Material>
    {
        public override Material Asset => asset;

        // Mesh
        [SerializeField] private Mesh _mesh;
        public Mesh Mesh => _mesh;


#if UNITY_EDITOR
        protected override void ApplyToRunningPlayer(PlayerController playerController)
        {
            playerController.ApplyFrontBumper(Asset, Mesh);
        }

        public void SetAsset(Material material, Mesh mesh)
        {
            SetAsset(material);

            _mesh = mesh;
        }
#endif
    }
}
