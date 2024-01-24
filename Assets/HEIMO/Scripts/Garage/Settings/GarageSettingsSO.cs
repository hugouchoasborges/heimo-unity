using Sirenix.OdinInspector;
using UnityEngine;
using System.IO;
using tools;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace garage.settings
{
    class GarageSettingsSO : ScriptableObject
    {
        public static GarageSettingsSO Instance => MenuExtensions.LoadSOFromResources<GarageSettingsSO>(Path.Combine(CONFIG_FILE_ROOT, CONFIG_FILE_PATH));

        [Header("Constants")]
        [ShowInInspector] public const string CONFIG_FILE_ROOT = "Assets/HEIMO/Resources/Settings/GARAGE";

        [ShowInInspector] public const string CONFIG_FILE_PATH = "garage_settings.asset";

        [ShowInInspector] public const string CONFIG_FILE_PAINTINGS_ROOT = "Assets/HEIMO/Resources/Settings/GARAGE/paintings";

        [Header("Car Parts")]
        [SerializeField] private List<CartPartPaintingSO> _paintings = new List<CartPartPaintingSO>();


#if UNITY_EDITOR

        private void OnValidate()
        {
            // Remove invalid entries

            if (_paintings.Count > 0)
                _paintings.RemoveAll(p => p == null);
        }

        // ----------------------------------------------------------------------------------
        // ========================== Menu Items ============================
        // ----------------------------------------------------------------------------------

        [MenuItem("HEIMO/GARAGE/Settings")]
        public static void MenuItem_GarageSettings()
        {
            MenuExtensions.PingOrCreateSO<GarageSettingsSO>(Path.Combine(CONFIG_FILE_ROOT, CONFIG_FILE_PATH));
        }


        // ========================== Painting ============================


        [Button(ButtonSizes.Medium, ButtonStyle.Box)]
        public void CreateNewPainting(string name, Material material)
        {
            if (string.IsNullOrEmpty(name)) return;

            string filePath = string.Format("{0}/painting_{1}.asset", CONFIG_FILE_PAINTINGS_ROOT, name);
            var newCarPart = MenuExtensions.PingOrCreateSO<CartPartPaintingSO>(filePath);

            if (material != null)
                newCarPart.SetAsset(material);

            _paintings.Add(newCarPart);
        }


        [MenuItem("Assets/HEIMO/Create Painting Asset from this", true)]
        private static bool Validate_CreateNewPaintingFromSelection()
        {
            // This method is used to determine if the menu item should be enabled or disabled
            // For example, you can enable it only when a material is selected
            return Selection.activeObject is Material;
        }

        [MenuItem("Assets/HEIMO/Create Painting Asset from this", false)]
        private static void CreateNewPaintingFromSelection()
        {
            // Get the currently selected object in the Project window
            Object selectedObject = Selection.activeObject;

            if (selectedObject != null && selectedObject is Material)
            {
                Material material = selectedObject as Material;
                Instance.CreateNewPainting(material.name, material);
            }
        }
#endif
    }
}
