using garage.settings;
using player;
using Sirenix.OdinInspector;
using UnityEngine;

namespace garage
{
    public abstract class AbstractCarPartSO : ScriptableObject, ICarPart
    {
        [SerializeField] protected string name;
        [SerializeField][TextArea(4, 10)] protected string description;
        [SerializeField][MinValue(0)] protected int price;

        public string Name => name;
        public string Description => description;
        public int Price => price;

#if UNITY_EDITOR
        [Button("Garage Settings")]
        private void GoToGarageSettings()
        {
            GarageSettingsSO.MenuItem_GarageSettings();
        }

        [Button(ButtonSizes.Medium, ButtonStyle.Box)]
        public void ApplyToRunningPlayer()
        {
            if (UnityEditor.EditorApplication.isPlaying)
            {
                PlayerController[] playerControllers = Object.FindObjectsOfType<PlayerController>();

                if (playerControllers == null) return;

                // Iterate through the array and do something with each PlayerController
                foreach (PlayerController playerController in playerControllers)
                {
                    ApplyToRunningPlayer(playerController);
                }
            }
        }

        protected virtual void ApplyToRunningPlayer(PlayerController playerController) { }
#endif

    }
}
