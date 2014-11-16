using UnityEngine;
using System.Collections;

public class OctoBullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){

		StartCoroutine(respawn());
		collider.GetComponent<Tank>();

		}

	IEnumerator respawn(){

		this.collider2D.enabled = false;
		this.GetComponent<SpriteRenderer>().enabled = false;

		yield return new WaitForSeconds(10);

		this.collider2D.enabled = true;
		this.GetComponent<SpriteRenderer>().enabled = true;
	}

}
