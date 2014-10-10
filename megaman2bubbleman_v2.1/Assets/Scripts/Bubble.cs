using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {
	bool goingleft = false;
	bool rollin = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x > 305) {
						goingleft = true;
				} else {
						goingleft = false;
				}



	   if (transform.position.x < 292 || transform.position.x > 316) {
			Destroy(this.gameObject);
	   }

		if (rollin == false) {
						if (goingleft == true) {
								this.rigidbody.velocity = new Vector3 (-15, 0, 0);
						} else {
								this.rigidbody.velocity = new Vector3 (15, 0, 0);

						}
						rollin = true;
				}
	}
}
