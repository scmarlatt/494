using UnityEngine;
using System.Collections;

public class DrawCubesScript : MonoBehaviour {

	private int Health = 4;
	public Vector3 pos;
	private Vector3 velocity;
	public float MaxD;
	public int maxV;
	// Use this for initialization
	void Start () {
		pos = this.transform.position;
		this.velocity.x = maxV;
	}
	
	// Update is called once per frame
	void Update () {
		if (Health == 0) {
			Destroy(this.gameObject);		
		}
		if(Mathf.Abs(this.transform.position.x - pos.x) > MaxD){
			this.velocity.x *= -1;
		}
		
		transform.position += velocity * Time.deltaTime;
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Bullet") {
			Destroy(col.gameObject);
			Health -= 1;		
		}
	}
}