using UnityEngine;
using System.Collections;
using UnityGameBase;

public class GameComponentExample : UGBExampleBase {

	MyGameComponentExample component;

	void OnEnable()
	{
		component = this.gameObject.AddComponent<MyGameComponentExample>();
		Debug.Log(component.Game.testing);
	}

	void OnDisable()
	{
		Destroy(component);
		component = null;
	}

	#region implemented abstract members of UGBExampleBase
	public override int Index {
		get {
			return 0;
		}
	}
	public override string Title {
		get {
			return "GameComponent";
		}
	}
	public override string Description {
		get {
			return "UGB provides a base class for your components to simplify access to your game implementation. " +
				"Instead of deriving from MonoBehaviour your scripts Should derive from GameComponent. " +
				"You provide the type of your game as a parameter to GameComponent. ";
		}
	}
	#endregion

}

public class MyGameComponentExample : GameComponent<EmptyGame>
{

}