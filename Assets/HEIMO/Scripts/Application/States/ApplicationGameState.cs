using fsm;
using log;

namespace application
{
    public class ApplicationGameState : AbstractApplicationState
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();

            ELog.Log_Debug(ELogType.NONE, nameof(ApplicationGameState));
            FSM.DispatchGameEventToAll(FSMEventType.APPLICATION_GAME_ENTERED);
        }

        public override void OnGameEventReceived(FSMEventType eventType, object data)
        {
            base.OnGameEventReceived(eventType, data);

            switch (eventType)
            {
                case FSMEventType.REQUEST_RESET_GAME:
                    applicationController.RestartSystem();
                    break;
            }
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            FSM.DispatchGameEventToAll(FSMEventType.APPLICATION_GAME_EXIT);
        }
    }
}