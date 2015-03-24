using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityGameBase;


namespace Examples.Input.MultiTouch
{
    public class MultiTouchApi1Example : UGBExampleBase
    {

        void OnEnable()
        {
            UGB.Input.TouchEnd += OnTouchEnd;
        }

        void OnTouchEnd(TouchInformation touchInfo)
        {
            Debug.Log("Duration in Seconds: " + (Time.time - touchInfo.birthTime));
            Debug.Log("Distance: " + touchInfo.distance);
            Debug.Log("Swipe direction: " + touchInfo.GetSwipeDirection());
        }

        void OnDisable()
        {
            UGB.Input.TouchEnd -= OnTouchEnd;
        }

        #region example details
        public override string Title
        {
            get { return "MultiTouch API 1"; }
        }

        public override string Description
        {
            get
            {
                return "TouchInformation has a rich API. For example you can extrapolate. " +
                    "This is useful to simulate a rubber band effect. ";
            }
        }
        
        public override int Index
        {
            get { return 2; }
        }
        #endregion
    }
}