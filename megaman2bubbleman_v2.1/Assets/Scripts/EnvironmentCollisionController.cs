using UnityEngine;
using System.Collections;

public class EnvironmentCollisionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		print ("HI");
		if (other.transform.position.y < (this.transform.position.y + (this.transform.lossyScale.y / 2.0))) {
			Vector3 vel = new Vector3(0, -15, 0);
			other.rigidbody.velocity = vel;	
			print (other.rigidbody.velocity.x);
		}
	}
}
