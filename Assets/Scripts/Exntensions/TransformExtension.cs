using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Bro.Client.Traffic
{
    public static class TransformExtension
    {
        public static void AlignRootPivot(this Transform transform)
        {
            var count = transform.childCount;
            var positions = new List<Vector3>();
            for (var i = 0; i < count; i++)
            {
                positions.Add(transform.GetChild(i).position);
            }

            var center = TrafficMath.CenterOfVectors(positions);
            var delta = center - transform.position;

            transform.position = center;
            
            for (var i = 0; i < count; i++)
            {
                transform.GetChild(i).position -= delta;
            }
        }

        public static Bounds GetBounds(this Transform transform, int maxEnclosure = 10)
        {
            var bounds = new Bounds(transform.position, new Vector3(1f,TrafficConst.GizmoLineHeight,1f));
            var enclosure = 0;
            EncapsulateBounds(transform, ref bounds, enclosure, maxEnclosure);
            return bounds;
        }

        private static void EncapsulateBounds(Transform transform, ref Bounds bounds, int enclosure, int maxEnclosure)
        {
            enclosure += 1;

            if (enclosure >= maxEnclosure)
            {
                return;
            }
            
            var count = transform.childCount;
            for (var i = 0; i < count; i++)
            {
                var child = transform.GetChild(i);
                bounds.Encapsulate(child.position);
                EncapsulateBounds(child, ref bounds, enclosure, maxEnclosure);
            }
        }

        public static bool IsSelected(this Transform transform)
        {
            return Selection.Contains(transform.gameObject);
        }
    }
}