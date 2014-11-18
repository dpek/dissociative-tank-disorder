using UnityEngine;
using System.Collections;

public class MenuItem : MonoBehaviour {

	public int level;

	void OnMouseDown()
	{
		Application.LoadLevel("Stage0"+level);
		State.Stage = level;
	}
}
