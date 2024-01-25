using garage;
using garage.settings;

namespace player
{
    public class PlayerPrepareState : AbstractPlayerState
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();

            // Use this to load any runtime settings for the player
            LoadPlayerPreferences();

            GoToState(fsm.FSMStateType.IDLE);
        }

        private void LoadPlayerPreferences()
        {
            PlayerInventorySO playerInventory = PlayerInventorySO.Instance;

            // Skin - painting
            CarPartPaintingSO painting = playerInventory.PaintingInUse;
            if (painting != null)
            {
                playerController.ApplyPainting(painting.Asset);
                playerInventory.SetPaintingInUse(painting);
            }

            // Skin - wheels
            CarPartWheelsSO wheels = playerInventory.WheelInUse;
            if (wheels != null)
            {
                playerController.ApplyWheels(wheels.Asset, wheels.MeshLeft, wheels.MeshRight, wheels.ColliderRadius);
                playerInventory.SetWheelsInUse(wheels);
            }

            // Skin - front bumper
            CarPartFrontBumperSO frontBumper = playerInventory.FrontBumperInUse;
            if (frontBumper != null)
            {
                playerController.ApplyFrontBumper(frontBumper.Asset, frontBumper.Mesh);
                playerInventory.SetFrontBumperInUse(frontBumper);
            }

            // Skin - roof attachment
            CarPartRoofAttachmentSO roofAttachment = playerInventory.RoofAttachmentInUse;
            if (roofAttachment != null)
            {
                playerController.ApplyRoofAttachment(roofAttachment.Asset, roofAttachment.Mesh);
                playerInventory.SetRoofAttachmentInUse(roofAttachment);
            }
        }
    }
}