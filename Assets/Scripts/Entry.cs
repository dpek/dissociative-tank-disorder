using UnityEngine;
using System.Collections;

public class Entry : MonoBehaviour
{
	public AudioClip clipDeathmatch;
	public AudioClip clipSteamroll;

	public AudioClip clipPanzer1;
	public AudioClip clipPanzer2;
	public AudioClip clipPanzer3;
	public AudioClip clipPanzer4;
	public AudioClip clipPanzer5;
	public AudioClip clipPanzer6;
	public AudioClip clipPanzer7;
	public AudioClip clipPanzer8;
	public AudioClip clipPanzer9;
	public AudioClip clipPanzer10;
	public AudioClip clipReady;
	public AudioClip clipFight;

	public Sprite modeDeathmatch;
	public Sprite modeSteamroll;
	
	public Sprite panzerTankLeft;
	public Sprite panzerTankRight;
	public Sprite panzerText;
	public Sprite panzerNum1;
	public Sprite panzerNum2;
	public Sprite panzerNum3;
	public Sprite panzerNum4;
	public Sprite panzerNum5;
	public Sprite panzerNum6;
	public Sprite panzerNum7;
	public Sprite panzerNum8;
	public Sprite panzerNum9;
	public Sprite panzerNum10;

	public enum Mode
	{
		DEATHMATCH, STEAMROLL
	}

	void Start() {
		StartCoroutine(DoIntro(Mode.STEAMROLL, 3));
	}

	IEnumerator DoIntro(Mode mode, int round)
	{
		float t = 0;
		float zoomPower = 4;
		float initialZoomScale = 0;
		float endZoomScale = 4;
		var endZoomVector = new Vector3(endZoomScale, endZoomScale, endZoomScale);
		var initialZoomVector = new Vector3(initialZoomScale, initialZoomScale, initialZoomScale);
		float offA = -7;
		float offNum = 9;
		
		// Game Mode
		float startDist = 20;
		float endDist = 10;
		var pos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -5);
		var panzerLeft = new GameObject("Panzer Left");
		var panzerRight = new GameObject("Panzer Right");
		panzerLeft.AddComponent<SpriteRenderer>().sprite = panzerTankLeft;
		panzerRight.AddComponent<SpriteRenderer>().sprite = panzerTankRight;
		var origLeft = panzerLeft.transform.position = new Vector3(pos.x - startDist, pos.y, pos.z);
		var origRight = panzerRight.transform.position = new Vector3(pos.x + startDist, pos.y, pos.z);
		panzerLeft.transform.localScale = new Vector3(2, 2, 1);
		panzerRight.transform.localScale = new Vector3(2, 2, 1);

		var modeText = new GameObject("Mode");
		modeText.transform.position = pos + new Vector3(0, 0, -2);
		modeText.transform.localScale = new Vector3(initialZoomScale, initialZoomScale, 1);
		switch(mode) {
			case Mode.DEATHMATCH:
				AudioSource.PlayClipAtPoint(clipDeathmatch, Vector3.zero);
				modeText.AddComponent<SpriteRenderer>().sprite = modeDeathmatch;
				break;
			case Mode.STEAMROLL:
				AudioSource.PlayClipAtPoint(clipSteamroll, Vector3.zero);
				modeText.AddComponent<SpriteRenderer>().sprite = modeSteamroll;
				break;
		}
		float time = 1.0f;
		while (t < time)
		{
			panzerLeft.transform.position = Vector3.Lerp(origLeft, pos - new Vector3(endDist, 0, 0), t / time);
			panzerRight.transform.position = Vector3.Lerp(origRight, pos + new Vector3(endDist, 0, 0), t / time);
			modeText.transform.localScale = Vector3.Lerp(initialZoomVector, endZoomVector, Mathf.Min(1, Mathf.Pow((t + time - 0.5f) / time, zoomPower)));

			yield return new WaitForEndOfFrame();
			t += Time.deltaTime;
		}
		AudioSource.PlayClipAtPoint(clipReady, Vector3.zero);
		t = 0;
		while (t < time)
		{
			panzerLeft.transform.position = Vector3.Lerp(pos - new Vector3(endDist, 0, 0), origLeft, t / time);
			panzerRight.transform.position = Vector3.Lerp(pos + new Vector3(endDist, 0, 0), origRight, t / time);

			yield return new WaitForEndOfFrame();
			t += Time.deltaTime;
		}
		GameObject.Destroy(panzerLeft);
		GameObject.Destroy(panzerRight);
		GameObject.Destroy(modeText);

		// Panzer
		var panzerNumText = new GameObject("PanzerNum");
		panzerNumText.transform.position = pos + new Vector3(offNum, 0, -2);
		panzerNumText.transform.localScale = new Vector3(initialZoomScale, initialZoomScale, 1);
		switch (round)
		{
			case 1:
				AudioSource.PlayClipAtPoint(clipPanzer1, Vector3.zero);
				panzerNumText.AddComponent<SpriteRenderer>().sprite = panzerNum1;
				break;
			case 2:
				AudioSource.PlayClipAtPoint(clipPanzer2, Vector3.zero);
				panzerNumText.AddComponent<SpriteRenderer>().sprite = panzerNum2;
				break;
			case 3:
				AudioSource.PlayClipAtPoint(clipPanzer3, Vector3.zero);
				panzerNumText.AddComponent<SpriteRenderer>().sprite = panzerNum3;
				break;
			case 4:
				AudioSource.PlayClipAtPoint(clipPanzer4, Vector3.zero);
				panzerNumText.AddComponent<SpriteRenderer>().sprite = panzerNum4;
				break;
			case 5:
				AudioSource.PlayClipAtPoint(clipPanzer5, Vector3.zero);
				panzerNumText.AddComponent<SpriteRenderer>().sprite = panzerNum5;
				break;
			case 6:
				AudioSource.PlayClipAtPoint(clipPanzer6, Vector3.zero);
				panzerNumText.AddComponent<SpriteRenderer>().sprite = panzerNum6;
				break;
			case 7:
				AudioSource.PlayClipAtPoint(clipPanzer7, Vector3.zero);
				panzerNumText.AddComponent<SpriteRenderer>().sprite = panzerNum7;
				break;
			case 8:
				AudioSource.PlayClipAtPoint(clipPanzer8, Vector3.zero);
				panzerNumText.AddComponent<SpriteRenderer>().sprite = panzerNum8;
				break;
			case 9:
				AudioSource.PlayClipAtPoint(clipPanzer9, Vector3.zero);
				panzerNumText.AddComponent<SpriteRenderer>().sprite = panzerNum9;
				break;
			case 10:
				AudioSource.PlayClipAtPoint(clipPanzer10, Vector3.zero);
				panzerNumText.AddComponent<SpriteRenderer>().sprite = panzerNum10;
				break;
		}
		Debug.Log(panzerNumText.transform);

		// Panzer Text
		var panzerTextGO = new GameObject("Panzer");
		panzerTextGO.AddComponent<SpriteRenderer>().sprite = panzerText;
		panzerTextGO.transform.position = pos + new Vector3(offA, 0, -2);
		panzerTextGO.transform.localScale = initialZoomVector;
		time = 0.3f;
		t = 0;
		while (t < time)
		{
			panzerTextGO.transform.localScale = Vector3.Lerp(initialZoomVector, endZoomVector, Mathf.Pow(t / time, zoomPower));
			yield return new WaitForEndOfFrame();
			t += Time.deltaTime;
		}

		// Panzer Number
		yield return new WaitForSeconds(0.2f);
		time = 0.4f;
		t = 0;
		while (t < time)
		{
			panzerNumText.transform.localScale = Vector3.Lerp(initialZoomVector, endZoomVector, Mathf.Pow(t / time, zoomPower));
			yield return new WaitForEndOfFrame();
			t += Time.deltaTime;
		}
		yield return new WaitForSeconds(0.3f);

		GameObject.Destroy(panzerTextGO);
		GameObject.Destroy(panzerNumText);

		// Fight
		AudioSource.PlayClipAtPoint(clipFight, Vector3.zero);
	}
}
