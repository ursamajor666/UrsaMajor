﻿using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

	private bool paused = false;
	public float vol = .35f;
	public float volOffset = .3f; //offset amount volume gets decreased during pause

	void Start () {
		paused = false;
		Time.timeScale = 1;
		AudioListener.volume = vol;
		Screen.showCursor = false;
	}
	
	void Update () {
		if(Input.GetKeyDown (KeyCode.Escape)){
			if(paused) { //unpause game if paused
				paused = false;
				Time.timeScale = 1;
				if(vol + volOffset > 1.0){ //properly adjust audio during pause and nonpause
					vol = 1.0f;
				} else {
					vol += volOffset;
				}
				Screen.showCursor = false;

			} else if (!paused) { //pause game if not pause
				paused = true;
				Time.timeScale = 0;
				if(vol - volOffset < 0){ 
					vol = 0.0f;
				} else {
					vol -= volOffset;
				}

				Screen.showCursor = true;
			}
		}
		AudioListener.volume = vol; //VOLUME THAT IS SET EVERY FRAME HERE, could cause problems if edit sound in another place!!!!
	}

	void OnGUI() {
		if(paused) {
			GUI.Box (new Rect(Screen.width/2 - 100, Screen.height/2 - 100, 250, 200), "Paused"); //main background box
			if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 250, 50), "Main Menu")) {
				Application.LoadLevel ("MainMenu");
			}
			if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2, 250, 50), "Quit")) {
				Application.Quit ();
			}
			vol = GUI.HorizontalSlider (new Rect(Screen.width/2 - 100, Screen.height/2 + 75, 250, 50), vol, 0, 1); //set vol based on slider
		}

	}
}
