using fsm;

namespace menu
{
    public class MenuIdleState : AbstractMenuState
    {
        public override void OnGameEventReceived(FSMEventType eventType, object data)
        {
            base.OnGameEventReceived(eventType, data);

            switch (eventType)
            {
                case FSMEventType.APPLICATION_GAME_ENTERED:
                    GoToState(FSMStateType.GAME);
                    break;

                case FSMEventType.APPLICATION_GARAGE_ENTERED:
                    GoToState(FSMStateType.GARAGE);
                    break;
            }
        }
    }
}
