using fsm;
using garage.settings;
using garage;
using UnityEngine;

namespace player
{
    [RequireComponent(typeof(PlayerController))]
    public class AbstractPlayerState : IFSMState
    {
        protected PlayerController playerController;

        private void Awake()
        {
            if (playerController == null)
            {
                playerController = GetComponent<PlayerController>();
            }
        }

        public override void OnGameEventReceived(FSMEventType eventType, object data)
        {
            base.OnGameEventReceived(eventType, data);

            switch (eventType)
            {
                case FSMEventType.APPLICATION_GAME_ENTERED:
                    GoToState(FSMStateType.GAME);
                    break;

                case FSMEventType.REQUEST_RESET_GARAGE:
                    LoadPlayerPreferences();
                    break;
            }
        }

        protected void LoadPlayerPreferences()
        {
            PlayerInventorySO playerInventory = PlayerInventorySO.Instance;

            // Skin - painting
            CarPartPaintingSO painting = playerInventory.PaintingInUse;
            if (painting != null)
            {
                playerController.ApplyPainting(painting.Material);
                playerInventory.SetPaintingInUse(painting);
            }

            // Skin - wheels
            CarPartWheelsSO wheels = playerInventory.WheelInUse;
            if (wheels != null)
            {
                playerController.ApplyWheels(wheels.Material, wheels.MeshLeft, wheels.MeshRight, wheels.ColliderRadius);
                playerInventory.SetWheelsInUse(wheels);
            }

            // Skin - front bumper
            CarPartFrontBumperSO frontBumper = playerInventory.FrontBumperInUse;
            if (frontBumper != null)
            {
                playerController.ApplyFrontBumper(frontBumper.Material, frontBumper.Mesh);
                playerInventory.SetFrontBumperInUse(frontBumper);
            }

            // Skin - roof attachment
            CarPartRoofAttachmentSO roofAttachment = playerInventory.RoofAttachmentInUse;
            if (roofAttachment != null)
            {
                playerController.ApplyRoofAttachment(roofAttachment.Material, roofAttachment.Mesh);
                playerInventory.SetRoofAttachmentInUse(roofAttachment);
            }
        }
    }
}
