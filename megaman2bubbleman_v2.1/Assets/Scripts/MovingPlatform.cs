using UnityEngine;
using System.Collections;

public class MovingPlatform: MonoBehaviour {

	public Vector3 pos;
	private Vector3 velocity;
	public float MaxD;
	// Use this for initialization
	void Start () {
		pos = this.transform.position;
		this.velocity.y = -8;
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(this.transform.position.y - pos.y) > MaxD){
			this.velocity.y *= -1;
		}

		transform.position += velocity * Time.deltaTime;
	}
}
