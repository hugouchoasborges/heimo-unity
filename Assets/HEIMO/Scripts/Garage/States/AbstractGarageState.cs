using fsm;
using UnityEngine;

namespace garage
{
    [RequireComponent(typeof(GarageController))]
    public class AbstractGarageState : IFSMState
    {
        protected GarageController garageController;

        private void Awake()
        {
            if (garageController == null)
            {
                garageController = GetComponent<GarageController>();
            }
        }

    }
}
