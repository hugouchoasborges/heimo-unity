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
    }
}
