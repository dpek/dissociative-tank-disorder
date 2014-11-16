using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {
	public string xInputName;
	public string yInputName;
	public Rigidbody2D shot;
	Vector2 spawnLocation;
	public float speed = 2f;

	Vector2 mov;
	Vector2 stored;
	
	// Use this for initialization
	void Start () {
		spawnLocation = transform.position;
		mov = new Vector2(0,0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CheckMovement ();
	}

	void CheckMovement() {
		mov.Set(Input.GetAxis(xInputName), Input.GetAxis(yInputName));
		rigidbody2D.velocity = (mov.normalized * speed);
	}

	public void BoostSpeed() {
			StartCoroutine (BoostSpeedCoroutine());
	}

	private IEnumerator BoostSpeedCoroutine(){
		speed = 8;
		yield return new WaitForSeconds (3);
		speed = 2f;
	}

	public void Respawn(float time){
		StartCoroutine (RespawnCoroutine(time));
	
	}

	private IEnumerator RespawnCoroutine(float time){
		this.gameObject.collider2D.enabled  = (false);
		this.gameObject.renderer.enabled = (false);
		this.gameObject.transform.GetComponentInChildren<TankTop> ().gameObject.renderer.enabled = false;
		yield return new WaitForSeconds (time);
		this.gameObject.transform.position = spawnLocation;
		this.gameObject.collider2D.enabled  = (true);
		this.gameObject.renderer.enabled = (true);
		this.gameObject.transform.GetComponentInChildren<TankTop> ().gameObject.renderer.enabled = true;

	}
}