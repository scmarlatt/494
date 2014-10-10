using UnityEngine;
using System.Collections;

public class MegaManController_Scene2 : MonoBehaviour {

	static public float mm2xpos;
	static public float mm2ypos;
	public GameObject Gun;
	public GameObject floormaterial;
	public int facing = 1;
	public Vector3 maxVelocity;
	public Vector3 maxBulletVelocity;
	private Vector3 velocity;
	Collider platform = null;
	//Collider sidePlatform = null;
	bool canJump = false;
	public GameObject Bullet;
	public GameObject currentBullet;
	public bool dead = false;
	static public int health = 30;
	public float bottomY1 = 35;
	public bool recovering = false;
	public float recoverTimer = 0.0f;
	static public bool imdead = false;
	bool madeit = false;
	public Material material;
	
	
	//SCOTTS
	public float jumpAirTime = 0f;
	public bool jumping = false;
	
	private Vector3 trc;
	private Vector3 tlc;
	private Vector3 blc;
	private Vector3 brc;
	private Vector3 ltrc;
	private Vector3 ltlc;
	private Vector3 lblc;
	private Vector3 lbrc;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{
		mm2xpos = this.transform.position.x;
		mm2ypos = this.transform.position.y;

		if (dead == true) {
			Application.LoadLevel("_Scene_1");		
		}
		if (this.transform.position.x > 295 && madeit == false) {
			GameObject door = Instantiate (floormaterial) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.z = 0;
			pos.x = 292;
			pos.y = -52;
			door.transform.position = pos;
			pos.x = 2;
			pos.y = 5;
			pos.z = 4;
			door.transform.localScale = pos;
			door.renderer.material = material;
			madeit = true;
			
		}
		if (health <= 0) {
			dead = true;		
		}
		if (this.transform.position.y < -500) {
			dead = true;		
		}
		
		if (this.recovering == true) {
			this.renderer.material.color = Color.black;
			recoverTimer += Time.deltaTime;
			if(recoverTimer > 2.0f){
				recovering = false;
				recoverTimer = 0;
				this.renderer.material.color = Color.blue;
			}
		}
		if (!(recoverTimer > 0 && recoverTimer < .5)) {
			
			velocity.x = maxVelocity.x * Input.GetAxis ("Horizontal");
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if (facing == -1) {
					Gun.transform.localPosition *= -1;
				}
				facing = 1;
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if (facing == 1) {
					Gun.transform.localPosition *= -1;
				}
				facing = -1;
			}
			
			
			if (Input.GetKeyDown ("x")) {
				currentBullet = Instantiate (Bullet) as GameObject;
				if (facing == 1) {
					print("HI");
					currentBullet.transform.position = transform.position;
					currentBullet.rigidbody.velocity += new Vector3 (25, 0, 0);
					
				}
				
				if (facing == -1) {
					currentBullet.transform.position = transform.position;
					currentBullet.rigidbody.velocity += new Vector3 (-25, 0, 0);
				}
			}
			
			
			if (canJump && Input.GetKeyDown ("z")) {
				canJump = false;
				jumping = true;
				velocity.y += maxVelocity.y;
				print(jumpAirTime);
			}
			if(Input.GetKeyUp("z")){
				jumping = false;
			}
			if(jumpAirTime < .2f && jumping){
				velocity.y += 2.2f;
			}
			if (!canJump) {
				velocity.y -= 2;
				jumpAirTime += Time.deltaTime;
			}
			
		}
		
		transform.position += velocity * Time.deltaTime;
		
		ltrc = trc;
		trc = new Vector3 (this.transform.position.x + (this.transform.lossyScale.x / 2), this.transform.position.y + (this.transform.lossyScale.y / 2), 0);
		ltlc = tlc;
		tlc = new Vector3 (this.transform.position.x - (this.transform.lossyScale.x / 2), this.transform.position.y + (this.transform.lossyScale.y / 2), 0);
		lblc = blc;
		blc = new Vector3 (this.transform.position.x - (this.transform.lossyScale.x / 2), this.transform.position.y - (this.transform.lossyScale.y / 2), 0);
		lbrc = brc;
		brc = new Vector3 (this.transform.position.x + (this.transform.lossyScale.x / 2), this.transform.position.y - (this.transform.lossyScale.y / 2), 0);
		
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.layer == 9) {
			
			Vector3 pos = transform.position;
			
			if(IsInside(col, brc) && IsInside(col, blc)){
				pos.y = col.bounds.max.y + (this.transform.lossyScale.y / 2);
				this.velocity.y = 0.0F;
				canJump = true;
				jumpAirTime = 0.0F;
			}
			else if(IsInside(col, trc) && IsInside(col, tlc)){
				pos.y = col.bounds.min.y - (this.transform.lossyScale.y / 2 );
				this.velocity.y = -2;
			}
			else if(IsInside(col, trc) && IsInside(col, brc)){
				pos.x = col.bounds.min.x - (this.transform.lossyScale.x / 2);
				this.velocity.x = 0.0F;
			}
			else if(IsInside(col, tlc) && IsInside(col, blc)){
				pos.x = col.bounds.max.x + (this.transform.lossyScale.x / 2);
				this.velocity.x = 0.0F;
			}
			else if(IsInside(col, brc)){
				print ("MATT SUX");
				RaycastHit hit;
				if(Physics.Raycast(lbrc, brc - lbrc, out hit)){
					if(closeEnough(hit.point.x, col.bounds.min.x)){
						//go to left
						pos.x = col.bounds.min.x - (this.transform.lossyScale.x / 2);
						this.velocity.x = 0.0F;
					}
					else if(closeEnough(hit.point.y, col.bounds.max.y)){
						//go on top
						pos.y = col.bounds.max.y + (this.transform.lossyScale.y / 2);
						this.velocity.y = 0.0F;
						canJump = true;
						jumpAirTime = 0.0F;
					}
				}
			}
			else if(IsInside (col, blc)){
				print ("MATT SUX");
				RaycastHit hit;
				if(Physics.Raycast(lblc, blc - lblc, out hit)){
					if(closeEnough(hit.point.x, col.bounds.max.x)){
						//right side collision
						pos.x = col.bounds.max.x + (this.transform.lossyScale.x / 2);
						this.velocity.x = 0.0F;
					}
					else if(closeEnough(hit.point.y, col.bounds.max.y)){
						//top collision
						pos.y = col.bounds.max.y + (this.transform.lossyScale.y / 2);
						this.velocity.y = 0.0F;
						canJump = true;
						jumpAirTime = 0.0F;
					}
				}
			}
			else if(IsInside (col, trc)){
				print ("MATT SUX1");
				RaycastHit hit;
				if(Physics.Raycast(ltrc, trc - ltrc, out hit)){
					if(closeEnough(hit.point.x, col.bounds.min.x)){
						pos.x = col.bounds.min.x - (this.transform.lossyScale.x / 2);
						this.velocity.x = 0.0F;
					}
					else if(closeEnough(hit.point.y, col.bounds.min.y)){
						pos.y = col.bounds.min.y - (this.transform.lossyScale.y / 2 );
						this.velocity.y = -2;
					}
				}
			}
			else if(IsInside (col, tlc)){
				print ("MATT SUX");
				RaycastHit hit;
				if(Physics.Raycast(ltlc, tlc - ltlc, out hit)){
					if(closeEnough(hit.point.x, col.bounds.max.x)){
						pos.x = col.bounds.max.x + (this.transform.lossyScale.x / 2);
						this.velocity.x = 0.0F;
					}
					else if(closeEnough(hit.point.y, col.bounds.min.y)){
						pos.y = col.bounds.min.y - (this.transform.lossyScale.y / 2 );
						this.velocity.y = -2;
					}
				}
			}
			else if(!IsInside(col, tlc) && !IsInside(col, blc)){
				this.velocity.x = 0.0F;
			}
			else if(!IsInside(col, trc) && !IsInside(col, brc)){
				this.velocity.x = 0.0F;
			}
			//what if both trc and brc are triggered and same for left
			//what do i need to do with velocity?
			transform.position = pos;
		}
		if (col.gameObject.layer == 11) {
			if(col.gameObject.layer == 11 && !this.recovering){
				health -= 3;
				if(facing == 1){
					velocity.x = -3;
					velocity.y = 5;
				}
				if(facing == -1){
					velocity.x = 3;
					velocity.y = 5;
				}
				recovering = true;	
			}
			velocity += Physics.gravity * Time.deltaTime;
			transform.position += velocity * Time.deltaTime;
		}
		if (col.gameObject.layer == 12) {
			dead = true;
			
		}
		if (col.gameObject.layer == 14) {
			health = 30;
			Destroy (col.gameObject);
			
		}
	}
	
	void OnTriggerStay(Collider col)
	{
		OnTriggerEnter(col);
	}
	
	void OnTriggerExit(Collider col)
	{
		canJump = false;
		jumpAirTime = 0.0f;
		
	}
	
	
	//Referred to this function by Nathan Shields from the page:
	//http://answers.unity3d.com/questions/163864/test-if-point-is-in-collider.html
	static public bool IsInside ( Collider coll, Vector3 point)
	{
		Vector3    center;
		Vector3    direction;
		Ray        ray;
		RaycastHit hitInfo;
		bool       hit;
		
		// Use collider bounds to get the center of the collider. May be inaccurate
		// for some colliders (i.e. MeshCollider with a 'plane' mesh)
		center = coll.bounds.center;
		
		// Cast a ray from point to center
		direction = center - point;
		ray = new Ray(point, direction);
		hit = coll.Raycast(ray, out hitInfo, direction.magnitude);
		
		// If we hit the collider, point is outside. So we return !hit
		return !hit;
	}
	
	static public bool closeEnough(float a, float b){
		if (Mathf.Abs (a - b) < .25F) {
			return true;
		}
		return false;
	}
	
	
	
	
	
}