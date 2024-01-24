using fsm;
using UnityEngine;

namespace player
{
    [RequireComponent(typeof(PlayerController))]
    public class AbstractPlayerState : IFSMState
    {
        protected PlayerController playerController;

        private void Awake()
        {
            if (playerController == null)
            {
                playerController = GetComponent<PlayerController>();
            }
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
    }
}
