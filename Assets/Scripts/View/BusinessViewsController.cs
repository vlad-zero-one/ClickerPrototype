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

        private Dictionary<Business, BusinessView> businessViews = new();

        private Dictionary<string, BusinessView> newBusinessViews = new();

        private float ContentSpacing => contentVerticalLayoutGroup.spacing;

        public void Init(EcsWorld ecsWorld)
        {
            this.ecsWorld = ecsWorld;

            prefabYSize = businessViewPrefab.GetComponent<RectTransform>().sizeDelta.y;
        }

        public void Instantiate(Business business)
        {
            var view = Instantiate(businessViewPrefab, scrollViewContent);

            scrollViewContent.sizeDelta += new Vector2(0, prefabYSize + ContentSpacing);

            view.Init(business);
            businessViews.Add(business, view);

            newBusinessViews.Add(business.Id, view);

            view.OnLevelUpClick += OnLevelUpViewClick;

            view.OnBuyUpgradeClick += OnBuyUpgradeClick;

        }

        public void UpdateView(Business business)
        {
            if (businessViews.ContainsKey(business))
            {
                businessViews[business].UpdateView();
            }
        }

        public void UpdateView(string businessId)
        {
            if (newBusinessViews.TryGetValue(businessId, out var businessView))
            {
                businessView.UpdateView();
            }
        }

        public void SetProgress(Business business, float progress)
        {
            if (businessViews.ContainsKey(business))
            {
                businessViews[business].SetProgress(progress);
            }
        }

        private void OnLevelUpViewClick(Business business)
        {
            ecsWorld.NewEntity().Get<LevelUpClickComponent>().Business = business;
        }

        private void OnBuyUpgradeClick(Business business, BusinessUpgrade businessUpgrade)
        {
            ref var comp = ref ecsWorld.NewEntity().Get<BuyUpgradeClickComponent>();
            comp.Business = business;
            comp.BusinessUpgrade = businessUpgrade;
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
