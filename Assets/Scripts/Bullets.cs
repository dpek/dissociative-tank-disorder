using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

	public Team source;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Tank1" || other.gameObject.tag == "Tank2") {
			if(source == Team.TEAM1 ) {
				State.team1Score--;
			} else {
				State.team2Score++;
			}
			other.GetComponent<Tank>().Respawn(5);

			GameObject.Destroy(this.gameObject);
		} else if(other.gameObject.tag == "Tank3" || other.gameObject.tag == "Tank4") {
			if(source == Team.TEAM2){
				State.team2Score--;
			} else {
				State.team1Score++;
			}
			other.GetComponent<Tank>().Respawn(5);

			GameObject.Destroy(this.gameObject);

		} else if(other.gameObject.tag == "Bullet"){
			GameObject.Destroy (other.gameObject);
		}
		

	}
}
