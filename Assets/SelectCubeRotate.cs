using UnityEngine;
using System.Collections;

public class SelectCubeRotate : MonoBehaviour {
	PitchBendController pbc;
	public OVRRaycaster raycaster;
	static public Transform trHighlight = null; 
	static public Transform trSelect = null; 
	public bool highlight = false;
	public bool selected = false;


	[Range(0, 1)]
	public float scale = 1f;

	public Shader shader1;
	public Shader shader2;
	public Renderer rend;

	private Transform virusMesh;
	public Transform sunLight;
	public Transform meta;
		
	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			if (child.tag == "VirusMesh")
				virusMesh = child;
		}
		sunLight = GameObject.FindGameObjectWithTag ("Light").transform;
		meta = GameObject.FindGameObjectWithTag ("Metaball").transform;
		raycaster = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<OVRRaycaster> ();
		rend = GetComponent<Renderer>();
		shader1 = Shader.Find("Shader Forge/Rim");
		shader2 = Shader.Find("Diffuse");
		pbc = GameObject.Find("GameController").GetComponent<PitchBendController>();
	}

	void Update () 	{
		

		if (selected && transform != trSelect) {
			selected = false;
		}

		if (pbc.selector && highlight) {
			trSelect = transform;
			selected = true;
		}

		if (highlight) {
			rend.material.shader = shader1;
			rend.material.color = Color.blue;
		}

		if (highlight && transform != trHighlight) 
		{
			highlight = false;
		}

		if (selected ) {
			rend.material.color = Color.red;
			rend.material.shader = shader1;
			if(raycaster.highlightText==false&&raycaster.highlightGraph==false)
			{
				virusMesh.transform.Rotate (-Vector3.up, pbc.left * scale);
				virusMesh.transform.Rotate (Vector3.up, pbc.right * scale);
			}
		}


		if (!highlight && !selected) {	
			rend.material.shader = shader2;
			rend.material.color = Color.green;
		}

		if (raycaster.highlightLight)
		{
			selected = false;
			highlight = false;
			sunLight.transform.Rotate (-Vector3.right, pbc.left * scale*0.1f);
			sunLight.transform.Rotate (Vector3.right, pbc.right * scale*0.1f);
		}
		if (raycaster.highlightMeta)
		{
			selected = false;
			highlight = false;
			meta.parent.transform.Rotate (-Vector3.up, pbc.left * scale*0.1f);
			meta.parent.transform.Rotate (Vector3.up, pbc.right * scale*0.1f);
		}


	}


}



