using Game.Components;
using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class BusinessViewsController : MonoBehaviour
    {
        [SerializeField] private BusinessView businessViewPrefab;
        [SerializeField] private RectTransform scrollViewContent;
        [SerializeField] private VerticalLayoutGroup contentVerticalLayoutGroup;

        private EcsWorld ecsWorld;

        private float prefabYSize;

        private Dictionary<string, BusinessView> businessViews = new();

        private float ContentSpacing => contentVerticalLayoutGroup.spacing;

        public void Init(EcsWorld ecsWorld)
        {
            this.ecsWorld = ecsWorld;

            prefabYSize = businessViewPrefab.GetComponent<RectTransform>().sizeDelta.y;
        }


        public void Instantiate(ref BusinessComponent business)
        {
            var view = Instantiate(businessViewPrefab, scrollViewContent);

            scrollViewContent.sizeDelta += new Vector2(0, prefabYSize + ContentSpacing);

            view.Init(ref business);

            businessViews.Add(business.Id, view);

            view.OnLevelUpClick += OnLevelUpViewClick;
            view.OnBuyUpgradeClick += OnBuyUpgradeClick;
        }

        public void UpdateView(ref BusinessComponent business)
        {
            if (businessViews.TryGetValue(business.Id, out var businessView))
            {
                businessView.UpdateView(ref business);
            }
        }

        public void SetProgress(string businessId, float progress)
        {
            if (businessViews.TryGetValue(businessId, out var businessView))
            {
                businessView.SetProgress(progress);
            }
        }

        private void OnLevelUpViewClick(string businessId)
        {
            ecsWorld.NewEntity().Get<LevelUpClickComponent>().BusinessId = businessId;
        }

        private void OnBuyUpgradeClick(string businessId, string businessUpgradeId)
        {
            ref var comp = ref ecsWorld.NewEntity().Get<BuyUpgradeClickComponent>();
            comp.BusinessId = businessId;
            comp.BusinessUpgradeId = businessUpgradeId;
        }

        private void OnDestroy()
        {
            foreach (var view in businessViews.Values)
            {
                view.OnLevelUpClick -= OnLevelUpViewClick;
                view.OnBuyUpgradeClick -= OnBuyUpgradeClick;
            }
        }
    }
}
