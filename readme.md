# Unity Game Base Examples

This repository contains examples on how to use the Unity Game Base. Unity Game Base can be found here: https://github.com/kwnetzwelt/ugb-source If you want to contribute to UGB or look at usage examples in context checkout this repository: https://github.com/kwnetzwelt/ugb-development

Unity Game Base is a toolkit for Game Development with the Unity Engine. It adds features, which are not present within the Engine and defines a basic guide on how to structure game development in Unity. 

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



### Localization