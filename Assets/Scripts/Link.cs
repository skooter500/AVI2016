using UnityEngine;
using System.Collections;

namespace Topology {
	
	public class Link: MonoBehaviour {


		public string id;
		public Node source;
		public Node target;

		public GameObject start;
		public GameObject end;
		public GameObject knot;
		public string sourceId;
		public string targetId;
		public string status;
		public bool loaded = false;
		
		void Awake ()
		{

		}
		
		void Start () {

//			start=transform.Find("start").gameObject;
//			end=transform.Find("end").gameObject;
//			knot=transform.Find("knot").gameObject;
			//color link according to status
			Color c;
			if (status == "Up")
				c = Color.gray;
			else
				c = Color.red;
			c.a = 0.5f;
			
			//draw line
			if(source && target && !loaded){
				//draw links as full duplex, half in each direction
				transform.position=	source.transform.position;			
				Vector3 midpointPosition = (source.transform.position-target.transform.position)/2 + source.transform.position;
				start.transform.position= source.GetComponent<Collider>().ClosestPointOnBounds(midpointPosition);
				end.transform.position= target.GetComponent<Collider>().ClosestPointOnBounds(midpointPosition);

				knot.transform.position =GameController.nodeCenter.GetComponent<Collider>().ClosestPointOnBounds(midpointPosition);
//				knot.transform.position=GameController.edgeCenter;
//				knot.transform.position= (target.transform.position - source.transform.position)/2 + source.transform.position;
				loaded = true;
			}
			

			//lineRenderer.SetPosition(2, new Vector3(0,1,0));
		}
		
		void Update () {
//			if(source && target && !loaded){
//				//draw links as full duplex, half in each direction
//				transform.position=	source.transform.position;			
//				start.transform.position= source.transform.position;
//				end.transform.position= target.transform.position;
//				knot.transform.position = (target.transform.position - source.transform.position)/2 + source.transform.position;
//								
//				loaded = true;
//			}
		}
	}
	
}
