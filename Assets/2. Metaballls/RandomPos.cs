using UnityEngine;
using System.Collections;

public class RandomPos : MonoBehaviour {

	static int radius= 10;
	// Use this for initialization
	void Awake () {
		transform.localPosition = Random.insideUnitSphere * radius;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
