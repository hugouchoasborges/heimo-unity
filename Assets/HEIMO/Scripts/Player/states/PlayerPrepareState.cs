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
            GarageSettingsSO garageSettings = GarageSettingsSO.Instance;

            // Skin - painting
            CarPartPaintingSO painting = garageSettings.GetPaintingInUse();
            if (painting != null)
            {
                playerController.ApplyPainting(painting.Asset);
                garageSettings.MarkPaintingAsInUse(painting);
            }

            // Skin - wheels
            CarPartWheelsSO wheels = garageSettings.GetWheelsInUse();
            if (wheels != null)
            {
                playerController.ApplyWheels(wheels.Asset, wheels.MeshLeft, wheels.MeshRight, wheels.ColliderRadius);
                garageSettings.MarkWheelsAsInUse(wheels);
            }

            // Skin - front bumper
            CarPartFrontBumperSO frontBumper = garageSettings.GetFrontBumperInUse();
            if (frontBumper != null)
            {
                playerController.ApplyFrontBumper(frontBumper.Asset, frontBumper.Mesh);
                garageSettings.MarkFrontBumperAsInUse(frontBumper);
            }

            // Skin - roof attachment
            CarPartRoofAttachmentSO roofAttachment = garageSettings.GetRoofAttachmentInUse();
            if (roofAttachment != null)
            {
                playerController.ApplyRoofAttachment(roofAttachment.Asset, roofAttachment.Mesh);
                garageSettings.MarkRoofAttachmentAsInUse(roofAttachment);
            }
        }
    }
}