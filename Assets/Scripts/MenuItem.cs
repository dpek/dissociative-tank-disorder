using UnityEngine;
using System.Collections;

public class MenuItem : MonoBehaviour {

	public string level;

	void OnMouseDown()
	{
		Application.LoadLevel(level);
	}
}
