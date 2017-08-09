using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour {
	private ShowPanels showPanels;						//Reference to the ShowPanels script used to hide and show UI panels
	// Use this for initialization
	private StartOptions startOptions;

	Animator anim;

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void Awake()
	{
		//Get a component reference to ShowPanels attached to this object, store in showPanels variable
		showPanels = GetComponent<ShowPanels> ();
		anim = GetComponent<Animator>();
		startOptions = GetComponent<StartOptions>();

	}

	public void MainMenu() {


//		Destroy(this.transform.parent.gameObject);
//		Destroy(GameObject.Find("EventSystem"));
//		Destroy(GameObject.Find("UI"));
////		GameObject("EventSystem")
//		showPanels.HidePausePanel ();
////		SceneManager.CreateScene (1);
//		SceneManager.UnloadSceneAsync (1);
//
		SceneManager.LoadScene (0);

//		Destroy(GameObject.Find("showPanels"));

//		SceneManager.GetSceneAt (1);

//		GameObject.Destroy (SceneManager.GetSceneAt (1);
//		Application.LoadLevel ("scene");

		SceneManager.UnloadSceneAsync (startOptions.sceneToStart);

		showPanels.HidePausePanel ();


	}
}
