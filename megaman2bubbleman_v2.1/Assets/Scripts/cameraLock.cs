using UnityEngine;
using System.Collections;

public class cameraLock : MonoBehaviour {
	
	public GameObject MegaMan;
	public GameObject MegaMan2;
	bool onthebottom = false;
	bool first = true;
	bool second = true;
	bool third = true;
	bool fourth = true;

	// Use this for initialization
	void Start () {
		//StartCoroutine(PauseCoroutine());   
	}

	// Update is called once per frame
	void Update () {
	
		//SCENETWO
		if (MegaMan2.transform.position.y >= 300) {
			Vector3 pos = MegaMan2.transform.position;
			pos.z = -10.0F;
			transform.position = pos;
			camera.orthographicSize = 12;
			return;
		}
		//Vector3 pos = MegaMan.transform.position;
		//pos.z = -10.0F;

		//FIRSTSCENE
		if (MegaMan.transform.position.x <= 13 && MegaMan.transform.position.y >35) {
			if(first == true){
			Vector3 posi = Vector3.zero;
			posi.x = MegaMan.transform.position.x;
			posi.y = 44;
			posi.z = -20;
			camera.orthographicSize = 10;
			transform.position = posi;
			return;
			}
			
		}

		//SECONDSCENE
		if (MegaMan.transform.position.y <= 35 && MegaMan.transform.position.y >= 13 && MegaMan.transform.position.x > -4) {
			if(second == true){
			first = false;
			Vector3 posi = Vector3.zero;
			posi.x = 11;
			posi.y = 25;
			posi.z = -20;
			camera.orthographicSize = 15;
			transform.position = posi;
			return;
			}
			
			
		}

		//THIRDSCENE
		if (MegaMan.transform.position.y <=10 && MegaMan.transform.position.y >= 4) {
			if(third == true){
				second = false;
			Vector3 posi = Vector3.zero;
			posi.x = 11;
			posi.y = 2;
			posi.z = -20;
			camera.orthographicSize = 15;
			transform.position = posi;
			return;
			}
			
			
		}

		//FOURTHSCENE AKA UNDERWATER
		if (MegaMan.transform.position.y < -15 && MegaMan.transform.position.x < 30 && MegaMan.transform.position.y > -35) {
			if(fourth == true){
			third = false;
			Vector3 posi = Vector3.zero;
			posi.x = 10;
			posi.y = -26;
			posi.z = -20;
			camera.orthographicSize = 15;
			transform.position = posi;
			return;
			}
			
			
		}
		//BUBBLEMAN
		if (MegaMan.transform.position.x > 290 && MegaMan.transform.position.y < -40) {
			
			Vector3 posi = Vector3.zero;
			posi.x = 300;
			posi.y = -45;
			posi.z = -20;
			camera.orthographicSize = 10;
			transform.position = posi;
			return;
			
		}

		//FIFTHSCENE AKA JERRYFISH
		if (MegaMan.transform.position.y < -38 && MegaMan.transform.position.x > -3 && MegaMan.transform.position.y > -55) {
			if(onthebottom == false)
			{
				Vector3 posi = Vector3.zero;
				posi.x = MegaMan.transform.position.x;
				posi.y = -48;
				posi.z = -20;
				camera.orthographicSize = 10;
				transform.position = posi;
				return;
			}
			
		}
		//PAST JERRYFIZ
		if (MegaMan.transform.position.y < -54 && MegaMan.transform.position.x > -3) {
			onthebottom = true;
			if(onthebottom == true){
				Vector3 posi = Vector3.zero;
				posi.x = MegaMan.transform.position.x;
				posi.y = -55;
				posi.z = -20;
				camera.orthographicSize = 10;
				transform.position = posi;
				return;
			}
		}

		if (onthebottom == true) {
			Vector3 posi = Vector3.zero;
			posi.x = MegaMan.transform.position.x;
			posi.y = -55;
			posi.z = -20;
			camera.orthographicSize = 10;
			transform.position = posi;
			return;
		}

	

		
		//transform.position = pos;
	}


	/*IEnumerator PauseCoroutine() {
		
		while (true)
		{
			if (Input.GetKeyDown(KeyCode.P))
			{
				if (Time.timeScale == 0)
				{
					Time.timeScale = 1;
				} else {
					Time.timeScale = 0;
				}
				
			}    
			yield return null;    
		}
	}*/
	
}