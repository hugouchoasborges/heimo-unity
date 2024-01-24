using garage.settings;
using log.settings;
using Sirenix.OdinInspector;
using UnityEngine;

namespace garage
{
    public abstract class AbstractCarPartSO<T> : ScriptableObject, ICarPart<T> where T : Object
    {
        [SerializeField] protected string name;
        [SerializeField][TextArea(4, 10)] protected string description;
        [SerializeField][MinValue(0)] protected int price;

        [SerializeField] protected T asset;

        public string Name => name;
        public string Description => description;
        public int Price => price;

        public abstract T Asset { get; }

        public void SetAsset(T asset)
        {
            this.asset = asset;
            this.name = asset.name;
        }

#if UNITY_EDITOR
        [Button("Garage Settings")]
        private void GoToGarageSettings()
        {
            GarageSettingsSO.MenuItem_GarageSettings();
        }
#endif

    }
}
