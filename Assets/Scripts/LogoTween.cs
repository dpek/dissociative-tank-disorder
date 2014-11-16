using UnityEngine;
using System.Collections;

public class LogoTween : MonoBehaviour {

	private Vector2 endSize;

	void Awake() {
		endSize = new Vector2(this.transform.localScale.x, this.transform.localScale.y);
	}

	void Start() {
		this.transform.localScale = new Vector3(0,0,0);
	}

	void Update () {
			this.transform.localScale = Vector2.Lerp(this.transform.localScale, endSize, 0.05f);
	}
}
