using UnityEngine;
using System.Collections;

public class TankTop : MonoBehaviour {
	public string xRotate;
	public string yRotate;
	public string shoot;
	public Rigidbody2D shot;
	public AudioClip shootSound;

	bool CanFire;
	
	// Use this for initialization
	void Start () {
		CanFire = true;
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
		}
		transform.Rotate (Vector3.forward, 180f * input * Time.deltaTime);
	}
		
	void Fire() {
		if (CanFire) {
			AudioSource.PlayClipAtPoint(shootSound, Vector3.zero);
			Rigidbody2D bullet = (Rigidbody2D)Instantiate (shot, transform.position + transform.up *.75f, Quaternion.Euler(0,0,0));
			bullet.rigidbody2D.velocity = transform.up * 10;
			if (this.gameObject.transform.parent.gameObject.tag == "Tank1" || this.gameObject.transform.parent.gameObject.tag == "Tank2") {
				bullet.gameObject.GetComponent<Bullets>().source = Team.TEAM1; 
			} else {
				bullet.gameObject.GetComponent<Bullets>().source = Team.TEAM2;
			}
			CanFire = false;
			StartCoroutine(ShotsFired());
		}
	}
	IEnumerator ShotsFired() {
		yield return new WaitForSeconds(3);
		CanFire = true;
	}
}