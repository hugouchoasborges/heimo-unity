namespace menu
{
    public class MenuPrepareState : AbstractMenuState
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();

            menuController.HideAllUI();
            GoToState(fsm.FSMStateType.IDLE);
        }
    }
}
