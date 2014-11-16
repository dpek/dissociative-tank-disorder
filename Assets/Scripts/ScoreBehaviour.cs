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

	bool ending = false;

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
		if (State.elapsedTime > State.roundTime && !ending) {
			ending = true;
			StartCoroutine(NextRound());
		}

		timerText.GetComponent<TextMesh> ().text = "" + Mathf.Max (0,((int)(State.roundTime - State.elapsedTime)));
	}

	IEnumerator NextRound() {
		ending = true;
		GameObject go = new GameObject("GAME END");
		string str = "GAME END\n";
		if(State.team1Score > State.team2Score) {
			str += "TEAM 1 WINS";
		}
		else if (State.team2Score > State.team1Score) {
			str += "TEAM 2 WINS";
		} else {
			str += "TIED";
		}
		go.AddComponent<TextMesh>().font = timerText.GetComponent<TextMesh>().font;
		go.GetComponent<TextMesh>().text = str;
		go.GetComponent<TextMesh>().alignment = TextAlignment.Center;
		go.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
		go.GetComponent<TextMesh>().fontSize = 400;
		go.GetComponent<MeshRenderer>().material = timerText.GetComponent<TextMesh>().font.material;
		go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

		yield return new WaitForSeconds(2f);
		State.round++;
		if (State.round > 5) {
			State.round = 1;
			Application.LoadLevel ("Menu");
		} else {
			State.Stage++;
			if (State.Stage > 5) {
				State.Stage = 1;			
			}
			Application.LoadLevel ("Stage0" + State.Stage);
		}
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