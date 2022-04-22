using System;
using UnityEditor;
using UnityEngine;

namespace View.Editor
{
    [CustomEditor(typeof(NoiseDraughtsman))]
    public class NoiseDraughtsmanEditor : UnityEditor.Editor
    {
        private IView _target;
        
        private void OnEnable()
        {
            _target = target as IView;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Draw"))
            {
                _target.Draw();
            }
        }
    }
}