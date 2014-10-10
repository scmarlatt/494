using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float hitcount = 0;

	public GameObject Health;
	static public float BubbleManHealth = 20;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter(Collider coll){
		//find out what hit this basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Bullet") {
			Destroy (collidedWith);

			if(this.tag == "LittleFrog"){
				Destroy (this.gameObject);
				LittleFrogJump.numfrogs--;
			}
			if(this.tag == "BigFrog" || this.tag == "BigFish"){
				hitcount++;
				if(hitcount == 5)
				{
					GameObject healthme = Instantiate (Health) as GameObject;
					Vector3 pos = this.transform.position;
					pos.y = pos.y - 1;
					healthme.transform.position = pos;
				
					Destroy (this.gameObject);
				}

			}
			if(this.tag == "Shrimp")
			{
				hitcount++;
				if(hitcount == 2)
				{
					Destroy (this.gameObject);
				}
			}
			if(this.tag == "JellyFish" || this.tag == "Snail")
			{
				Destroy(this.gameObject);
			}
			if(this.tag == "BubbleMan")
			{
				hitcount++;
				BubbleManHealth = BubbleManHealth - 1;
				if(hitcount == 20)
				{
					Destroy (this.gameObject);
				}
			}
		}
	}
}