using UnityEngine;
using System.Collections;

public class LittleFrog : MonoBehaviour {
	bool onplatform = false;
	public Vector3 velocity;
	public float nextusage;
	public float delay = 3.0f;
	float landingpos = 0;
	
	
	// Use this for initialization
	void Start () {
		nextusage = Time.time + delay;
		frogJump ();
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Time.time > nextusage) {
			nextusage = Time.time + delay;
			frogJump();

			
		}*/
		
		if (onplatform == false) {
			velocity += 2 * (Physics.gravity/3) * Time.deltaTime;
		}
		transform.position += velocity * Time.deltaTime;
	}
	
	void FixedUpdate () {
		this.rigidbody.angularDrag = 1000;
		if(Shrimp.mmanposy > this.transform.position.y + 10)
		{
			
			Destroy(this.gameObject);
			LittleFrogJump.numfrogs--;
		}
		
	}
	
	
	void OnTriggerEnter (Collider coll){
		if (this.tag == "LittleFrog") {
			if(coll.gameObject.layer == 9)
			{
			Vector3 pos = transform.position;
			pos.y = coll.bounds.max.y + (this.transform.localScale.y/2);
			if(onplatform == false)
			{
				landingpos = transform.position.x;
			}
			
			onplatform = true;
			if (Time.time > nextusage) {
				pos.y += 1;
				nextusage = Time.time + delay;
				frogJump();
			}
			pos.x = landingpos;
			onplatform = true;
			velocity.y = 0.0F;
			velocity.x = 0.0F;
			transform.position = pos;
			}
		}
	}
	
	void OnTriggerStay(Collider col)
	{
		OnTriggerEnter (col);
		
	}
	void OnTriggerExit(Collider col)
	{
		onplatform = false;
	}
	
	
	
	void frogJump(){
		
		if (Shrimp.mmanpos < transform.position.x) {
			this.rigidbody.velocity = new Vector3 (-9, 18, 0);
		} else {
			this.rigidbody.velocity = new Vector3 (9, 18, 0);
		}
		
	}
	
}