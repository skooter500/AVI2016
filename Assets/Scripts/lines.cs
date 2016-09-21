using UnityEngine;
using System.Collections;

[ExecuteInEditMode()] //EquivalenttoJS@scriptExecuteInEditMode()
public class lines : MonoBehaviour
{
	
	public GameObject start, control, end;
	public int numberOfPoints = 20;
	private LineRenderer lineRenderer;
	private Vector3 p0, p1, p2;
	
	//Usethisforinitialization
	void Start ()
	{
		//Getthelinerendererattachtedtothescript
		lineRenderer = GetComponent<LineRenderer>();
		
	}
	
	//Updateiscalledonceperframe
	void Update ()
	{
		if (numberOfPoints > 0)
		{
			lineRenderer.SetVertexCount(numberOfPoints); //Be sure to match the vertex count to the points
		}
		
		p0 = start.transform.position;
		p1 = control.transform.position; //The control point helps shape the curve
		p2 = end.transform.position;
		
		for(int i = 0; i < numberOfPoints; i++)
		{
			float t = (float)i / (float)(numberOfPoints - 1);
			
			//http://en.wikibooks.org/wiki/Cg_Programming/Unity/Bézier_Curves
			//B(t) = (1-t)2 * p0 + 2(1-t)* t * p1 + t^2 * p2
			//Be sure to check your Vector3 axis
			Vector3 position = (1.0F - t) * (1.0F - t) * new Vector3(p0.x,p0.y,p0.z)
				+ 2.0F * (1.0F - t) * t * new Vector3(p1.x,p0.y,p1.z)
					+ t * t * new Vector3(p2.x,p0.y,p2.z);
			
			lineRenderer.SetPosition(i,position); //Assign each new position via for loop
		}
		
	}
	
}