using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class UGBExampleLoader : MonoBehaviour
{
    public UnityEngine.UI.Text title;
    public UnityEngine.UI.Text description;


    UGBExampleBase currentExample;
    int currentIndex = 0;
    List<System.Type> exampleClasses = new List<System.Type>();

    void OnEnable()
    {
        exampleClasses = UnityGameBase.Core.Utils.UGBHelpers.GetTypesAssignableFrom<UGBExampleBase>();
        Debug.Log(string.Format("Found {0} example classes", exampleClasses.Count));
        InitExampleClass(0);
    }


    void NextExample()
    {
        currentIndex++;
        InitExampleClass(currentIndex);
    }

    void PreviousExample()
    {
        currentIndex--;
        InitExampleClass(currentIndex);
    }

    void InitExampleClass(int index)
    {
        index = index % exampleClasses.Count;
        
        if(currentExample != null)
        {
            
            Destroy(currentExample);
            currentExample = null;
        }

        System.Type nextType = exampleClasses[index];
        Debug.Log(string.Format("Will initialize {0} example. ", nextType));

        currentExample = this.gameObject.AddComponent(nextType) as UGBExampleBase;

        UpdateDescriptionPanel();
    }

    void UpdateDescriptionPanel()
    {
        title.text = currentExample.Title;
        description.text = currentExample.Description;
    }
}
