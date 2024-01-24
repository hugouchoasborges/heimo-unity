using fsm;

namespace player
{
    public class PlayerGameState : AbstractPlayerState
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();

            // Enable player's movement
            playerController.SetCarInputActive(true);
        }

        public override void OnGameEventReceived(FSMEventType eventType, object data)
        {
            base.OnGameEventReceived(eventType, data);

            switch (eventType)
            {
                case FSMEventType.APPLICATION_GAME_EXIT:
                    GoToState(FSMStateType.IDLE);
                    break;
            }
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            // Disable player's movement
            playerController.SetCarInputActive(false);
        }
    }
}