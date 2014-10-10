using UnityEngine;
using System.Collections;

public class FallingFloorController : MonoBehaviour {

	public float Timer = 0.0f;
	public bool collEvent = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (collEvent) {
			if (Mathf.Abs (Time.time - Timer) > .15){
				this.rigidbody.velocity = new Vector3 (0, -10, 0);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		Timer = Time.time;
		collEvent = true;
	}
}
