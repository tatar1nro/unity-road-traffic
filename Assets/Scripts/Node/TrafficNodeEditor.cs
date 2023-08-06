using UnityEditor;
using UnityEngine;

namespace Bro.Client.Traffic
{
    [CustomEditor(typeof(TrafficNode))]
    public class TrafficNodeEditor : Editor
    { 
        private void OnSceneGUI()
        {
            var script = (TrafficNode)target;
            if(Event.current.type == EventType.MouseUp)
            {
                script.Validate();
            }
        }
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var script = (TrafficNode)target;
            if (GUILayout.Button("Validate"))
            {
                script.Validate();
            }
        }
    }
}