using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour {
	private Vector3 compare;

	void Start()
	{
		compare = new Vector3 (30,30,30);
	}
	
	// Update is called once per frame
	void Update () 
	{		
		transform.localScale += new Vector3(0.1f,0.1f,0.1f);

		if (V3Equal(transform.localScale, compare))
		{
			transform.localScale = new Vector3(0.2f,0.2f,0.2f);
		}
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Node") {
			
			other.gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
	public bool V3Equal(Vector3 a, Vector3 b){
		return Vector3.SqrMagnitude(a - b) < 0.1;
	}

}
