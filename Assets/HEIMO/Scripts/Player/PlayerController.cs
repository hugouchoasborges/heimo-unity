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

        // Wheel
        [SerializeField] private MeshFilter[] _wheelMeshLeftFilters;
        [SerializeField] private MeshFilter[] _wheelMeshRightFilters;
        [SerializeField] private MeshRenderer[] _wheelMeshRenderers;
        [SerializeField] private WheelCollider[] _wheelColliders;

        // Bumper
        [SerializeField] private MeshFilter _frontBumperMeshFilter;
        [SerializeField] private MeshRenderer _frontBumperMeshRenderer;

        // Roof Attachment
        [SerializeField] private MeshFilter _roofAttachmentMeshFilter;
        [SerializeField] private MeshRenderer _roofAttachmentMeshRenderer;

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

        [Button(ButtonSizes.Medium, ButtonStyle.Box)]
        public void ApplyFrontBumper(Material material, Mesh mesh)
        {
            if (material == null && mesh == null)
            {
                _frontBumperMeshRenderer.gameObject.SetActive(false);
            }
            else
            {
                _frontBumperMeshRenderer.gameObject.SetActive(true);
                _frontBumperMeshRenderer.material = material;
                _frontBumperMeshFilter.mesh = mesh;
            }
        }

        [Button(ButtonSizes.Medium, ButtonStyle.Box)]
        public void ApplyRoofAttachment(Material material, Mesh mesh)
        {
            if (material == null && mesh == null)
            {
                _roofAttachmentMeshRenderer.gameObject.SetActive(false);
            }
            else
            {
                _roofAttachmentMeshRenderer.gameObject.SetActive(true);
                _roofAttachmentMeshRenderer.material = material;
                _roofAttachmentMeshFilter.mesh = mesh;
            }
        }
    }
}
