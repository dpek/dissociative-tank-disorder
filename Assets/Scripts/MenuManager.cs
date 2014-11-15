using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {

	public List<string> stages;
	int offset;
	
	// Use this for initialization
	void Start () {
	
	}

	void OnGUI() {

		foreach(string stage in stages){

			if( GUI.Button( new Rect (350+offset, 500, 100, 100), stage ) )
			   Application.LoadLevel(stage);

			offset += 100;
		}

		offset = 0;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
