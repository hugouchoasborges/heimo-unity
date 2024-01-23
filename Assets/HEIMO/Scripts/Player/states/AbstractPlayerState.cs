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
    }
}
