using player;
using Sirenix.OdinInspector;
using UnityEngine;

namespace garage
{
    public class CarPartPaintingSO : AbstractCarPartSO<Material>
    {
        public override Material Asset => asset;


#if UNITY_EDITOR
        protected override void ApplyToRunningPlayer(PlayerController playerController)
        {
            playerController.ApplyPainting(Asset);
        }
#endif
    }
}
