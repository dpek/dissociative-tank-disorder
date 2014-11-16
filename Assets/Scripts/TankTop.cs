using UnityEngine;
using System.Collections;

public class TankTop : MonoBehaviour {
	public string xRotate;
	public string yRotate;
	public	GameObject job;
	bool CanFire;

	float AngularVelocity = 10;


	public string shoot;
	public Rigidbody2D shot;
	// Use this for initialization
	void Start () {
		CanFire = true;
		job.transform.localPosition = new Vector2 (0, 0);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown (shoot)) {
				Fire ();
		}
		float input = 0;
		if (Input.GetButton (xRotate)) {
				input = -1;
		} else if (Input.GetButton (yRotate)) {
				input = 1;
		
		} else {
				input = 0;
		}
		
		Debug.Log (xRotate + " " + yRotate + " " + input);				
		transform.Rotate (Vector3.forward, 180f * input * Time.deltaTime);
	}
		
	void Fire(){
		if (CanFire) {
			Debug.Log ("Position: " + transform.position + " Forward: " + transform.forward);
			Rigidbody2D bullet = (Rigidbody2D)Instantiate (shot, transform.position + transform.up *.60f, Quaternion.Euler(0,0,0));
			bullet.rigidbody2D.velocity = transform.up * 10;
			CanFire = false;
			StartCoroutine(ShotsFired());
		}
		
	}
	IEnumerator ShotsFired(){
		yield return new WaitForSeconds(3);
		CanFire = true;
		
	}
}