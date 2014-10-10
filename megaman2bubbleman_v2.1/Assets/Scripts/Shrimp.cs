using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shrimp : MonoBehaviour {
	
	
	static public float mmanpos;
	static public float mmanposy;
	public GameObject shrimpPrefab;
	public GameObject thecamera;
	public float speed = 1f;
	public float yoffset = 1;
	public float secondsbetweenjump = 0;
	static public float numShrimp = 0;
	public float maxjumpheight = 3f;
	public float delay = 1.0f;
	public float nextusage;
	public GameObject megaman;
	int startingindex = 0;
	bool threedown = false;
	public float timer = 0;
	bool createme = false;
	
	
	
	
	void Start () {
		
		
	}
	
	void shrimpCreate(){
		GameObject shrimp = Instantiate (shrimpPrefab) as GameObject;
		Vector3 pos = Vector3.zero;
		pos.x = transform.position.x - 3;
		pos.y = transform.position.y + yoffset;
		yoffset = yoffset + 2;
		if (yoffset >= 3) {
			yoffset = 0;
		}
		pos.z = transform.position.z;
		//pos.z = pos.z + 1;
		shrimp.transform.position = pos;
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		
		mmanpos = megaman.transform.position.x;
		mmanposy = megaman.transform.position.y;
		
		if (Mathf.Abs (mmanpos) - Mathf.Abs (transform.position.x) < 20) {
			
			createme = true;
		}
		//if (Mathf.Abs(thecamera.transform.position.x + (2 * thecamera.camera.orthographicSize)) - Mathf.Abs(transform.position.x) < 3) {
		if(timer > 6.0f && threedown == true)
			
		{
			startingindex = startingindex + 2;
			timer = 0;
			threedown = false;
		}
		timer += Time.deltaTime;
		
		//if(frogcount == 0){
		if(createme == true){
			if (threedown == false) {


				if((megaman.transform.position.x < transform.position.x && megaman.transform.position.x + 15 >= transform.position.x)
				   || (megaman.transform.position.x > transform.position.x && megaman.transform.position.x - 15 <= transform.position.x)) 
				{
					shrimpCreate ();
					threedown = true;
					
					//frogcount++;
					
					
					//ShrimpSwim ();
					nextusage = Time.time + delay;
				}
			}
		}
		
		// }
		
		//}
		/*for (int i = 0; i < 3; i++) {
Vector3 pos = frogList [i].transform.position;
if(frogList[i].transform.position.y < maxjumpheight && keepjumping == true)
{
pos.y += speed * Time.deltaTime;
frogList[i].transform.position = pos;
}
else
{
keepjumping = false;
if(frogList[i].transform.position.y == 0)
{
keepjumping = true;
}
}

} */
		
	}
}