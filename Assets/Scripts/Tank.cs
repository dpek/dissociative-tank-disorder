using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {
	public string xInputName;
	public string yInputName;
	public Rigidbody2D shot;

	Vector2 mov;
	Vector2 stored;
	
	// Use this for initialization
	void Start () {
		mov = new Vector2(0,0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CheckMovement ();
	}

	void CheckMovement() {
		mov.Set(Input.GetAxis(xInputName), Input.GetAxis(yInputName));
		rigidbody2D.velocity = (mov.normalized * 1f);
	}
}