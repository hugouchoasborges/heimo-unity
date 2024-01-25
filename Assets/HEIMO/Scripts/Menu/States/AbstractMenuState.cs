using fsm;

namespace menu
{
    public class AbstractMenuState : IFSMState
    {
        protected MenuController menuController;

        private void Awake()
        {
            menuController = GetComponent<MenuController>();
        }
    }
}
