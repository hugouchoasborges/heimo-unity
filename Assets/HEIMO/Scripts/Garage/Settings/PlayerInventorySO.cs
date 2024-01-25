using Sirenix.OdinInspector;
using UnityEngine;
using System.IO;
using tools;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace garage.settings
{
    class PlayerInventorySO : ScriptableObject
    {
        public static PlayerInventorySO Instance => MenuExtensions.LoadSOFromResources<PlayerInventorySO>(Path.Combine(CONFIG_FILE_ROOT, CONFIG_FILE_PATH));

        [Header("Constants")]
        public const string CONFIG_FILE_ROOT = "Assets/HEIMO/Resources/Settings/GARAGE";
        public const string CONFIG_FILE_PATH = "player_inventory.asset";

        [Header("Basic Info")]
        [SerializeField][Range(0, 100000)] private int _credit = 0;

        public int Credit
        {
            get => _credit;
            set => _credit = value;
        }


        [Header("Inventory - Car Parts")]
        [SerializeField] private List<CarPartPaintingSO> _paintings = new List<CarPartPaintingSO>();
        [SerializeField] private List<CarPartWheelsSO> _wheels = new List<CarPartWheelsSO>();
        [SerializeField] private List<CarPartFrontBumperSO> _frontBumpers = new List<CarPartFrontBumperSO>();
        [SerializeField] private List<CarPartRoofAttachmentSO> _roofAttachments = new List<CarPartRoofAttachmentSO>();

        public List<CarPartPaintingSO> Paintings => _paintings;
        public List<CarPartWheelsSO> Wheels => _wheels;
        public List<CarPartFrontBumperSO> FrontBumpers => _frontBumpers;
        public List<CarPartRoofAttachmentSO> RoofAttachments => _roofAttachments;

        [Header("Currently In Use")]
        [SerializeField] private CarPartPaintingSO _paintingInUse = null;
        [SerializeField] private CarPartWheelsSO _wheelInUse = null;
        [SerializeField] private CarPartFrontBumperSO _frontBumperInUse = null;
        [SerializeField] private CarPartRoofAttachmentSO _roofAttachmentInUse = null;

        public CarPartPaintingSO PaintingInUse => _paintingInUse;
        public CarPartWheelsSO WheelInUse => _wheelInUse;
        public CarPartFrontBumperSO FrontBumperInUse => _frontBumperInUse;
        public CarPartRoofAttachmentSO RoofAttachmentInUse => _roofAttachmentInUse;

        public void SetPaintingInUse(CarPartPaintingSO painting)
        {
            _paintingInUse = painting;
        }

        public void SetWheelsInUse(CarPartWheelsSO wheels)
        {
            _wheelInUse = wheels;
        }

        public void SetFrontBumperInUse(CarPartFrontBumperSO frontBumper)
        {
            _frontBumperInUse = frontBumper;
        }

        public void SetRoofAttachmentInUse(CarPartRoofAttachmentSO roofAttachment)
        {
            _roofAttachmentInUse = roofAttachment;
        }


        // ========================== Ownership CHeck ============================

        public bool PlayerHasCarPart(ICarPart carPart)
        {
            if (_paintings.Any(part => (part as ICarPart) == carPart)) return true;
            if (_wheels.Any(part => (part as ICarPart) == carPart)) return true;
            if (_frontBumpers.Any(part => (part as ICarPart) == carPart)) return true;
            if (_roofAttachments.Any(part => (part as ICarPart) == carPart)) return true;

            return false;
        }

#if UNITY_EDITOR

        private void OnValidate()
        {
            // Remove invalid entries
            if (_paintings.Count > 0)
                _paintings.RemoveAll(p => p == null);

            if (_wheels.Count > 0)
                _wheels.RemoveAll(w => w == null);

            if (_frontBumpers.Count > 0)
                _frontBumpers.RemoveAll(f => f == null);

            if (_roofAttachments.Count > 0)
                _roofAttachments.RemoveAll(r => r == null);
        }

        // ----------------------------------------------------------------------------------
        // ========================== Menu Items ============================
        // ----------------------------------------------------------------------------------

        [MenuItem("HEIMO/GARAGE/Player Inventory")]
        public static void MenuItem_PlayerInventory()
        {
            MenuExtensions.PingOrCreateSO<PlayerInventorySO>(Path.Combine(CONFIG_FILE_ROOT, CONFIG_FILE_PATH));
        }

        [Button("Garage Settings")]
        public void OpenGarageSettings()
        {
            GarageSettingsSO.MenuItem_GarageSettings();
        }

#endif
    }
}
