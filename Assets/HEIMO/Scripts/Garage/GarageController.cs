using garage.settings;
using log;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

namespace garage
{
    public class GarageController : MonoBehaviour
    {
        [Header("Player Info")]
        [SerializeField] private TMP_InputField _creditInput;
        public int Credit => _creditInput == null ? 0 : int.Parse(_creditInput.text);

        [Header("Entries")]
        [SerializeField] private Transform _containerRootTransform;
        private List<GarageEntry> _entries = new List<GarageEntry>();

        private void Start()
        {
            LoadAllEntries();
        }

        private void OnEnable()
        {
            _creditInput.onEndEdit.AddListener(ValidateCreditInput);
            UpdateCredit();
        }

        private void OnDisable()
        {
            _creditInput.onEndEdit.RemoveAllListeners();
        }


        // ========================== Entries ============================

        private void UnloadAllEntries()
        {
            for (int i = _entries.Count - 1; i >= 0; i--)
            {
                GameObject gObj = _entries[i].gameObject;
                _entries.RemoveAt(i);
                GameObject.Destroy(gObj);
            }
        }

        private void LoadAllEntries()
        {
            UnloadAllEntries();
            _entries.Clear();

            List<ICarPart> allCarParts = GarageSettingsSO.Instance.GetAllCarParts();
            foreach (var carPart in allCarParts)
            {
                if (carPart.Price <= 0)
                {
                    ELog.LogWarning(ELogType.NONE, "Car Part removed from store. {0}, price={1}", carPart.Name, carPart.Price);
                    continue;
                }

                _entries.Add(CreateEntry(carPart));
            }
        }

        private GarageEntry CreateEntry(ICarPart carPart)
        {
            GarageEntry newEntry = GameObject.Instantiate(GarageSettingsSO.Instance.GarageEntryPrefab, _containerRootTransform).GetComponent<GarageEntry>();
            newEntry.LoadCarPart(carPart);
            return newEntry;
        }


        // ========================== Credit ============================

        private void ValidateCreditInput(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                // Parse the input string as a float
                if (!int.TryParse(input, out int value))
                {
                    // If parsing fails, set the input field text to 0
                    value = 0;
                }

                // If the value is negative, set it to 0
                if (value < 0)
                    value = 0;

                PlayerInventorySO.Instance.Credit = value;
                UpdateCredit();
            }
        }

        public void UpdateCredit()
        {
            _creditInput.text = System.Math.Max(0, PlayerInventorySO.Instance.Credit).ToString();
            UpdateEntries();
        }

        private void UpdateEntries()
        {
            foreach (var entry in _entries)
            {
                entry.UpdateEntry();
            }
        }
    }
}
