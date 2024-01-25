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

        [ShowInInspector] public const string CONFIG_FILE_PAINTINGS_ROOT = CONFIG_FILE_ROOT + "/paintings";
        [ShowInInspector] public const string CONFIG_FILE_WHEELS_ROOT = CONFIG_FILE_ROOT + "/wheels";
        [ShowInInspector] public const string CONFIG_FILE_FRONTBUMPER_ROOT = CONFIG_FILE_ROOT + "/front_bumpers";
        [ShowInInspector] public const string CONFIG_FILE_ROOFATTACHMENT_ROOT = CONFIG_FILE_ROOT + "/roof_attachment";

        [Header("Car Parts")]
        [SerializeField] private List<CarPartPaintingSO> _paintings = new List<CarPartPaintingSO>();
        [SerializeField] private List<CarPartWheelsSO> _wheels = new List<CarPartWheelsSO>();
        [SerializeField] private List<CarPartFrontBumperSO> _frontBumpers = new List<CarPartFrontBumperSO>();
        [SerializeField] private List<CarPartRoofAttachmentSO> _roofAttachments = new List<CarPartRoofAttachmentSO>();


#if UNITY_EDITOR

        private void OnValidate()
        {
            // Remove invalid entries

            if (_paintings.Count > 0)
                _paintings.RemoveAll(p => p == null);

            if (_wheels.Count > 0)
                _wheels.RemoveAll(w => w == null);
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
            var newCarPart = MenuExtensions.PingOrCreateSO<CarPartPaintingSO>(filePath);

            if (material != null)
                newCarPart.SetAsset(material);

            _paintings.Add(newCarPart);
        }


        [MenuItem("Assets/HEIMO/Create Painting Asset from this", true)]
        private static bool Validate_CreateNewPaintingFromSelection()
        {
            // This method is used to determine if the menu item should be enabled or disabled
            // For example, you can enable it only when a material is selected
            return Selection.objects.Length == 1 && Selection.activeObject is Material;
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

        // ========================== Wheels ============================


        [Button(ButtonSizes.Medium, ButtonStyle.Box)]
        public void CreateNewWheels(string name, Material material, Mesh meshLeft, Mesh meshRight)
        {
            if (string.IsNullOrEmpty(name)) return;

            string filePath = string.Format("{0}/wheel_{1}.asset", CONFIG_FILE_WHEELS_ROOT, name);
            var newCarPart = MenuExtensions.PingOrCreateSO<CarPartWheelsSO>(filePath);

            if (material != null)
                newCarPart.SetAsset(material, meshLeft, meshRight);

            _wheels.Add(newCarPart);
        }


        [MenuItem("Assets/HEIMO/Create Wheels Asset from this", true)]
        private static bool Validate_CreateNewWheelsFromSelection()
        {
            Object[] selectedObjects = Selection.objects;
            return selectedObjects.Length == 3 &&
                   ((selectedObjects[0] is Material && selectedObjects[1] is Mesh && selectedObjects[2] is Mesh));
        }

        [MenuItem("Assets/HEIMO/Create Wheels Asset from this", false)]
        private static void CreateNewWheelsFromSelection()
        {
            Object[] selectedObjects = Selection.objects;

            if (selectedObjects.Length == 3)
            {
                Material material = null;
                Mesh meshLeft = null;
                Mesh meshRight = null;

                // Determine the order of Mesh and Material in the selected objects
                if (selectedObjects[0] is Material && selectedObjects[1] is Mesh && selectedObjects[2] is Mesh)
                {
                    material = selectedObjects[0] as Material;
                    meshLeft = selectedObjects[1] as Mesh;
                    meshRight = selectedObjects[2] as Mesh;
                }

                if (material != null && meshLeft && meshRight != null)
                {
                    // Create wheels using the selected mesh and material
                    Instance.CreateNewWheels(material.name, material, meshLeft, meshRight);
                }
            }
        }

        // ========================== Front Bumper ============================


        [Button(ButtonSizes.Medium, ButtonStyle.Box)]
        public void CreateNewFrontBumper(string name, Material material, Mesh mesh)
        {
            if (string.IsNullOrEmpty(name)) return;

            string filePath = string.Format("{0}/front_bumper_{1}.asset", CONFIG_FILE_FRONTBUMPER_ROOT, name);
            var newCarPart = MenuExtensions.PingOrCreateSO<CarPartFrontBumperSO>(filePath);

            if (material != null)
                newCarPart.SetAsset(material, mesh);

            _frontBumpers.Add(newCarPart);
        }


        [MenuItem("Assets/HEIMO/Create FrontBumper Asset from this", true)]
        private static bool Validate_CreateNewFrontBumperFromSelection()
        {
            Object[] selectedObjects = Selection.objects;
            return selectedObjects.Length == 2 &&
                   ((selectedObjects[0] is Material && selectedObjects[1] is Mesh));
        }

        [MenuItem("Assets/HEIMO/Create FrontBumper Asset from this", false)]
        private static void CreateNewFrontBumperFromSelection()
        {
            Object[] selectedObjects = Selection.objects;

            if (selectedObjects.Length == 2)
            {
                Material material = null;
                Mesh mesh = null;

                // Determine the order of Mesh and Material in the selected objects
                if (selectedObjects[0] is Material && selectedObjects[1] is Mesh)
                {
                    material = selectedObjects[0] as Material;
                    mesh = selectedObjects[1] as Mesh;
                }

                if (material != null && mesh != null)
                {
                    // Create wheels using the selected mesh and material
                    Instance.CreateNewFrontBumper(material.name, material, mesh);
                }
            }
        }

        // ========================== Roof Attachment ============================


        [Button(ButtonSizes.Medium, ButtonStyle.Box)]
        public void CreateNewRoofAttachment(string name, Material material, Mesh mesh)
        {
            if (string.IsNullOrEmpty(name)) return;

            string filePath = string.Format("{0}/roof_attachment_{1}.asset", CONFIG_FILE_ROOFATTACHMENT_ROOT, name);
            var newCarPart = MenuExtensions.PingOrCreateSO<CarPartRoofAttachmentSO>(filePath);

            if (material != null)
                newCarPart.SetAsset(material, mesh);

            _roofAttachments.Add(newCarPart);
        }


        [MenuItem("Assets/HEIMO/Create RoofAttachment Asset from this", true)]
        private static bool Validate_CreateNewRoofAttachmentFromSelection()
        {
            Object[] selectedObjects = Selection.objects;
            return selectedObjects.Length == 2 &&
                   ((selectedObjects[0] is Material && selectedObjects[1] is Mesh));
        }

        [MenuItem("Assets/HEIMO/Create RoofAttachment Asset from this", false)]
        private static void CreateNewRoofAttachmentFromSelection()
        {
            Object[] selectedObjects = Selection.objects;

            if (selectedObjects.Length == 2)
            {
                Material material = null;
                Mesh mesh = null;

                // Determine the order of Mesh and Material in the selected objects
                if (selectedObjects[0] is Material && selectedObjects[1] is Mesh)
                {
                    material = selectedObjects[0] as Material;
                    mesh = selectedObjects[1] as Mesh;
                }

                if (material != null && mesh != null)
                {
                    // Create wheels using the selected mesh and material
                    Instance.CreateNewRoofAttachment(mesh.name, material, mesh);
                }
            }
        }
#endif
    }
}
