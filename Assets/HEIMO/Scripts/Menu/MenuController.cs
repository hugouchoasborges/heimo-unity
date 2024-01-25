using fsm;
using UnityEngine;

namespace menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _gameUI;
        [SerializeField] private GameObject _garageUI;

        public void SetGameUIActive(bool active)
        {
            _gameUI.SetActive(active);
        }

        public void SetGarageUIActive(bool active)
        {
            _garageUI.SetActive(active);
        }

        public void HideAllUI()
        {
            SetGameUIActive(false);
            SetGarageUIActive(false);
        }

        // ----------------------------------------------------------------------------------
        // ========================== In-Game ============================
        // ----------------------------------------------------------------------------------

        public void ResetGame()
        {
            FSM.DispatchGameEventToAll(FSMEventType.REQUEST_RESET_GAME);
        }

        public void GoToGarage()
        {
            FSM.DispatchGameEventToAll(FSMEventType.REQUEST_GOTO_GARAGE);
        }

        // ----------------------------------------------------------------------------------
        // ========================== In-Garage ============================
        // ----------------------------------------------------------------------------------

        public void ResetGarage()
        {
            FSM.DispatchGameEventToAll(FSMEventType.REQUEST_RESET_GARAGE);
        }

        public void GoToGame()
        {
            FSM.DispatchGameEventToAll(FSMEventType.REQUEST_GOTO_GAME);
        }
    }
}
