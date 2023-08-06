using UnityEngine;

namespace Bro.Client.Traffic
{
    public static class TrafficConst
    {
        public const float GizmoLineWidth = 0.2f;
        public const float GizmoLineHeight = 0.1f;
        
        public const float GizmoArrowLenght = 1.0f;
        public const float GizmoArrowAngle = 40f;
        
        public const float GizmoAnchorLinkedRadius = 0.3f;
        public const float GizmoAnchorEmptyRadius = 1f;

        public static readonly Color ColorError = new Color(1f, 0f, 0f, 0.25f);
        public static readonly Color ColorSelection = new Color(0f, 0f, 1f, 1f);
        public static readonly Color ColorLine = new Color(0f, 0f, 1f, 1f);
        
        public static readonly Color ColorAnchorLinked = new Color(0f, 1f, 0f, 1f);
        public static readonly Color ColorAnchorEmpty = Color.red;
        
    }
}