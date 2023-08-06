using UnityEngine;

namespace Bro.Client.Traffic
{
    public abstract class TrafficNodeView : MonoBehaviour
    {
        public abstract void Validate();
        
        public void OnAnchorChanged()
        {
            Validate();
        }
        
        private void OnValidate()
        {
            Validate();
        }

        private void OnEnable()
        {
            Validate();
        }
        
        protected void DrawError()
        {
            TrafficGizmo.DrawBounds(transform, TrafficConst.ColorError);
        }

        protected void DrawSelection()
        {
            TrafficGizmo.DrawWiredBounds(transform, TrafficConst.ColorSelection);
        }

        protected bool IsSelected()
        {
            if (transform.IsSelected())
            {
                return true;
            }
            var count = transform.childCount;
            for (var i = 0; i < count; ++i)
            {
                if (transform.GetChild(i).IsSelected())
                {
                    return true;
                }
            }
            return false;
        }
    }
}