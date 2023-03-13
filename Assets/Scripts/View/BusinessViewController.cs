using Game.Components;
using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class BusinessViewController : MonoBehaviour
    {
        [SerializeField] private BusinessView businessViewPrefab;
        [SerializeField] private RectTransform scrollViewContent;
        [SerializeField] private VerticalLayoutGroup contentVerticalLayoutGroup;

        private EcsWorld ecsWorld;

        private float prefabYSize;

        private Dictionary<Business, BusinessView> businessViews = new();

        private float contentSpacing => contentVerticalLayoutGroup.spacing;

        public void Init(EcsWorld ecsWorld)
        {
            this.ecsWorld = ecsWorld;

            prefabYSize = businessViewPrefab.GetComponent<RectTransform>().sizeDelta.y;
        }

        public void Instantiate(Business business)
        {
            var view = Instantiate(businessViewPrefab, scrollViewContent);

            scrollViewContent.sizeDelta += new Vector2(0, prefabYSize + contentSpacing);

            view.Init(business);
            businessViews.Add(business, view);

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

        public void SetProgress(Business business, float progress)
        {
            if (businessViews.ContainsKey(business))
            {
                businessViews[business].SetProgress(progress);
            }
        }

        private void OnLevelUpViewClick(Business business)
        {
            var entity = ecsWorld.NewEntity();

            ref var comp = ref entity.Get<LevelUpClickComponent>();
            comp.Business = business;
        }

        private void OnBuyUpgradeClick(Business business, BusinessUpgrade businessUpgrade)
        {
            var entity = ecsWorld.NewEntity();

            ref var comp = ref entity.Get<BuyUpgradeClickComponent>();
            comp.Business = business;
            comp.BusinessUpgrade = businessUpgrade;
        }

        private void OnDestroy()
        {
            foreach (var view in businessViews.Values)
            {
                view.OnLevelUpClick -= OnLevelUpViewClick;
            }
        }
    }
}
