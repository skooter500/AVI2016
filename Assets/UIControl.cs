using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {

	private bool showCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up")) {
			print ("up");
		}
		if (Input.GetMouseButtonDown(2) ) {
			showCanvas=!showCanvas;
		}
		if (showCanvas)
			gameObject.GetComponentInChildren<CanvasGroup> ().alpha = 1f;
		else
			gameObject.GetComponentInChildren<CanvasGroup> ().alpha = 0f;
	}
}
