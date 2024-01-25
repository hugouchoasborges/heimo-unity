using fsm;
using garage;

namespace player
{
    public class PlayerGarageState : AbstractPlayerState
    {

        public override void OnGameEventReceived(FSMEventType eventType, object data)
        {
            base.OnGameEventReceived(eventType, data);

            switch (eventType)
            {
                case FSMEventType.APPLICATION_GARAGE_EXIT:
                    GoToState(FSMStateType.IDLE);
                    break;

                case FSMEventType.REQUEST_PREVIEW_PAINTING:
                    CarPartPaintingSO painting = data as CarPartPaintingSO;
                    if (painting != null)
                        playerController.ApplyPainting(painting.Material);
                    break;

                case FSMEventType.REQUEST_PREVIEW_WHEELS:
                    CarPartWheelsSO wheels = data as CarPartWheelsSO;
                    if (wheels != null)
                        playerController.ApplyWheels(wheels.Material, wheels.MeshLeft, wheels.MeshRight, wheels.ColliderRadius);
                    break;

                case FSMEventType.REQUEST_PREVIEW_FRONTBUMPER:
                    CarPartFrontBumperSO frontBumper = data as CarPartFrontBumperSO;
                    if (frontBumper != null)
                        playerController.ApplyFrontBumper(frontBumper.Material, frontBumper.Mesh);
                    break;

                case FSMEventType.REQUEST_PREVIEW_ROOFATTACHMENT:
                    CarPartRoofAttachmentSO roofAttachment = data as CarPartRoofAttachmentSO;
                    if (roofAttachment != null)
                        playerController.ApplyRoofAttachment(roofAttachment.Material, roofAttachment.Mesh);
                    break;

            }
        }
    }
}