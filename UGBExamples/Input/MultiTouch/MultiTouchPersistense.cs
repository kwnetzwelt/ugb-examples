using UnityEngine;
using UnityGameBase;

namespace Examples.Input.MultiTouch
{
    public class MultiTouchPersistenceExample : UGBExampleBase
    {
        TouchInformation myTouch;
        void OnEnable()
        {
            UGB.Input.TouchStart += OnTouchStart;
        }

        void OnDisable()
        {
            UGB.Input.TouchStart -= OnTouchStart;
        }

        void OnTouchStart(TouchInformation touchInfo)
        {
            if (myTouch != null)
            {
                Debug.Log("Touch rejected, we already track one touch. ");
                return;
            }

            myTouch = touchInfo;
            Debug.Log("Touch started. ");
        }

        void Update()
        {
            if (myTouch != null)
            {
                Debug.Log(myTouch.ScreenPosition);

                if (myTouch.IsDead)
                {
                    Debug.Log("Distance: " + myTouch.distance);
                    myTouch = null;
                    Debug.Log("Touch ended. ");
                }
            }
        }

        #region example details

        public override string Title
        {
            get { return "Touch persistence"; }
        }

        public override string Description
        {
            get
            {
                return "TouchInformation instances are persistent. " +
                    "Once created they will be updated by the system. " +
                    "Hence the possibility to use TouchInformation in the update method. ";
            }
        }

        public override int Index
        {
            get { return 1; }
        }
        #endregion
    }
}