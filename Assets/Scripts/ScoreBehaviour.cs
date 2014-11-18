using UnityEngine;
using System.Collections;

public class ScoreBehaviour : MonoBehaviour {
	public GameObject team1Text;
	public GameObject team2Text;
	public GameObject timerText;
	public AudioClip good;
	public AudioClip bad;
	private float roundTime = 65;
	public Entry entry;
	public Entry.Mode mode;
	
	public TextCoroutine team1TextCoroutines;
	public TextCoroutine team2TextCoroutines;

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
		
		team1TextCoroutines = new GameObject().AddComponent<TextCoroutine>();
		team2TextCoroutines = new GameObject().AddComponent<TextCoroutine>();
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
		GameObject go = new GameObject("ROUND END");
		string str = "ROUND END\n";
		if(State.team1Score > State.team2Score) {
			str += "TEAM 1 WINS";
			State.team1RoundScore++;
		}
		else if (State.team2Score > State.team1Score) {
			str += "TEAM 2 WINS";
			State.team2RoundScore++;
		} else {
			str += "TIED";
		}
		str += "\nSCORE: " + State.team1RoundScore;
		str += " - " + State.team2RoundScore;

		go.AddComponent<TextMesh>().font = timerText.GetComponent<TextMesh>().font;
		go.GetComponent<TextMesh>().text = str;
		go.GetComponent<TextMesh>().alignment = TextAlignment.Center;
		go.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
		go.GetComponent<TextMesh>().fontSize = 400;
		go.GetComponent<MeshRenderer>().material = timerText.GetComponent<TextMesh>().font.material;
		go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

		yield return new WaitForSeconds(5f);
		State.round++;
		if (State.round > 5) {
			State.round = 1;

			str = "GAME END";
			str += "\nSCORE: " + State.team1RoundScore;
			str += " - " + State.team2RoundScore;
			go.GetComponent<TextMesh>().text = str;
			State.team1RoundScore = 0;
			State.team2RoundScore = 0;

			yield return new WaitForSeconds(5f);

			Application.LoadLevel ("Menu");
		} else {
			State.Stage++;
			if (State.Stage > 5) {
				State.Stage = 1;			
			}
			Application.LoadLevel ("Stage0" + State.Stage);
		}
	}
	
	public void UpdateScore(Team team, int score, bool goodChange) {
		if (goodChange) {
			AudioSource.PlayClipAtPoint(good, Vector3.zero);
		} else {
			AudioSource.PlayClipAtPoint(bad, Vector3.zero);
		}
		
		GameObject teamText = null;
		if (team == Team.TEAM1) {
			teamText = team1Text;
			oldTeam1Score = score;
			team1TextCoroutines.UpdateScore(teamText, originalTeam1Scale, score);
		} else if (team == Team.TEAM2) {
			teamText = team2Text;
			oldTeam2Score = score;
			team2TextCoroutines.UpdateScore(teamText, originalTeam2Scale, score);
		}
	}
}