using UnityEngine;
using System.Collections;

public class OVRRaycaster : MonoBehaviour {
	PitchBendController pbc;
	public bool highlightText=false;
	public bool highlightGraph=false;
	public bool highlightLight=false;
	public bool highlightMeta=false;
	// Use this for initialization
	void Start () {
		pbc = GameObject.Find("GameController").GetComponent<PitchBendController>();
	}
	
	// Update is called once per frame
	void Update () {
		int sightlength = 500;
		RaycastHit seen;
		Ray raydirection = new Ray(transform.position, transform.forward);
		if (Physics.Raycast (raydirection, out seen, sightlength)) {
			if (seen.collider.tag == "Node") { //in the editor, tag anything you want to interact with and use it here
				highlightText = false;
				highlightGraph = false;
				seen.transform.gameObject.GetComponent<SelectCubeRotate> ().highlight = true;
				SelectCubeRotate.trHighlight = seen.transform;

			}
			if (seen.collider.tag == "Text") { //in the editor, tag anything you want to interact with and use it here
				highlightText = true;
			}
					

			if (seen.collider.tag == "Graph") { //in the editor, tag anything you want to interact with and use it here
				highlightGraph = true;
			} 
			if (seen.collider.tag == "Light") { //in the editor, tag anything you want to interact with and use it here
				highlightLight = true;
			} 

			if (seen.collider.tag == "Metaball") { //in the editor, tag anything you want to interact with and use it here
				highlightMeta = true;
			} 





		} else {
			highlightText = false;
			highlightGraph = false;
			highlightLight = false;
			highlightMeta = false;
		}

	}
}
