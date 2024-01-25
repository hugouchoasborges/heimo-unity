using fsm;

namespace menu
{
    public class MenuGarageState : AbstractMenuState
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();

            menuController.SetGarageUIActive(true);
        }

        public override void OnGameEventReceived(FSMEventType eventType, object data)
        {
            base.OnGameEventReceived(eventType, data);

            switch (eventType)
            {
                case FSMEventType.APPLICATION_GAME_ENTERED:
                    GoToState(FSMStateType.GAME);
                    break;
            }
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            menuController.SetGarageUIActive(false);
        }
    }
}
