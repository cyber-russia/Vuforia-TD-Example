using System;
using System.Collections.Generic;
using UnityEngine;

namespace CyberRussia.ARTDImageTarget
{ 
    public class PathBuilder: MonoBehaviour
    {
        public List<Marker> pathMarkers;
        public List<Vector3> path;
        public LineRenderer _LineRenderer;
        
        void Awake()
        {
            Marker.OnAddMarkerToPath += AddMarker;
            Marker.OnDisableMarker += RemoveMarker;             
        }

        private void Update()
        {
            DrawPath();
        }

        void AddMarker(Marker _marker)
        {
            switch (_marker.type)
            {
                case TypeMarker.CASTLE:
                    pathMarkers.Add(_marker);
                    break;
                case TypeMarker.SPAWN:
                    pathMarkers.Insert(0, _marker);
                    break;
                case TypeMarker.TOWER:
                    break;
                case TypeMarker.PATHPOINT:
                    if (pathMarkers.Count != 0 && pathMarkers[pathMarkers.Count-1].type == TypeMarker.CASTLE)
                    {
                        if (pathMarkers.Count == 1)
                        {
                            pathMarkers.Insert(0, _marker);
                        }
                        else
                            pathMarkers.Insert(pathMarkers.Count - 1, _marker);                            
                    }
                    else
                        pathMarkers.Add(_marker);                        
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void RemoveMarker(Marker marker)
        {
            if (pathMarkers.Contains(marker)) pathMarkers.Remove(marker);
        }

        void DrawPath()
        {
            path.Clear();
            foreach (var item in pathMarkers)
            {
                path.Add(item.transform.position);
            }

            if (_LineRenderer != null)
            {
                _LineRenderer.positionCount = path.Count;
                _LineRenderer.SetPositions(path.ToArray());
            }

        }

    }
}