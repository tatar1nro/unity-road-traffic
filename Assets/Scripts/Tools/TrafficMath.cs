using System.Collections.Generic;
using UnityEngine;

namespace Bro.Client.Traffic
{
    public static class TrafficMath
    {
        public static Vector3 CenterOfVectors( List<Vector3> vectors )
        {
            var sum = Vector3.zero;
            if( vectors == null || vectors.Count == 0 )
            {
                return sum;
            }

            foreach( var vector in vectors )
            {
                sum += vector;
            }
            return sum / vectors.Count;
        }
    }
}