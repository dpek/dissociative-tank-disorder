using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D collider){
		if( collider.gameObject.tag == "Tank1" || collider.gameObject.tag == "Tank2"){
				State.team1Score --;
				collider.GetComponent<Tank>().Respawn(5);
		}
		else if( collider.gameObject.tag == "Tank3" || collider.gameObject.tag == "Tank4"){
				State.team2Score--;
				collider.GetComponent<Tank>().Respawn(5);
	
		}
	}
}
