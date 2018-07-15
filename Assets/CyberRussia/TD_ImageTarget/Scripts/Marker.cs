using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace CyberRussia.ARTDImageTarget
{
    public enum TypeMarker
    {
        CASTLE,
        SPAWN,
        TOWER,
        PATHPOINT
    }

    public delegate void DelegatMarker(Marker marker);
    
    public class Marker : MonoBehaviour
    {
        public TypeMarker type;

        public static event DelegatMarker OnEnableMarker; 
        public static event DelegatMarker OnDisableMarker; 
        public static event DelegatMarker OnAddMarkerToPath;
        
        private void OnEnable()
        {   
            if (OnEnableMarker != null) OnEnableMarker(this);
            if (OnAddMarkerToPath != null && type != TypeMarker.TOWER)
            {
                OnAddMarkerToPath(this);
            }
        }


        private void OnDisable()
        {
            if(OnDisableMarker != null) OnDisableMarker(this);
        }
    }
    
}