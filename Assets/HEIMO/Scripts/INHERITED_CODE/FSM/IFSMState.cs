using System;
using System.Collections.Generic;

namespace fsm
{
    public abstract class IFSMState : UnityEngine.MonoBehaviour
    {
        public bool IsActive => gameObject != null && gameObject.activeInHierarchy;

        // ----------------------------------------------------------------------------------
        // ========================== Infra - Actions ============================
        // ----------------------------------------------------------------------------------

        private Action<IFSMState> _actionGoToState;
        private Action<FSMStateType> _actionGoToStateByName;

        public bool AllowAllEvents { get; protected set; }
        public List<FSMEventType> AllowedEventTypes { get; protected set; }
        public List<FSMEventType> IgnoredEventTypes { get; protected set; }

        public bool IsEventAllowed(FSMEventType eventType)
        {
            if (AllowAllEvents)
                return !(IgnoredEventTypes.Contains(eventType));

            if (AllowedEventTypes.Contains(eventType)) return true;

            return false;
        }

        public void RegisterActions(Action<IFSMState> goToState, Action<FSMStateType> goToStateByName)
        {
            _actionGoToState = goToState;
            _actionGoToStateByName = goToStateByName;
        }

        public void RegisterAllowedAllEvents(bool allowAllEvents)
        {
            AllowAllEvents = allowAllEvents;
        }

        public void RegisterAllowedEvents(List<FSMEventType> allowedEvents)
        {
            AllowedEventTypes = new List<FSMEventType>(allowedEvents);
        }

        public void RegisterIgnoredEvents(List<FSMEventType> ignoredEvents)
        {
            IgnoredEventTypes = new List<FSMEventType>(ignoredEvents);
        }


        // ----------------------------------------------------------------------------------
        // ========================== State Transition ============================
        // ----------------------------------------------------------------------------------

        protected void GoToState(FSMStateType stateType) => _actionGoToStateByName.Invoke(stateType);
        protected void GoToState(IFSMState newState) => _actionGoToState.Invoke(newState);


        // ----------------------------------------------------------------------------------
        // ========================== State Callbacks ============================
        // ----------------------------------------------------------------------------------

        public virtual void OnStateEnter() { }
        public virtual void OnStateUpdate() { }
        public virtual void OnStateFixedUpdate() { }
        public virtual void OnStateExit() { }


        // ----------------------------------------------------------------------------------
        // ========================== State Events ============================
        // ----------------------------------------------------------------------------------

        public virtual void OnGameEventReceived(FSMEventType eventType, object data) { }
    }
}