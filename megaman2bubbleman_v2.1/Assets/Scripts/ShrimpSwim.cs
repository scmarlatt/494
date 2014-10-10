using UnityEngine;
using System.Collections;

public class ShrimpSwim : MonoBehaviour {
	
	public float delay = 2.0f;
	public float nextusage;
	public GameObject megaman;
	public float frogcount = 0;
	bool swimming = false;
	public float timer = 0;
	
	// Use this for initialization
	void Start () {
		Swim ();
		nextusage = Time.time + delay;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void Swim(){
		
		float newy = 4;
		
		if(Shrimp.mmanpos < transform.position.x)
		{
			this.rigidbody.velocity += new Vector3(-4,newy,0);
		}
		else
		{
			this.rigidbody.velocity += new Vector3(4,newy,0);
		}
		this.rigidbody.angularDrag = 1000;
		
		swimming = true;
		
	}
	
	
	void FixedUpdate () {
		
		if (Time.time > nextusage) {
			nextusage = Time.time + delay;
			Swim();
			
		}
		
		
		if (swimming == true) {
			this.rigidbody.AddForce (0, -3, 0);
		}
		
		if(Mathf.Abs(this.rigidbody.velocity.x) > 4.0)
		{
			this.rigidbody.velocity += new Vector3(this.rigidbody.velocity.x * -1,2,0);
		}
		
		//if(Mathf.Abs (this.rigidbody.velocity.y) > 2.0)
		//{
		//this.rigidbody.velocity += new Vector3(0,this.rigidbody.velocity.y * -1,0);
		//}
		
	}
}