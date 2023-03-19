using Game.Components;
using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class BusinessInspector : IEcsComponentInspector
    {
        public Type GetFieldType()
        {
            return typeof(BusinessComponent);
        }

        public void OnGUI(string label, object value, EcsWorld world, ref EcsEntity entityId)
        {
            var component = (BusinessComponent)value;

            EditorGUILayout.LabelField(label, EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            EditorGUILayout.LabelField("Id", component.Id);
            EditorGUILayout.LabelField("Name", component.Name);
            EditorGUILayout.LabelField("Level", component.Level.ToString());
            EditorGUILayout.LabelField("Income", component.Income.ToString());
            EditorGUILayout.LabelField("IncomeTime", component.IncomeTime.ToString());
            EditorGUILayout.LabelField("LevelUpPrice", component.LevelUpPrice.ToString());

            var style = new GUIStyle();
            style.fontStyle = FontStyle.Bold;
            EditorGUILayout.LabelField("Upgrades", style);

            foreach(var upgrade in component.Upgrades)
            {
                EditorGUILayout.LabelField("Upgrade", upgrade.ToString());
                EditorGUILayout.LabelField("Upgrade", upgrade.ToString());
            }

            EditorGUI.indentLevel--;
        }
    }
}