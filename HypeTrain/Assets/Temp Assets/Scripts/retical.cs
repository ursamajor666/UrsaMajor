﻿using UnityEngine;
using System.Collections;

public class retical : MonoBehaviour {

	public int reticalSize = 32;
	//public Texture2D reticalSprite;
	private int retX;
	private int retY;
	private int retOffset;
	public Vector3 currPlace;
	public GameObject cameraObj;

	// Use this for initialization
	void Start () {
		retX = reticalSize;
		retY = reticalSize;
		retOffset = reticalSize/2;
		Screen.showCursor = false;
	}

	void OnGUI() {
		//GUI.DrawTexture(new Rect(Input.mousePosition.x - retOffset, Screen.height - Input.mousePosition.y - retOffset, retX, retY), reticalSprite);
	}

	// Update is called once per frame
	void Update () {

		currPlace = Input.mousePosition;
		currPlace.z = 100;
		transform.position = cameraObj.GetComponent<Camera2D> ().camera.ScreenToWorldPoint(currPlace);
	}
}
