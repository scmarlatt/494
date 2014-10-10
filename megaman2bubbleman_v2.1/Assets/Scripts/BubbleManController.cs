using UnityEngine;
using System.Collections;

public class BubbleManController : MonoBehaviour {

	public GameObject Bubbles;
	public GameObject currentBullet;
	static public float bubbleCount = 0;
	public int bmhealth = 40;
	private Vector3 velocity;
	private MegaManController mmc;
	public GameObject MegaMan;
	bool canJump = true;
	public float nextusage;
	public float delay = 1.0f;
	float landingpos = 0;
	bool reloading = false;
	public float reloadingTimer = 0.0f;
	bool onplatform = false;
	bool isrunning = false;
	public GameObject Bullet;
	float shootbullet = 0;

	void Awake(){

	}

	// Use this for initialization
	void Start () {

		/*if (this.transform.position.x - MegaMan.transform.position.x < 12 &&  this.transform.position.x - MegaMan.transform.position.x >= 0 ) {
			
			
			this.rigidbody.velocity = new Vector3 (-60, 0, 0);
			
			
		}*/
		
		
	}
	
	// Update is called once per frame

	void Update () {
	
						if ((MegaMan.transform.position.x >= 305 && this.transform.position.x >= 305) || (MegaMan.transform.position.x <= 305 && this.transform.position.x <= 305)) {
								isrunning = true;
						} else {
								isrunning = false;
						}
						if (onplatform == false) {
								velocity += 2 * (Physics.gravity / 3) * Time.deltaTime;
						}
						transform.position += velocity * Time.deltaTime;


	}
	void BubblemanJump(){
				if (isrunning == true) {
						if (this.transform.position.x > 305) {


										this.rigidbody.velocity = new Vector3 (-15, 25, 0);
								
						}
						else{
			
									this.rigidbody.velocity = new Vector3 (15, 25, 0);
							}
			   bubbleCount = 0;
				}
		else {
			this.rigidbody.velocity = new Vector3 (0, 25, 0);
		}
	}
	void OnTriggerEnter(Collider coll){

		if (coll.gameObject.tag == "BubbleManFloor") {

					
						Vector3 pos = transform.position;
						pos.y = coll.bounds.max.y + (this.transform.localScale.y / 2);
						if (onplatform == false) {
								landingpos = transform.position.x;
						}
		
						onplatform = true;
						if (Time.time > nextusage) {
								pos.y += 1;
								nextusage = Time.time + delay;
								BubblemanJump ();
							
						}
						pos.x = landingpos;
						onplatform = true;
						velocity.y = 0.0F;
						velocity.x = 0.0F;
						transform.position = pos;
						if (MegaMan.transform.position.x > 293) {
								if (bubbleCount <= 3) {
										GameObject myBub = Instantiate (Bubbles) as GameObject;
										bubbleCount++;
								
										Vector3 bang = this.transform.position;
				                        bang.y  = coll.transform.position.y + (coll.transform.localScale.y/2) + 1;
										myBub.transform.position = bang;

								}
						}
				}

	}

	void OnTriggerStay(Collider col)
	{
		OnTriggerEnter(col);
	}

	void OnTriggerExit(Collider col){
		if (MegaMan.transform.position.x > 293) {
						if (shootbullet % 2 == 0) {
								currentBullet = Instantiate (Bullet) as GameObject;
								currentBullet.transform.position = this.transform.position;
								if (this.transform.position.x > 305) {
										currentBullet.rigidbody.velocity = new Vector3 (-10, 0, 0);
								} else {
										currentBullet.rigidbody.velocity = new Vector3 (10, 0, 0);
								}

						}
				}
		shootbullet++;
		onplatform = false;

	}
}
