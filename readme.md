# Unity Game Base Examples

This repository contains examples on how to use the Unity Game Base. Unity Game Base can be found here: https://github.com/kwnetzwelt/ugb-source If you want to contribute to UGB or look at usage examples in context checkout this repository: https://github.com/kwnetzwelt/ugb-development

Unity Game Base is a toolkit for Game Development with the Unity Engine. It adds features, which are not present within the Engine and defines a basic guide on how to structure game development in Unity. 

 **UGB Master:** | [![Build Status](https://travis-ci.org/kwnetzwelt/ugb-source.svg?branch=master)](https://travis-ci.org/kwnetzwelt/ugb-source) 
 **UGB Development:** | [![Build Status](https://travis-ci.org/kwnetzwelt/ugb-source.svg?branch=development)](https://travis-ci.org/kwnetzwelt/ugb-source) 


## Install UGB examples

1. Setup a Unity project or use open your existing Unity Project
2. If not present add Unity Game Base to your project via commandline like this


    $ cd Assets
    $ mkdir packages && cd packages
    $ git clone https://github.com/kwnetzwelt/ugb-source
    $ git clone https://github.com/kwnetzwelt/ugb-examples


3. Open your Unity Project
4. Navigate to Assets/packages/ugb-examples

## Examples

### Gamelogic

Contains information on how to create your game. The Gamelogic class is a basic class to simplify access of all your Game Components. It is a singleton. Any instance of it coming up while loading levels will automatically be destroyed. 

```C#
using UnityEngine;
using System.Collections;
using UnityGameBase;


public class EmptyGame : Game {

    protected override void Initialize()
    {
    }

    protected override void GameSetupReady()
    {
        testing
    }

    public void DoSomething() 
    {
        Debug.Log("Done");
    }
}
```

Your project should contain a scene called "default"  which is the first scene of your project and only contains your derived class of "UnityGameBase.Game". 

You can control how to handle loading your game with the _testing_ flag. This flag is usually false in the first scene of your project and true in all other scenes. This way you can easily check it in _GameSetupReady_ and either Load the next level or not.     

Use the GameComponent class to access your Game Instance like this:

```C#
public class MyGameComponentExample : GameComponent<EmptyGame>
{
    void Start()
    {
        EmptyGame.DoSomething();
    }
}
```


### Input

#### Multitouch

This part explains the Multitouch API of the UGB. 

Touches and clicks are detected through the same API. Try this sourcecode in your GameComponent. 

```C#
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

``` 
TouchInformation has a rich API. For example you can extrapolate (_touchInfo.Extrapolate()_). This is useful to simulate a rubber band effect. 

```C#
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
``` 

TouchInformation instances are persistent. Once created they will be updated by the system. Hence the possibility to use TouchInformation in the update method. Touches are persistent like this. 

```C#
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

``` 

### Localization

UGB contains localization functionality. It can parse XML and CSV Data. Loca-Source-files should be labeled ```UGB_Loca```. 
When they are imported, an AssetPostprocessor will parse them and create language specific loca-files in ```Resources/loca```. 

We provide localization for UI through ```UnityGameBase.Core.XUI.LocalizedTextCompent```. 

You need to register supported language in your ```Game``` implementation. Do it in the ```Initialize()``` method. 
```C#
Languages.Add(1, "en");
Languages.Add(2, "es");
Languages.Add(3, "de");
```

Language can be changed at runtime. However all ```LString``` keep their values!

```C#
// switch to spanish:
UGB.Loca.SetLanguage(2);
```

In your Source-Code you can use ```LString``` to translate your text. You can also use it to fill your text with parameters. 

```C#
LString myTranslation = "MyTextKey";
// Will log the translation of "MyTextKey" as defined in the localization file
Debug.Log(myTranslation);

float value1 = 0.02f;
int value2 = 34;

// Uses string format on the Translation of "MyTextKey" using the parameters value1 and value2
Debug.Log(myTranslation.Params(value1,value2));  
```
