using UnityEngine;
using System.Collections;

public class SelectObject : MonoBehaviour {

	static private Transform trSelect = null; 
	public bool selected = false;

	void Update () {

		if (selected && transform != trSelect) {
			selected = false;
		}

	}

	public void OnMouseDown(){
		selected = true;
		trSelect = transform;
	}
}
