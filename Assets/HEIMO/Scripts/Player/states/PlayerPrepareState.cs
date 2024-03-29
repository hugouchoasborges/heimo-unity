namespace player
{
    public class PlayerPrepareState : AbstractPlayerState
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();

            // Use this to load any runtime settings for the player
            LoadPlayerPreferences();

            GoToState(fsm.FSMStateType.IDLE);
        }
    }
}