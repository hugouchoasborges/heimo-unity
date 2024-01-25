using fsm;

namespace menu
{
    public class MenuGameState : AbstractMenuState
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();

            menuController.SetGameUIActive(true);
        }

        public override void OnGameEventReceived(FSMEventType eventType, object data)
        {
            base.OnGameEventReceived(eventType, data);

            switch (eventType)
            {
                case FSMEventType.APPLICATION_GARAGE_ENTERED:
                    GoToState(FSMStateType.GARAGE);
                    break;
            }
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            menuController.SetGameUIActive(false);
        }
    }
}
