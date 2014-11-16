using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {
	
	public static int team1Score = 0;
	public static int team2Score = 0;
	
	public static void resetScore() {
		team1Score = 0;
		team2Score = 0;
	}
}
