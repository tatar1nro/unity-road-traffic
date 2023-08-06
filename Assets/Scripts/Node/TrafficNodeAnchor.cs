using UnityEditor;
using UnityEngine;

namespace Bro.Client.Traffic
{
    public class TrafficNodeAnchor : MonoBehaviour
    {
        [SerializeField] private TrafficAnchorType _anchorType;

        public bool IsIn => _anchorType == TrafficAnchorType.In;
        public bool IsOut => _anchorType == TrafficAnchorType.Out;
        public Vector3 Position => transform.position;
        public bool IsLinked => false;
        
        private void OnDrawGizmos()
        {
            if (IsLinked)
            {
                TrafficGizmo.DrawSphere(Position, TrafficConst.ColorAnchorLinked, TrafficConst.GizmoAnchorLinkedRadius);
            }
            else
            {
                TrafficGizmo.DrawSphere(Position, TrafficConst.ColorAnchorEmpty, TrafficConst.GizmoAnchorEmptyRadius);
            }
        }
        
        
        public void OnMouseUp()
        {
            var parent = transform.parent;
            var node = parent != null ? parent.GetComponent<TrafficNode>() : null;
            
            if (node != null)
            {
                if (transform.hasChanged)
                {
                    transform.hasChanged = false;
                    node.OnAnchorChanged();
                }
            }
            else
            {
                Debug.LogError("traffic: anchor have to be a parent of node");
            }
        }

        public void ValidateRootNode()
        {
            var parent = transform.parent;
            var node = parent != null ? parent.GetComponent<TrafficNode>() : null;
            if (node != null)
            {
                node.Validate();
            }
        }
    }
    
    [CustomEditor(typeof(TrafficNodeAnchor))]
    public class TrafficNodeAnchorEditor : Editor
    {
        private void OnSceneGUI()
        {
            if(Event.current.type == EventType.MouseUp)
            {
                var script = (TrafficNodeAnchor)target;
                script.OnMouseUp();
            }
        }
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var script = (TrafficNodeAnchor)target;
            if (GUILayout.Button("Validate"))
            {
                script.ValidateRootNode();
            }
        }
    }
}