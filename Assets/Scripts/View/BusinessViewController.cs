using System;
using System.Collections;
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

        private float prefabYSize;

        public List<BusinessView> BusinessViews { get; private set; } = new();

        private float contentSpacing => contentVerticalLayoutGroup.spacing;

        public void Init()
        {
            prefabYSize = businessViewPrefab.GetComponent<RectTransform>().sizeDelta.y;
        }

        public void Instantiate(Business business = null)
        {
            var view = Instantiate(businessViewPrefab, scrollViewContent);

            scrollViewContent.sizeDelta += new Vector2(0, prefabYSize + contentSpacing);

            view.Init(business);
        }
    }
}
