using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	// Use this for initialization

	void Start () {

	}
	
	
	// Update is called once per frame
	
	void Update () {

		if (this.transform.position.x > MegaManController.mm2xpos + 17 || this.transform.position.x < MegaManController.mm2xpos - 17) {
			Destroy(this.gameObject);
		}
	}
	
	
}