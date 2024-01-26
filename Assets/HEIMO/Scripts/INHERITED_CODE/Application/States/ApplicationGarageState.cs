using fsm;
using scenes;

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
                case FSMEventType.REQUEST_GOTO_GAME:
                    SceneHelper.UnloadSceneAsync(SceneType.GARAGE);
                    SceneHelper.LoadSceneAsync(SceneType.GAME, mode: UnityEngine.SceneManagement.LoadSceneMode.Additive, setAsActive: true, callback: () => GoToState(FSMStateType.GAME));
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