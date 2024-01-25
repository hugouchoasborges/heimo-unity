namespace fsm
{
    public enum FSMEventType
    {
		NONE = 0,
		APPLICATION_GAME_ENTERED = 1,
		APPLICATION_GAME_EXIT = 2,
		REQUEST_RESET_GAME = 3,
		REQUEST_RESET_GARAGE = 4,
		REQUEST_GOTO_GAME = 5,
		REQUEST_GOTO_GARAGE = 6,
		APPLICATION_GARAGE_ENTERED = 7,
		APPLICATION_GARAGE_EXIT = 8,
}
}
