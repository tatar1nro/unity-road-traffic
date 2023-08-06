using System.Collections.Generic;
using UnityEngine;

namespace Bro.Client.Traffic
{
    [ExecuteInEditMode]
    public class TrafficNode : TrafficNodeView
    {
        public int Lines = 1;

        private readonly List<TrafficNodeAnchor> _anchorsIn = new List<TrafficNodeAnchor>();
        private readonly List<TrafficNodeAnchor> _anchorsOut = new List<TrafficNodeAnchor>();
        
        private bool _isFlagOk;

        private void OnDrawGizmos()
        {
            if (IsSelected())
            {
                DrawSelection();
            }

            if (!_isFlagOk)
            {
                DrawError();
                return;
            }

            foreach (var nodeIn in _anchorsIn)
            {
                foreach (var nodeOut in _anchorsOut)
                {
                    TrafficGizmo.DrawLine(nodeIn.Position, nodeOut.Position, TrafficConst.ColorLine);   
                }
            }

        
        }

        public override void Validate()
        {
            _isFlagOk = true;
            
            _anchorsIn.Clear();
            _anchorsOut.Clear();

            transform.AlignRootPivot();
            
            var childCount = transform.childCount;
            
            if (childCount < 2)
            {
                _isFlagOk = false;
                Debug.LogError("have to be >= 2 nodes inside");
                return;
            }
            
            for (var i = 0; i < childCount; ++ i)
            {
                var child = transform.GetChild(i);
                var anchor = child.gameObject.GetComponent<TrafficNodeAnchor>();
                if (anchor != null)
                {
                    if (anchor.IsIn)
                    {
                        _anchorsIn.Add(anchor);
                    }
                    else if (anchor.IsOut)
                    {
                        _anchorsOut.Add(anchor);
                    }
                }
            }
            
            if (_anchorsIn.Count < 1 || _anchorsOut.Count < 1)
            {
                _isFlagOk = false;
                Debug.LogError("have to be at least one in and one out");
                return;
            }
            
        }



    }
    
}