using UnityEngine;
using System.Collections;

public class Jellyfish : MonoBehaviour {
	
	public float delay = 1.8f;
	public float nextusage;
	public float frogcount = 0;
	bool swimming = false;
	public float timer = 0;
	
	// Use this for initialization
	void Start () {
		nextusage = Time.time + delay;
		
		
		//print (Shrimp.mmanposy);
		//print (transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (Shrimp.mmanpos > transform.position.x + 10) {
			rigidbody.velocity = new Vector3 (0, 0, 0);
			return;
		}
		
		if (Shrimp.mmanpos < transform.position.x - 10) {
			rigidbody.velocity = new Vector3 (0, 0, 0);
			return;
		}
		if (swimming == false) {
			rigidbody.velocity = new Vector3 (0, -3, 0);
		}
	}
	
	void Swim(){
		if (Time.time > nextusage) {
			if (Shrimp.mmanpos < transform.position.x && rigidbody.velocity.x == 0) {
				nextusage = Time.time + delay;
				rigidbody.velocity = new Vector3 (-3, -1, 0);
				return;
			}
			
			
			if(Shrimp.mmanpos > transform.position.x && rigidbody.velocity.x == 0) {
				
				rigidbody.velocity = new Vector3 (3, -1, 0);
				nextusage = Time.time + delay;
				return;
				
			}
			
			nextusage = Time.time + delay;
			rigidbody.velocity = new Vector3 (0, 2, 0);
			
			
		}  
		
		
	}
	
	void FixedUpdate () {
		
		if (swimming == true) {
			
			Swim();
			
			
		}
		
		
		if (Shrimp.mmanposy >= transform.position.y && Shrimp.mmanposy < 0) {
			
			swimming = true;
		}
		
		
		//if (swimming == true) {
		//this.rigidbody.AddForce (0, -3, 0);
		//}
		//
		//if(Mathf.Abs(this.rigidbody.velocity.x) > 4.0)
		//{
		//this.rigidbody.velocity += new Vector3(this.rigidbody.velocity.x * -1,2,0);
		//}
		
		
		
		//if(Mathf.Abs (this.rigidbody.velocity.y) > 2.0)
		//{
		//this.rigidbody.velocity += new Vector3(0,this.rigidbody.velocity.y * -1,0);
		//}
		
	}
	
	
}