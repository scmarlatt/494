using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Snail : MonoBehaviour {
	
	public GameObject snailPrefab;
	public float speed = 8f;
	public float leftAndRightEdge = 2f;
	public GameObject megaMan;
	public List<GameObject> snailList;
	
	
	void Start () {
		SnailCreate ();
	}
	void Update () {
		if (snailList [0] == null) {
			return;
		}
		leftAndRightEdge = (transform.position.x + (transform.localScale.x/2) - 1);
		Vector3 pos = snailList[0].transform.position;
		pos.x += speed * Time.deltaTime;
		snailList[0].transform.position = pos;
		if (pos.x < (transform.position.x - (transform.localScale.x/2) + 1)) {
			speed = Mathf.Abs (speed);
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed);
		} 
		
	}
	
	
	void SnailCreate(){
		GameObject snail = Instantiate (snailPrefab) as GameObject;
		Vector3 pos = Vector3.zero;
		pos.x = transform.position.x + 2;
		pos.y = transform.position.y + 2;
		pos.z = transform.position.z;
		snail.transform.position = pos;
		snailList.Add (snail);
		
		
	}
}
