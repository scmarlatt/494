using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public GameObject LockedDoor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Bullet"){
			Destroy(this.LockedDoor);
			Destroy(col);
			this.renderer.material.color = Color.green;
		}
	}
}
