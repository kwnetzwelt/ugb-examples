using UnityEngine;
using System.Collections;
using UnityGameBase;

namespace Examples.Input.MultiTouch
{
    public class MultiTouchExample : UGBExampleBase
    {

        void OnEnable()
        {
            UGB.Input.TouchStart += Input_TouchStart;
            UGB.Input.TouchEnd += Input_TouchEnd;
            UGB.Input.TouchUpdate += Input_TouchUpdate;
        }

        void OnDisable()
        {
            UGB.Input.TouchStart -= Input_TouchStart;
            UGB.Input.TouchEnd -= Input_TouchEnd;
            UGB.Input.TouchUpdate -= Input_TouchUpdate;
        }

        private void Input_TouchStart(TouchInformation touchInfo)
        {
            Debug.Log("Touch was started");
        }


        void Input_TouchUpdate(TouchInformation touchInfo)
        {
            Debug.Log("Touch updated");
        }


        void Input_TouchEnd(TouchInformation touchInfo)
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