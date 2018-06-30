using UnityEngine;

public enum MarkerType
{
    CASTLE,
    ADDITIONAL,
    SPAWN,
    CANON
}

namespace SupremumStudio
{

    public delegate void MarkerDelegate(Marker mark);
    
    public class Marker: MonoBehaviour
    {

        public static event MarkerDelegate EnableMark;
        public static event MarkerDelegate DisableMark;
            
        public MarkerType TargetType;

        

        private void OnEnable()
        {
           EnableMark(this);    
        }

        private void OnDisable()
        {
            DisableMark(this);
        }
    }
    
    
}