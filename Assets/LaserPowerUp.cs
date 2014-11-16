using UnityEngine;
using System.Collections;

public class LaserPowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D Player){
		if(Player.tag.Contains("Tank")){
			Player.gameObject.GetComponent<Tank>().gameObject.transform.GetComponentInChildren<TankTop>().LaserSpeed();
			StartCoroutine(Respawn ());
		}
	
	}
	IEnumerator Respawn(){
		this.gameObject.collider2D.enabled  = (false);
		this.gameObject.renderer.enabled = (false);
		yield return new WaitForSeconds (10);
		this.gameObject.collider2D.enabled  = (true);
		this.gameObject.renderer.enabled = (true);
	
	}
}
