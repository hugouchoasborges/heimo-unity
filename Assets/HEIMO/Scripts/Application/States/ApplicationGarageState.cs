using fsm;

namespace application
{
    public class ApplicationGarageState : AbstractApplicationState
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();

            FSM.DispatchGameEventToAll(FSMEventType.APPLICATION_GARAGE_ENTERED);
        }

        public override void OnGameEventReceived(FSMEventType eventType, object data)
        {
            base.OnGameEventReceived(eventType, data);

            switch (eventType)
            {
                case FSMEventType.REQUEST_RESET_GARAGE:
                    applicationController.RestartSystem();
                    break;
            }
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            FSM.DispatchGameEventToAll(FSMEventType.APPLICATION_GARAGE_EXIT);
        }
    }
}