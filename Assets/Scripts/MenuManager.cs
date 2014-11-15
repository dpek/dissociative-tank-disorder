using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {

	public List<string> stages;

	public float width = 100;
	public float height = 100;

	void OnGUI() {
		for(int i = 0; i < stages.Count; ++i){
			string stage = stages[i];
			float offset = ((stages.Count-1) / 2.0f) - i;
			offset *= width;

			float x = Screen.width/2 - width/2 + offset;
			float y = Screen.height - height*2;

			if(GUI.Button( new Rect(x, y, width, height), stage )) {
			   Application.LoadLevel(stage);
			}
		}
	}
}
