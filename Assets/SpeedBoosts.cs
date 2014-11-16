using UnityEngine;
using System.Collections;

public class SpeedBoosts : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D Player){
		if(Player.tag.Contains("Tank")){
			Player.GetComponent<Tank>().BoostSpeed();
		}
	}
}
