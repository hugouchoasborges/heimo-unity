using garage.settings;
using player;
using UnityEngine;

namespace garage
{
    public class CarPartWheelsSO : AbstractCarPartSO
    {
        // Material
        [SerializeField] private Material _material;
        public Material Material => _material;

        [Header("L/R Meshes")]
        [SerializeField] private Mesh _meshLeft;
        [SerializeField] private Mesh _meshRight;

        [Header("Collider Info")]
        [SerializeField][Range(0f, 1f)] private float _colliderRadius = .5f;

        public Mesh MeshLeft => _meshLeft;
        public Mesh MeshRight => _meshRight;
        public float ColliderRadius => _colliderRadius;

        public void SetAsset(Material material, Mesh meshLeft, Mesh meshRight)
        {
            name = material.name;
            _material = material;
            _meshLeft = meshLeft;
            _meshRight = meshRight;
        }

#if UNITY_EDITOR
        protected override void ApplyToRunningPlayer(PlayerController playerController)
        {
            playerController.ApplyWheels(Material, MeshLeft, MeshRight, ColliderRadius);
            PlayerInventorySO.Instance.SetWheelsInUse(this);
        }
#endif
    }
}
