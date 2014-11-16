using UnityEngine;
using System.Collections;

public class TankTop : MonoBehaviour {
	public string xRotate;
	public string yRotate;
	public string shoot;
	public Rigidbody2D shot;
	public AudioClip shootSound;
	public int fireTime;
	float bulletSpeed = 12;
	bool CanFire;
	
	// Use this for initialization
	void Start () {
		fireTime = 3;
		CanFire = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton(shoot)) {
			Fire (fireTime);
		}
		float input = 0;
		if (Input.GetButton (xRotate)) {
			input = -1;
		} else if (Input.GetButton (yRotate)) {
			input = 1;
		}
		transform.Rotate (Vector3.forward, 180f * input * Time.deltaTime);
	}
		
	void Fire(float time) {
		if (CanFire && this.gameObject.transform.parent.renderer.enabled ) {
			AudioSource.PlayClipAtPoint(shootSound, Vector3.zero);
			Rigidbody2D bullet = (Rigidbody2D)Instantiate (shot, transform.position + transform.up *1.25f, Quaternion.Euler(0,0,0));
			bullet.rigidbody2D.velocity = transform.up * bulletSpeed;
			if (this.gameObject.transform.parent.gameObject.tag == "Tank1" || this.gameObject.transform.parent.gameObject.tag == "Tank2") {
				bullet.gameObject.GetComponent<Bullets>().source = Team.TEAM1; 
			} else {
				bullet.gameObject.GetComponent<Bullets>().source = Team.TEAM2;
			}
			CanFire = false;
			StartCoroutine(ShotsFired(time));
		}
	}
	public void LaserSpeed(){
		StartCoroutine (laserShot (0));
	}
	private IEnumerator laserShot(float time){
		fireTime = 0;
		yield return new WaitForSeconds (2);
		fireTime = 3;

	}
	IEnumerator ShotsFired(float time) {
		yield return new WaitForSeconds(time);
		CanFire = true;
	}

}