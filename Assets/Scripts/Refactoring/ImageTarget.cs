using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Refactoring
{
    
    public delegate void DelegateImageTarget(ImageTarget target);
    /// <summary>
    /// Класс эмитирует ImageTarget Vuforia
    /// </summary>
    public class ImageTarget : MonoBehaviour
    {
        public static DelegateImageTarget RegistrImageTarget;
        
        void Awake()
        {
//            print(this.name +" - - -" + (RegistrImageTarget==null));
            
            if (RegistrImageTarget != null)
            {
                RegistrImageTarget(this);
            }  
        }
    }
}