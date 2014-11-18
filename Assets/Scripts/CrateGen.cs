using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CrateGen: MonoBehaviour {

	public Transform blockPrefab;
	public int numObjects;

	private Transform lastBlock;
	private Queue<Transform> blockQ;
	
	private Vector3 blockNextPosition;
	private Vector3 blockStartPos;

	IEnumerator Start () {

		blockStartPos = blockPrefab.position;
		blockNextPosition = blockStartPos;
		
		blockQ = new Queue<Transform>(numObjects);
		for(int i = 0; i < numObjects; i++){
			lastBlock = (Transform)Instantiate(blockPrefab);
			lastBlock.parent = transform;
			blockNextPosition.y -= 7;
			lastBlock.position = blockNextPosition;
			blockQ.Enqueue(lastBlock);
		}

		while (true) {
			yield return StartCoroutine(MoveObject(transform, blockStartPos, blockNextPosition, 3.0f));
		}
	}

	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 0.15f / time;
		while (i < 0.25f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
}