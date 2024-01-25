using garage.settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace garage
{
    public class GarageEntry : MonoBehaviour
    {
        private readonly Color _colorCantAfford = Color.red;
        private readonly Color _colorCanAfford = Color.green;

        [Header("Components")]
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _price;

        [SerializeField] private Button _previewButton;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _equipButton;

        private ICarPart _carPart;

        public void LoadCarPart(ICarPart carPart)
        {
            _carPart = carPart;
            UpdateEntry();
        }

        public void UpdateEntry()
        {
            if (_carPart == null)
            {
                gameObject.SetActive(false);
                return;
            }

            bool bought = PlayerInventorySO.Instance.PlayerHasCarPart(_carPart);

            //_icon = _carPart.Icon;
            _name.text = gameObject.name = _carPart.Name;
            _price.text = string.Format("$ {0}", _carPart.Price);

            bool canAfford = PlayerInventorySO.Instance.Credit >= _carPart.Price;
            _price.color =
                canAfford
                ? _colorCanAfford
                : _colorCantAfford;

            _buyButton.gameObject.SetActive(!bought);
            _equipButton.gameObject.SetActive(bought);

            _buyButton.interactable = canAfford;
            _equipButton.interactable = canAfford;
            //_previewButton.interactable = canAfford;

            gameObject.SetActive(true);
        }



        // ----------------------------------------------------------------------------------
        // ========================== Button Events ============================
        // ----------------------------------------------------------------------------------


        private void OnEnable()
        {
            _buyButton.onClick.AddListener(OnBuy);
            _equipButton.onClick.AddListener(OnEquip);
            _previewButton.onClick.AddListener(OnPreview);
        }

        private void OnDisable()
        {
            _buyButton.onClick.RemoveAllListeners();
            _equipButton.onClick.RemoveAllListeners();
            _previewButton.onClick.RemoveAllListeners();
        }


        // ========================== Buy ============================


        private void OnBuy()
        {
            // Here goes product decisions
            DoBuy();
        }

        private void DoBuy()
        {
            // TODO: Implement
        }

        // ========================== Equip ============================


        private void OnEquip()
        {
            // Here goes product decisions
            DoEquip();
        }

        private void DoEquip()
        {
            // TODO: Implement
        }

        // ========================== Preview ============================


        private void OnPreview()
        {
            // Here goes product decisions
            DoPreview();
        }

        private void DoPreview()
        {
            // TODO: Implement
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            UpdateEntry();
        }
#endif
    }

}
