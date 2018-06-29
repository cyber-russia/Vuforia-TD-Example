using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SupremumStudio
{
    public class PathBuilder : MonoBehaviour
    {

        List<Marker> marks = new List<Marker>();
        [Space] public LineRenderer LineRenderer;

        public List<Vector3> Path = new List<Vector3>();

        private void Awake()
        {
            Marker.EnableMark += AddMarks;
            Marker.DisableMark += RemoveMark;
        }

        void AddMarks(Marker mark)
        {

            switch (mark.TargetType)
            {
                case MarkerType.CASTLE:
                    marks.Insert(marks.Count, mark);
                    break;
                case MarkerType.ADDITIONAL:
                    if (marks.Count == 0)
                    {
                        marks.Add(mark);
                    }
                    else
                    {
                        marks.Insert(1, mark);
                    }

                    break;
                case MarkerType.SPAWN:
                    marks.Insert(0, mark);
                    break;
                case MarkerType.CANON:

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void RemoveMark(Marker mark)
        {
            marks.Remove(mark);
        }

        private void Update()
        {
            DrawLine();
        }

        void DrawLine()
        {
            Path.Clear();
            LineRenderer.positionCount = marks.Count;
            for (int i = 0; i < LineRenderer.positionCount; i++)
            {
                LineRenderer.SetPosition(i, marks[i].transform.position);
                Path.Add(marks[i].transform.position);
            }

        }
    }
}