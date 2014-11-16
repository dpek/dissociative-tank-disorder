using UnityEngine;
using System.Collections;

public class GoalBehaviour : MonoBehaviour {

	public Team team;

	void OnTriggerEnter2D(Collider2D collider){
		if( collider.gameObject.tag == "Tank1" || collider.gameObject.tag == "Tank2"){
			if(team == Team.TEAM2){
				State.team1Score += 2;
				collider.GetComponent<Tank>().Respawn(0);
			}
		}
		else if( collider.gameObject.tag == "Tank3" || collider.gameObject.tag == "Tank4"){
			if(team == Team.TEAM1){
				State.team2Score += 2;
				collider.GetComponent<Tank>().Respawn(0);
			}
		}
	}
}
