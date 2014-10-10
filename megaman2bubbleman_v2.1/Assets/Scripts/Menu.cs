using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			Application.LoadLevel("_Scene_0");
		}
		if (Input.GetKeyDown ("2")) {
			Application.LoadLevel("_Scene_1");		
		}
		if (Input.GetKeyDown ("3")) {
			Application.LoadLevel("Tips");	
		}
		if (Input.GetKeyDown ("4")) {
			Application.LoadLevel("MainScreen");		
		}
	}
}
