using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class UGBExampleLoader : MonoBehaviour
{
    public UnityEngine.UI.Text title;
    public UnityEngine.UI.Text description;

    public string group;

    UGBExampleBase currentExample;
    int currentIndex = 0;
    List<System.Type> exampleClasses = new List<System.Type>();
    List<UGBExampleBase> examples = new List<UGBExampleBase>();
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        exampleClasses = UnityGameBase.Core.Utils.UGBHelpers.GetTypesAssignableFrom<UGBExampleBase>();

        exampleClasses = exampleClasses.FindAll((type) =>
        {
            return type.Namespace.EndsWith(group);
        });
        
        foreach(var exampleClass in exampleClasses)
        {
            var itm = this.gameObject.AddComponent(exampleClass) as UGBExampleBase;
            itm.enabled = false;
            examples.Add(itm);
        }

        examples.Sort((a, b) => {
            return a.Index.CompareTo(b.Index);
        });

        Debug.Log(string.Format("Found {0} example classes", exampleClasses.Count));
        InitExampleClass(0);
    }


    public void NextExample()
    {
        currentIndex++;
        InitExampleClass(currentIndex);
    }

    public void PreviousExample()
    {
        currentIndex--;
        InitExampleClass(currentIndex);
    }

    void InitExampleClass(int index)
    {
        index = index % exampleClasses.Count;
        
        if(currentExample != null)
        {
            currentExample.enabled = false;
            currentExample = null;
        }

        currentExample = examples[index];
        currentExample.enabled = true;
        UpdateDescriptionPanel();
    }

    void UpdateDescriptionPanel()
    {
        title.text = currentExample.Title;
        description.text = currentExample.Description;
    }
}
