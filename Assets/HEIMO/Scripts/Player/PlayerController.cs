using external;
using UnityEngine;

namespace player
{
    [RequireComponent(typeof(CarController))]
    public class PlayerController : MonoBehaviour
    {
        private CarController _carController;

        private void Awake()
        {
            _carController = GetComponent<CarController>();
        }

        public void SetCarInputActive(bool active)
        {
            _carController.enabled = active;
        }
    }
}
