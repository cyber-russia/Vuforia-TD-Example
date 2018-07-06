using UnityEngine;

namespace Refactoring
{
    public delegate void DelegateTargetContent(TargetContent content);

    /// <summary>
    /// Класс отвечающий за объекты внутри ImageTarget
    /// </summary>
    public class TargetContent : MonoBehaviour
    {
        public static DelegateTargetContent ContentOn;
        public static DelegateTargetContent ContentOff;

        public EnumMareker TYPES;

        private void OnEnable()
        {
//            print(this.name +" - - -" + (ContentOn==null));

            if (ContentOn != null) //TODO: Залушки можно поставить при желании
            {
                ContentOn(this);
            }
        }

        private void OnDisable()
        {
            if (ContentOff != null)
            {
                ContentOff(this); //TODO: Залушки можно поставить при желании
            }
        }
    }
}