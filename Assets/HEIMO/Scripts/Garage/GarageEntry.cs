using fsm;
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
            bool equipped = PlayerInventorySO.Instance.PlayerEquipped(_carPart);

            //_icon = _carPart.Icon;
            _name.text = gameObject.name = _carPart.Name;
            _price.text =
                bought ? "Owned"
                : string.Format("$ {0}", _carPart.Price);

            bool canAfford = PlayerInventorySO.Instance.Credit >= _carPart.Price;
            _price.color =
                (canAfford || bought)
                ? _colorCanAfford
                : _colorCantAfford;


            _buyButton.gameObject.SetActive(!bought);
            _equipButton.gameObject.SetActive(bought);

            _buyButton.interactable = canAfford;
            _equipButton.interactable = !equipped;
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
            PlayerInventorySO inventory = PlayerInventorySO.Instance;

            if (_carPart is CarPartPaintingSO painting)
                inventory.BuyPainting(painting);

            else if (_carPart is CarPartWheelsSO wheels)
                inventory.BuyWheels(wheels);

            else if (_carPart is CarPartFrontBumperSO frontBumper)
                inventory.BuyFrontBumper(frontBumper);

            else if (_carPart is CarPartRoofAttachmentSO roofAttachment)
                inventory.BuyRoofAttachment(roofAttachment);

            UpdateEntry();
            fsm.FSM.DispatchGameEventToAll(FSMEventType.ON_CREDIT_UPDATED);

        }

        // ========================== Equip ============================


        private void OnEquip()
        {
            // Here goes product decisions
            DoEquip();
        }

        private void DoEquip()
        {
            PlayerInventorySO inventory = PlayerInventorySO.Instance;

            if (_carPart is CarPartPaintingSO painting)
                inventory.SetPaintingInUse(painting);

            else if (_carPart is CarPartWheelsSO wheels)
                inventory.SetWheelsInUse(wheels);

            else if (_carPart is CarPartFrontBumperSO frontBumper)
                inventory.SetFrontBumperInUse(frontBumper);

            else if (_carPart is CarPartRoofAttachmentSO roofAttachment)
                inventory.SetRoofAttachmentInUse(roofAttachment);

            OnPreview();
            UpdateEntry();
            fsm.FSM.DispatchGameEventToAll(FSMEventType.ON_CREDIT_UPDATED);
        }

        // ========================== Preview ============================


        private void OnPreview()
        {
            // Here goes product decisions
            DoPreview();
        }

        private void DoPreview()
        {
            FSMEventType eventType = FSMEventType.NONE;

            if (_carPart is CarPartPaintingSO)
                eventType = FSMEventType.REQUEST_PREVIEW_PAINTING;
            else if (_carPart is CarPartWheelsSO)
                eventType = FSMEventType.REQUEST_PREVIEW_WHEELS;
            else if (_carPart is CarPartFrontBumperSO)
                eventType = FSMEventType.REQUEST_PREVIEW_FRONTBUMPER;
            else if (_carPart is CarPartRoofAttachmentSO)
                eventType = FSMEventType.REQUEST_PREVIEW_ROOFATTACHMENT;

            if (eventType != FSMEventType.NONE)
            {
                FSM.DispatchGameEventToAll(eventType, _carPart);
            }

            fsm.FSM.DispatchGameEventToAll(FSMEventType.ON_CREDIT_UPDATED);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            UpdateEntry();
        }
#endif
    }

}
