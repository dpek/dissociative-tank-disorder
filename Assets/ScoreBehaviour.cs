using UnityEngine;
using System.Collections;

public class ScoreBehaviour : MonoBehaviour {

	public GameObject team1Text;
	public GameObject team2Text;

	int oldTeam1Score = 0;
	int oldTeam2Score = 0;
	Vector3 originalTeam1Scale;
	Vector3 originalTeam2Scale;
	
	public enum Team{
		TEAM1, TEAM2
	}

	void Start () {
		State.resetScore();
		oldTeam1Score = 0;
		oldTeam2Score = 0;
		originalTeam1Scale = team1Text.transform.localScale;
		originalTeam2Scale = team2Text.transform.localScale;
	}

	void Update () {
		if(Input.GetKeyDown( KeyCode.A)) { State.team1Score++;}

		if (State.team1Score != oldTeam1Score) {
			UpdateScore (Team.TEAM1, State.team1Score);
		}
		if (State.team2Score != oldTeam2Score) {
			UpdateScore (Team.TEAM2, State.team2Score);
		}
	}

	void UpdateScore(Team team, int score) {
		StopAllCoroutines();

		int oldScore = 0;
		GameObject teamText = null;
		if (team == Team.TEAM1) {
			teamText = team1Text;
			oldScore = oldTeam1Score;
			oldTeam1Score = score;
			teamText.transform.localScale = originalTeam1Scale;
		} else if (team == Team.TEAM2) {
			teamText = team2Text;
			oldScore = oldTeam2Score;
			oldTeam2Score = score;
			teamText.transform.localScale = originalTeam2Scale;
		}

		teamText.GetComponent<TextMesh>().text = ""+oldScore;
		StartCoroutine(TweenText(teamText, score));
	}

	IEnumerator TweenText(GameObject go, int score) {
		float t = 0;
		Vector3 originalScale = go.transform.localScale;
		Vector3 destScale = go.transform.localScale * 2;

		// Larger
		while(t < 1) {
			go.transform.localScale = Vector3.Lerp(originalScale, destScale, Mathf.Pow(t, 4));
			yield return new WaitForEndOfFrame();
			t += Time.deltaTime*3;
		}

		go.transform.localScale = destScale;
		go.GetComponent<TextMesh>().text = "" + score;

		// Smaller
		t = 0;
		while (t < 1) {
			go.transform.localScale = Vector3.Lerp(destScale, originalScale, Mathf.Pow(t, 1/4f));
			go.transform.Rotate(Vector3.left * t);
			yield return new WaitForEndOfFrame();
			t += Time.deltaTime*3;
		}

		go.transform.localScale = originalScale;
	}
}