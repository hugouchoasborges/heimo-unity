using fsm;

namespace garage
{
    public class GarageIdleState : AbstractGarageState
    {
        public override void OnGameEventReceived(FSMEventType eventType, object data)
        {
            base.OnGameEventReceived(eventType, data);

            switch (eventType)
            {
                case FSMEventType.ON_CREDIT_UPDATED:
                    garageController.UpdateCredit();
                    break;
            }
        }
    }
}
