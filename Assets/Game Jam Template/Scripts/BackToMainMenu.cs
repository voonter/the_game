using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBack : MonoBehaviour {
	private ShowPanels showPanels;						//Reference to the ShowPanels script used to hide and show UI panels
	// Use this for initialization

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void Awake()
	{
		//Get a component reference to ShowPanels attached to this object, store in showPanels variable
		showPanels = GetComponent<ShowPanels> ();


	}

	public void MainMenu() {
//		showPanels.HidePausePanel ();
//		SceneManager.UnloadSceneAsync(1);
//		SceneManager.LoadScene (0);
	}
}
