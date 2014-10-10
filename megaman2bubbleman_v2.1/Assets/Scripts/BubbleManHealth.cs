using UnityEngine;
using System.Collections;

public class BubbleManHealth : MonoBehaviour {
	public GameObject megaman;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (megaman.transform.position.x > 293) {
			GUIText gt = this.GetComponent<GUIText> ();
			gt.text = "BubbleMan Health: " + EnemyController.BubbleManHealth;
		}

	}
}
