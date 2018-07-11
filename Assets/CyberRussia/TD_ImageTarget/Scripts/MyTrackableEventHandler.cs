using UnityEngine;
using Vuforia;

namespace CyberRussia.ARTDImageTarget
{
    public class MyTrackableEventHandler: DefaultTrackableEventHandler
    {
        protected override void OnTrackingFound()
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        protected override void OnTrackingLost()
        {
            transform.GetChild(0).gameObject.SetActive(false);            
        }
    }
}