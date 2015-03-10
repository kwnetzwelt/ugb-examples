using UnityEngine;
using System.Collections;
using UnityGameBase;

public class MultiTouchExample : UGBExampleBase {

    TouchInformation touch;

	void Start () {
        UGB.Input.TouchStart += Input_TouchStart;
	}

    private void Input_TouchStart(TouchInformation touchInfo)
    {
        Debug.Log("Touch was started");
        touch = touchInfo;
        
    }

    void Update()
    {
        if (touch != null)
        {
            Debug.Log("Touch active");

            if (touch.IsDead)
            {
                Debug.Log("Touch died");
                touch = null;
            }
        }
    }

    public override string Title
    {
        get { return "MultiTouch Example"; }
    }

    public override string Description
    {
        get { return 
            "Touches and clicks are detected through the same API. " +
            "In this example, you can click/tap then hold and release. " +
            "Notice the debug output. " +
            "TouchInformation instances are persistent. " + 
            "Once created they will be updated by the system. " +
            "Hence the possibility to use TouchInformation in the update method. " +
            "\n\n" +
            "TouchInformation has a rich API. For example you can extrapolate. " + 
            "This is useful to simulate a rubber band effect. "; 
        }
    }
}
