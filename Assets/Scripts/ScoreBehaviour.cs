using UnityEngine;
using System.Collections;

public class ScoreBehaviour : MonoBehaviour {
	public GameObject team1Text;
	public GameObject team2Text;
	public GameObject timerText;
	public AudioClip good;
	public AudioClip bad;
	public float roundTime = 60;
	public Entry entry;
	public Entry.Mode mode;

	int oldTeam1Score = 0;
	int oldTeam2Score = 0;
	Vector3 originalTeam1Scale;
	Vector3 originalTeam2Scale;

	void Start () {
		State.reset(roundTime);
		oldTeam1Score = 0;
		oldTeam2Score = 0;
		originalTeam1Scale = team1Text.transform.localScale;
		originalTeam2Scale = team2Text.transform.localScale;
		StartCoroutine(entry.DoIntro (mode, State.round));
	}

	void Update () {
		if (State.team1Score != oldTeam1Score) {
			UpdateScore(Team.TEAM1, State.team1Score, State.team1Score > oldTeam1Score);
		}
		if (State.team2Score != oldTeam2Score) {
			UpdateScore(Team.TEAM2, State.team2Score, State.team2Score > oldTeam2Score);
		}
		State.elapsedTime += Time.deltaTime;
		if (State.elapsedTime > State.roundTime) {
			State.round++;
			if (State.round > 10) {
				State.round = 1;
				Application.LoadLevel("Menu");

			} else {
				int number = Random.Range (1, 5);
				Application.LoadLevel("Stage0" + number);
			}
		}

		timerText.GetComponent<TextMesh> ().text = "" + ((int)(State.roundTime - State.elapsedTime));
	}

	void UpdateScore(Team team, int score, bool goodChange) {
		StopAllCoroutines();

		if (goodChange) {
			AudioSource.PlayClipAtPoint(good, Vector3.zero);
		} else {
			AudioSource.PlayClipAtPoint(bad, Vector3.zero);
		}

		GameObject teamText = null;
		if (team == Team.TEAM1) {
			teamText = team1Text;
			oldTeam1Score = score;
			teamText.transform.localScale = originalTeam1Scale;
		} else if (team == Team.TEAM2) {
			teamText = team2Text;
			oldTeam2Score = score;
			teamText.transform.localScale = originalTeam2Scale;
		}

		StartCoroutine(TweenText(teamText, score));
	}

	IEnumerator TweenText(GameObject go, int score) {
		float t = 0;
		Vector3 originalScale = go.transform.localScale;
		Vector3 destScale = go.transform.localScale * 2;

		// Larger
		while(t < 1) {
			go.transform.localScale = Vector3.Lerp(originalScale, destScale, Mathf.Pow(t, 4));
			go.transform.Rotate(-Vector3.forward * t);
			yield return new WaitForEndOfFrame();
			t += Time.deltaTime*3;
		}

		go.transform.localScale = destScale;
		go.GetComponent<TextMesh>().text = "" + score;

		// Smaller
		t = 0;
		while (t < 1) {
			go.transform.localScale = Vector3.Lerp(destScale, originalScale, Mathf.Pow(t, 1/4f));
			go.transform.Rotate(Vector3.forward * t);
			yield return new WaitForEndOfFrame();
			t += Time.deltaTime*3;
		}

		go.transform.localScale = originalScale;
	}
}