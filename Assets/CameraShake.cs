﻿using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	private Vector3 targetPos;

	public bool auto = false;
	public float autoFreq = 0.1f;
	public float autoTime = 2;

	public float speed = 0.1f;

	void Start () {
		targetPos = transform.localPosition;
		if(auto) {
			StartCoroutine(Shake(autoFreq, autoTime));
		}
	}

	void Update () {
		transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, speed);
	}

	public IEnumerator Shake(float frequency, float time) {
		int changeTimes = 0;
		float spentTime = 0;
		while(spentTime < time || time == -1) {
			yield return new WaitForEndOfFrame();
			if(spentTime / frequency > changeTimes) {
				changeTimes++;
				Vector2 pos = Random.insideUnitCircle;
				targetPos.x = pos.x;
				targetPos.y = pos.y;
				targetPos.z = transform.localPosition.z;
			}
			spentTime += Time.deltaTime;
		}
	}
}
