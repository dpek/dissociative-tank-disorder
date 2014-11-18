using UnityEngine;
using System.Collections;

public class LogoTween : MonoBehaviour {

	private Vector2 endSize;

	private bool tween = false;
	public float delay = 0;

	void Awake() {
		endSize = new Vector2(this.transform.localScale.x, this.transform.localScale.y);
	}

	void Start() {
		this.transform.localScale = new Vector3(0,0,0);
		tween = false;
		StartCoroutine(WaitForDelay());
	}

	void Update () {
		if (tween)
		{
			this.transform.localScale = Vector2.Lerp(this.transform.localScale, endSize, 0.05f);
		}
	}

	IEnumerator WaitForDelay()
	{
		yield return new WaitForSeconds(delay);
		tween = true;
	}
}
