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
            return typeof(NewBusinessComponent);
        }

        public void OnGUI(string label, object value, EcsWorld world, ref EcsEntity entityId)
        {
            var component = (NewBusinessComponent)value;

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
            EditorGUILayout.LabelField("FirstUpgrade", component.FirstUpgrade.ToString());
            EditorGUILayout.LabelField("SecondUpgrade", component.SecondUpgrade.ToString());

            EditorGUI.indentLevel--;
        }
    }
}