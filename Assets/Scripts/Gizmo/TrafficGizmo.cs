using System.Collections.Generic;
using UnityEngine;

namespace Bro.Client.Traffic
{
    public static class TrafficGizmo
    {
        public static void DrawSphere(Vector3 position, Color color, float radius)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(position, radius);
        }
        
        public static void DrawLine(Vector3 from, Vector3 to, Color color)
        {
            var center = TrafficMath.CenterOfVectors(new List<Vector3>(){from, to});
            var distance = Vector3.Distance(from, to);
            var direction = to - center;
            var angle = Vector3.SignedAngle(Vector3.left, direction, Vector3.up);
            var rotation = Quaternion.Euler(0, angle, 0);

            Gizmos.color = color;

            Gizmos.matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
            Gizmos.DrawCube(Vector3.zero, new Vector3(distance,TrafficConst.GizmoLineHeight,TrafficConst.GizmoLineWidth));

            var arrowRightRotation = Quaternion.Euler(0, 180 + TrafficConst.GizmoArrowAngle, 0);
            var arrowLeftRotation = Quaternion.Euler(0, 180 - TrafficConst.GizmoArrowAngle, 0);
    
            var right = Quaternion.LookRotation(direction) * arrowRightRotation * new Vector3(0,0,1);
            var left = Quaternion.LookRotation(direction) * arrowLeftRotation * new Vector3(0,0,1);
				        
            Gizmos.matrix = Matrix4x4.TRS(center + right * TrafficConst.GizmoArrowLenght * 0.5f, rotation * arrowRightRotation, Vector3.one);
            Gizmos.DrawCube(Vector3.zero, new Vector3(TrafficConst.GizmoArrowLenght,TrafficConst.GizmoLineHeight,TrafficConst.GizmoLineWidth));
            
            Gizmos.matrix = Matrix4x4.TRS(center + left * TrafficConst.GizmoArrowLenght * 0.5f, rotation * arrowLeftRotation, Vector3.one);
            Gizmos.DrawCube(Vector3.zero, new Vector3(TrafficConst.GizmoArrowLenght,TrafficConst.GizmoLineHeight,TrafficConst.GizmoLineWidth));
            
            Gizmos.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one);
        }

        public static void DrawBounds(Transform transform, Color color)
        {
            var bounds = transform.GetBounds();
            Gizmos.color = color;
            Gizmos.DrawCube(bounds.center, bounds.size);
        } 
        
        public static void DrawWiredBounds(Transform transform, Color color)
        {
            var bounds = transform.GetBounds();
            Gizmos.color = color;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
    }
}