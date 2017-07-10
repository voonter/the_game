﻿using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {


	private ShowPanels showPanels;						//Reference to the ShowPanels script used to hide and show UI panels
	private bool isPaused;								//Boolean to check if the game is paused or not
	private StartOptions startScript;					//Reference to the StartButton script

	private Animator anim;
	private Component[] pausableInterfaces;

    private GameObject hudCanvas;




    //Awake is called before Start()

    void Awake()
	{
		//Get a component reference to ShowPanels attached to this object, store in showPanels variable
		showPanels = GetComponent<ShowPanels> ();
		//Get a component reference to StartButton attached to this object, store in startScript variable
		startScript = GetComponent<StartOptions> ();

        hudCanvas = GameObject.FindGameObjectWithTag("HUD");

    }

	// Update is called once per frame
	void Update () {

		//Check if the Cancel button in Input Manager is down this frame (default is Escape key) and that game is not paused, and that we're not in main menu
		if (Input.GetButtonDown ("Cancel") && !isPaused && !startScript.inMainMenu) 
		{
			//Call the DoPause function to pause the game
			DoPause();
		} 
		//If the button is pressed and the game is paused and not in main menu
		else if (Input.GetButtonDown ("Cancel") && isPaused && !startScript.inMainMenu) 
		{
			//Call the UnPause function to unpause the game
			UnPause ();
		}
	
	}


	public void DoPause()
	{
		//Set isPaused to true
		isPaused = true;
		//Set time.timescale to 0, this will cause animations and physics to stop updating
		Time.timeScale = 0;


        GameObject player = GameObject.FindGameObjectWithTag("PlayerFPS");
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        player.GetComponent<MouseLook>().enabled = false;
        player.GetComponent<CharacterMotor>().enabled = false;
        mainCamera.GetComponent<MouseLook>().enabled = false;

        hudCanvas = GameObject.FindGameObjectWithTag("HUD");
        hudCanvas.SetActive(false);

        showPanels.ShowPausePanel ();
	}


	public void UnPause()
	{
        GameObject playerFPS = GameObject.FindGameObjectWithTag("PlayerFPS");
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (!playerHealth.isPlayerDead())
        {
            playerFPS.GetComponent<MouseLook>().enabled = true;
            playerFPS.GetComponent<CharacterMotor>().enabled = true;
            mainCamera.GetComponent<MouseLook>().enabled = true;
        }
        hudCanvas.SetActive(true);

        //Set isPaused to false
        isPaused = false;
		//Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
		Time.timeScale = 1;
		//call the HidePausePanel function of the ShowPanels script
		showPanels.HidePausePanel ();
	}


}
