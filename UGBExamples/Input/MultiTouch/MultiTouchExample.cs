using UnityEngine;
using System.Collections;
using UnityGameBase;

namespace Examples.Input.MultiTouch
{
    public class MultiTouchExample : UGBExampleBase
    {

        void OnEnable()
        {
            UGB.Input.TouchStart += OnTouchStart;
            UGB.Input.TouchEnd += OnTouchEnd;
            UGB.Input.TouchUpdate += OnTouchUpdate;
        }

        void OnDisable()
        {
            UGB.Input.TouchStart -= OnTouchStart;
            UGB.Input.TouchEnd -= OnTouchEnd;
            UGB.Input.TouchUpdate -= OnTouchUpdate;
        }

        private void OnTouchStart(TouchInformation touchInfo)
        {
            Debug.Log("Touch was started");
        }


        void OnTouchUpdate(TouchInformation touchInfo)
        {
            Debug.Log("Touch updated");
        }


        void OnTouchEnd(TouchInformation touchInfo)
        {
            Debug.Log("Touch ended");
        }

        #region example details
        public override string Title
        {
            get { return "MultiTouch Example"; }
        }

        public override string Description
        {
            get
            {
                return
                    "Touches and clicks are detected through the same API. " +
                    "In this example, you can click/tap then hold and release. " +
                    "Notice the debug output. ";
            }
        }

        public override int Index
        {
            get { return 0; }
        }
        #endregion
    }

}