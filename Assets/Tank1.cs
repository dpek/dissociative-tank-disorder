using UnityEngine;
using System.Collections;

public class Tank1 : MonoBehaviour {

	Vector2 mov;
	public GameObject Tank;
	Vector2 stored;
	bool CanFire;
	public Rigidbody2D shot;
	// Use this for initialization
	void Start () {
		CanFire = true;
		mov = new Vector2(0,0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CheckMovement ();
	}

	void CheckMovement(){
		mov.Set(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
		rigidbody2D.velocity = (mov.normalized * .5f);

	
	}
	void Fire(){
		if (CanFire) {
			Rigidbody2D bullet = (Rigidbody2D)Instantiate (shot);
			bullet.AddForce (transform.TransformDirection (mov.normalized));
			CanFire = false;
			ShotsFired();
		}
		
	}
	IEnumerator ShotsFired(){
		yield return new WaitForSeconds(3);
	
	}
	
}
