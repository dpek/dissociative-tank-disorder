using UnityEngine;
using System.Collections;

public class TextCoroutine : MonoBehaviour {
	
	public void UpdateScore(GameObject teamText, Vector2 originalScale, int score) {
		StopAllCoroutines();

		teamText.transform.localScale = originalScale;
		
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
