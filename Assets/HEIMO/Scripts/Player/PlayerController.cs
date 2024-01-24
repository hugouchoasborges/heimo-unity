using external;
using Sirenix.OdinInspector;
using UnityEngine;

namespace player
{
    [RequireComponent(typeof(CarController))]
    public class PlayerController : MonoBehaviour
    {
        private CarController _carController;

        [Header("Car Parts")]
        [SerializeField] private MeshRenderer _bodyMesh;

        // Wheel Rear Right
        [SerializeField] private MeshFilter[] _wheelMeshLeftFilters;
        [SerializeField] private MeshFilter[] _wheelMeshRightFilters;
        [SerializeField] private MeshRenderer[] _wheelMeshRenderers;
        [SerializeField] private WheelCollider[] _wheelColliders;

        private void Awake()
        {
            _carController = GetComponent<CarController>();
        }

        public void SetCarInputActive(bool active)
        {
            _carController.enabled = active;
        }


        // ----------------------------------------------------------------------------------
        // ========================== Apply Parts ============================
        // ----------------------------------------------------------------------------------

        [Button(ButtonSizes.Medium, ButtonStyle.Box)]
        public void ApplyPainting(Material paintingMaterial)
        {
            _bodyMesh.material = paintingMaterial;
        }

        [Button(ButtonSizes.Medium, ButtonStyle.Box)]
        public void ApplyWheels(Material material, Mesh meshLeft, Mesh meshRight, float colliderRadius)
        {
            foreach (var meshFilter in _wheelMeshLeftFilters)
                meshFilter.mesh = meshLeft;

            foreach (var meshFilter in _wheelMeshRightFilters)
                meshFilter.mesh = meshRight;

            foreach (var meshRenderer in _wheelMeshRenderers)
                meshRenderer.material = material;

            foreach (var wheelCollider in _wheelColliders)
                wheelCollider.radius = colliderRadius;
        }
    }
}
