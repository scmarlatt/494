using UnityEngine;
using System.Collections;

public class winner : MonoBehaviour {
	public GameObject bubbleman;
	public float timer = 0;
	int i = 0;
	// Use this for initialization
	void Start () {
		timer = Time.time + 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (bubbleman == null) {
			if(i == 0){
			timer = Time.time + 3.0f;
				i++;
			}
			GUIText gt = this.GetComponent<GUIText> ();
			gt.text = "YOU WIN!";
			if(Time.time > timer)
			{
				Application.LoadLevel("MainScreen");
			}
		}

	}
}
