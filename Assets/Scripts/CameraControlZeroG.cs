/*
 * Copyright 2014 Jason Graves (GodLikeMouse/Collaboradev)
 * http://www.collaboradev.com
 *
 * This file is part of Unity - Topology.
 *
 * Unity - Topology is free software: you can redistribute it 
 * and/or modify it under the terms of the GNU General Public 
 * License as published by the Free Software Foundation, either 
 * version 3 of the License, or (at your option) any later version.
 *
 * Unity - Topology is distributed in the hope that it will be useful, 
 * but WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with Unity - Topology. If not, see http://www.gnu.org/licenses/.
 */

using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Move ZeroG")]
public class CameraControlZeroG : MonoBehaviour {


	public float speed = 5f;
	public GUIText movementSpeed;
	public Transform target;
	private Vector3 move = new Vector3();
	private Vector3 cluster1 = new Vector3(-20, 0, 0);
	private Vector3 cluster2 = new Vector3(42, 79, 54);
	private Vector3 cluster3 = new Vector3(92, 8, 26);
	private Vector3 cluster4 = new Vector3(31, 17, 76);
	private Vector3 cluster5 = new Vector3(87, 43, 9);

	void Start(){
		//set to first cluster position
		transform.position = cluster1;
	}
	
	void Update () {
		move.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		move.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		move.y = 0;
		if (Input.GetKey ("space")) {
			move.y = speed * Time.deltaTime;
		}

		if (Input.GetKey ("left ctrl")) {
			move.y = -speed * Time.deltaTime;
		}

		//adjust speed with mouse wheel
		speed += Input.GetAxis("Mouse ScrollWheel");
		if (speed < 5)
			speed = 5;

		movementSpeed.text = "Move Speed: " + speed;

		move = transform.TransformDirection(move);
		transform.position += move;

		//set warp to cluster controls
		if(Input.GetKey("1")){
			transform.position = cluster1;
			transform.LookAt(target);
		}

		if(Input.GetKey("2")){
			transform.position = cluster2;
			transform.LookAt(target);
		}

		if(Input.GetKey("3")){
			transform.position = cluster3;
			transform.LookAt(target);
		}

		if(Input.GetKey("4")){
			transform.position = cluster4;
			transform.LookAt(target);
		}

		if(Input.GetKey("5")){
			transform.position = cluster5;
			transform.LookAt(target);
		}
	}
}
