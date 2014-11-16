using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {
	
	public static int team1Score = 0;
	public static int team2Score = 0;
	public static int team1RoundScore = 0;
	public static int team2RoundScore = 0;
	public static float elapsedTime = 0;
	public static float roundTime = 0;
	public static int round = 1;
	public static int Stage = 0;
	
	public static void reset(float roundTime) {
		team1Score = 0;
		team2Score = 0;
		team1RoundScore = 0;
		team2RoundScore = 0;
		elapsedTime = 0;
		State.roundTime = roundTime;
	}
}
