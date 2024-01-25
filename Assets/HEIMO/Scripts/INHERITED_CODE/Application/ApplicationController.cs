using scenes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace application
{
    public class ApplicationController : MonoBehaviour
    {
        [Header("Scenes")]
        [SerializeField]
        private SceneType _mainMenuScene;

        [SerializeField]
        private SceneType _gameScene;

        [SerializeField]
        private SceneType _initializationScene;

        public void LoadMainMenu()
        {
            SceneHelper.LoadSceneAsync(_mainMenuScene, LoadSceneMode.Additive);
        }

        public void LoadGame()
        {
            SceneHelper.LoadSceneAsync(_gameScene, LoadSceneMode.Additive);
        }

        private void LoadInitializationScene()
        {
            SceneHelper.LoadSceneAsync(_initializationScene);
        }

        public void RestartSystem()
        {
            UnloadAdditionalScenes();
            LoadInitializationScene();
        }

        private void UnloadAdditionalScenes()
        {
            if (SceneHelper.IsSceneLoaded(_mainMenuScene))
                SceneHelper.UnloadSceneAsync(_mainMenuScene);

            if (SceneHelper.IsSceneLoaded(_gameScene))
                SceneHelper.UnloadSceneAsync(_gameScene);
        }

        // ========================== Editor Hacked Initialization ============================

#if UNITY_EDITOR
        // "Hacked Initialization (Editor Only)"
        public static fsm.FSMStateType HackedStartupState
        {
            get => (fsm.FSMStateType)Enum.Parse(typeof(fsm.FSMStateType), PlayerPrefs.GetInt(nameof(HackedStartupState)).ToString());
            set => PlayerPrefs.SetInt(nameof(HackedStartupState), (int)value);
        }
#endif
    }
}