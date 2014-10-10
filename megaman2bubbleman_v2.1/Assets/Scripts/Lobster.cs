using UnityEngine;
using System.Collections;

public class Lobster : MonoBehaviour {
	public GameObject Lobsterprefab;
	// Use this for initialization
	bool first = false;
	bool second = false;
	bool third = false;
	bool fourth = false;
	
	bool onplatform = false;
	Vector3 velocity;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Shrimp.mmanpos > 190 && Shrimp.mmanpos < 200) {
			if(first == false)
			{
				GameObject Lobster = Instantiate (Lobsterprefab) as GameObject;
				print ("made one!");
				Vector3 pos = transform.position;
				pos.x += 10;
				pos.y += 10;
				pos.z = 0;
				Lobster.transform.position = pos;
				first = true;
			}
		}
		
		if (Shrimp.mmanpos > 210 && Shrimp.mmanpos < 220) {
			if(second == false)
			{
				GameObject Lobster = Instantiate (Lobsterprefab) as GameObject;
				Vector3 pos = transform.position;
				pos.x += 20;
				pos.y += 10;
				pos.z = 0;
				Lobster.transform.position = pos;
				second = true;
			}
		}
		if (Shrimp.mmanpos > 230 && Shrimp.mmanpos < 237) {
			if(third == false)
			{
				GameObject Lobster = Instantiate (Lobsterprefab) as GameObject;
				Vector3 pos = transform.position;
				pos.x += 40;
				pos.y += 10;
				pos.z = 0;
				Lobster.transform.position = pos;
				third = true;
			}
		}
		
		if (Shrimp.mmanpos > 240 && Shrimp.mmanpos < 255) {
			if(fourth == false)
			{
				GameObject Lobster = Instantiate (Lobsterprefab) as GameObject;
				Vector3 pos = transform.position;
				pos.x += 50;
				pos.y += 10;
				pos.z = 0;
				Lobster.transform.position = pos;
				fourth = true;
				
			}
		}
	}
	
}
