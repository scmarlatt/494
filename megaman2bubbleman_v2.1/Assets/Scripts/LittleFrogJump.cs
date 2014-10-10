using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LittleFrogJump : MonoBehaviour {
	
	public GameObject littlefrogPrefab;
	public GameObject thecamera;
	public float speed = 1f;
	public float xoffset = 0;
	public float secondsbetweenjump = 0;
	static public float numfrogs = 0;
	public List<GameObject> frogList;
	public float maxjumpheight = 3f;
	public float delay = 1.8f;
	public float nextusage;
	public GameObject megaman;
	public float frogcount = 0;
	bool lilfrogs = false;
	int startingindex = 0;
	bool threedown = false;
	
	float They = 0;
	
	bool onplatform = false;
	
	
	void Awake(){
		numfrogs = 0;
	}
	void Start () {
		
		nextusage = Time.time + delay;
	}
	void frogCreate(){
		GameObject littlefrog = Instantiate (littlefrogPrefab) as GameObject;
		Vector3 pos = Vector3.zero;
		pos.x = transform.position.x;
		pos.x = pos.x - 2;
		pos.x += xoffset;
		xoffset += 3;
		if (xoffset >= 9) 
		{
			xoffset = 0;
		}
		pos.y = transform.position.y + 2;
		pos.z = transform.position.z;
		//pos.z = pos.z + 1;
		littlefrog.transform.position = pos;
		//frogList.Add (littlefrog);
	}
	
	//	void frogJump(){
	//		for (int i = startingindex; i < (startingindex + 3); i++) {
	//			if(frogList[i] == null)
	//			{
	//				continue;
	//			}
	//			if(megaman.transform.position.x < frogList[i].transform.position.x)
	//			{
	//			frogList[i].rigidbody.velocity += new Vector3(-7,18,0);
	//			}
	//			else
	//			{
	//				frogList[i].rigidbody.velocity += new Vector3(7,18,0);
	//			}
	//			frogList[i].rigidbody.angularDrag = 1000;
	//
	//		}
	
	
	
	//	}
	
	void FixedUpdate () {
		
		
		//		if (onplatform == true) {
		//			print ("trying_everything");
		//			Vector3 pos = transform.position;
		//			pos.x = 0;
		//			pos.y = They;
		//			pos.z = 0;
		//
		//			transform.position = pos;
		//		}
		//		if (lilfrogs == true) {
		//			for (int i = startingindex; i < (startingindex + 3); i++) {
		//				if(frogList[i] == null)
		//				{
		//					continue;
		//				}
		//				frogList [i].rigidbody.AddForce (3 * Physics.gravity);
		//				if(transform.position.y > frogList[i].transform.position.y + 10)
		//				{
		//
		//					Destroy(frogList[i]);
		//					//frogcount--;
		//			
		//					LittleFrogJump.numfrogs--;
		//				}
		//			}
		//		}
	}
	
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(thecamera.transform.position.x + (2 * thecamera.camera.orthographicSize)) - Mathf.Abs(transform.position.x) < 1) {
			print (Mathf.Abs(thecamera.transform.position.x + (2 * thecamera.camera.orthographicSize)) - Mathf.Abs(this.transform.position.x) < 1);
			if(LittleFrogJump.numfrogs <= 0 && threedown == true)
				
			{
				startingindex = startingindex + 3;
				threedown = false;
			}
			
			//if(frogcount == 0){
			
			
			if(LittleFrogJump.numfrogs <= 0)
			{
				if(this.transform.position.y < -50)
				{
					if(megaman.transform.position.x < this.transform.position.x - 10)
					{
						return;
					}
					else if(megaman.transform.position.x > this.transform.position.x + 10)
					{
						return;
					}
				}
				for (int i = startingindex; i < (startingindex + 3); i++) {
					
					frogCreate();
					threedown = true;
					lilfrogs = true;
					//frogcount++;
					numfrogs = 3;
				}
				
				//				frogJump();
				//				nextusage = Time.time + delay;
			}
			// }
			
			//			if (Time.time > nextusage) {
			//				nextusage = Time.time + delay;
			//				frogJump();
			//				
			//			}
			
			
		}
		
	}


}