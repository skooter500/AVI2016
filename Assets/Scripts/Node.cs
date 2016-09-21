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
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Topology {

	public class Node : MonoBehaviour {

		public string id;
		public TextMesh nodeText;
		public CanvasGroup uiCanvas;
		public MainUi ui;
		public static Transform light;
		public float close;

		private MeshHolder meshArray;
		private TextHolder textArray;
		private ImageHolder imageArray;
		private AudioHolder soundArray;
		private GameObject avatar;
		private GameObject myMesh;
		private Text myDescription;
		private Image myImage;
		private SelectCubeRotate mySelector;

		public bool buttonDown=false;
		Quaternion OriginalRot;
		void Awake()
		{
			light = GameObject.Find("Directional light").transform;
			ui = GameObject.Find("Canvas").GetComponent<MainUi>();
			uiCanvas = GameObject.Find("Canvas").GetComponent<CanvasGroup>();
			avatar = GameObject.FindGameObjectWithTag ("Player");
			meshArray = GameObject.Find("MeshHolder").GetComponent<MeshHolder>();
			textArray = GameObject.Find("TextHolder").GetComponent<TextHolder>();
			soundArray =GameObject.Find("AudioHolder").GetComponent<AudioHolder>();
			imageArray = GameObject.Find("ImageHolder").GetComponent<ImageHolder>();
			myDescription = transform.Find("descriptionText").GetComponent<Text>();
			myImage=transform.Find("image").GetComponent<Image>();
			mySelector = gameObject.GetComponent<SelectCubeRotate> ();

		}

		void Start()
		{

			uiCanvas.alpha = 0;		
				
			switch (id) 
			{
			case "node_1":
				myMesh = Instantiate (meshArray.Meshes [0], new Vector3 (transform.position.x, transform.position.y+0.8f, transform.position.z), transform.rotation) as GameObject;
				myDescription.GetComponent<Text> ().text = textArray.TextDescription [0].text;
				myImage.GetComponent<Image> ().sprite = imageArray.Images [0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [0];
				break;
			case "node_2":
				myMesh=Instantiate( meshArray.Meshes[1],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[1].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[1];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [1];
				break;
			case "node_3":
				myMesh=Instantiate( meshArray.Meshes[2],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[1];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [2];
				break;
			case "node_4":
				myMesh=Instantiate( meshArray.Meshes[3],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[1].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[1];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [3];
				break;
			case "node_5":
				myMesh=Instantiate( meshArray.Meshes[4],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [4];
				break;
			case "node_6":
				myMesh=Instantiate( meshArray.Meshes[5],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[1].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[1];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [5];
				break;
			case "node_7":
				myMesh=Instantiate( meshArray.Meshes[6],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [6];
				break;
			case "node_8":
				myMesh=Instantiate( meshArray.Meshes[7],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[1].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [7];
				break;
			case "node_9":
				myMesh=Instantiate( meshArray.Meshes[8],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[1].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [8];
				break;
			case "node_10":
				myMesh=Instantiate( meshArray.Meshes[9],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[1];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [9];
				break;
			case "node_11":
				myMesh=Instantiate( meshArray.Meshes[10],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[1].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [9];
				break;
			case "node_12":
				myMesh=Instantiate( meshArray.Meshes[11],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [8];
				break;
			case "node_13":
				myMesh=Instantiate( meshArray.Meshes[12],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[1].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [7];
				break;
			case "node_14":
				myMesh=Instantiate( meshArray.Meshes[13],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[2];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [6];
				break;
			case "node_15":
				myMesh=Instantiate( meshArray.Meshes[14],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[1];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [5];
				break;
			case "node_16":
				myMesh=Instantiate( meshArray.Meshes[15],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [4];
				break;
			case "node_17":
				myMesh=Instantiate( meshArray.Meshes[16],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[2];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [3];
				break;
			case "node_18":
				myMesh=Instantiate( meshArray.Meshes[17],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [2];
				break;
			case "node_19":
				myMesh=Instantiate( meshArray.Meshes[18],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [1];
				break;
			case "node_20":
				myMesh=Instantiate( meshArray.Meshes[19],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[1];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [0];
				break;
			case "node_21":
				myMesh=Instantiate( meshArray.Meshes[20],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[2];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [1];
				break;
			case "node_22":
				myMesh=Instantiate( meshArray.Meshes[21],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [2];
				break;
			case "node_23":
				myMesh=Instantiate( meshArray.Meshes[22],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [3];
				break;
			case "node_24":
				myMesh=Instantiate( meshArray.Meshes[23],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[2];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [4];
				break;
			case "node_25":
				myMesh=Instantiate( meshArray.Meshes[24],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[1];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [5];
				break;
			case "node_26":
				myMesh=Instantiate( meshArray.Meshes[25],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [6];
				break;
			case "node_27":
				myMesh=Instantiate( meshArray.Meshes[26],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [7];
				break;
			case "node_28":
				myMesh=Instantiate( meshArray.Meshes[27],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[2];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [8];
				break;
			case "node_29":
				myMesh=Instantiate( meshArray.Meshes[28],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [9];
				break;
			case "node_30":
				myMesh=Instantiate( meshArray.Meshes[29],new Vector3(transform.position.x,transform.position.y+0.8f,transform.position.z), transform.rotation)as GameObject;
				myDescription.GetComponent<Text>().text=textArray.TextDescription[0].text;
				myImage.GetComponent<Image>().sprite=imageArray.Images[0];
				gameObject.GetComponent<AudioSource> ().clip = soundArray.sounds [0];
				break;

			}
			myMesh.transform.SetParent (transform);
			myMesh.tag = "VirusMesh";
			OriginalRot = myMesh.transform.rotation;
		}

		void Update () {
			//node text always facing camera
			nodeText.transform.LookAt (Camera.main.transform);
			close = Vector3.Distance(transform.position,avatar.transform.position);
	
			if (close < 4f) {

				nodeText.fontSize = 20;

				if (Input.GetButtonDown ("Fire2")) {
					buttonDown = !buttonDown;
				}
				if(buttonDown&&mySelector.selected)
				{

						ui.uiImage.sprite = myImage.sprite;
						ui.uiText.text = myDescription.text;
						uiCanvas.alpha = 1;
						uiCanvas.gameObject.transform.position = myMesh.transform.position;
						uiCanvas.gameObject.transform.SetParent(transform,false);
						uiCanvas.gameObject.transform.LookAt (avatar.transform);
						Vector3 uiRotation = new Vector3 (0, uiCanvas.gameObject.transform.rotation.eulerAngles.y, uiCanvas.gameObject.transform.rotation.eulerAngles.z);
						uiCanvas.gameObject.transform.eulerAngles = uiRotation;
				} 
				else 
				{
					uiCanvas.alpha = 0;
				}
				
			}
			if (close > 3f)
			{
				buttonDown=false;
				nodeText.fontSize = 100;
				//uiCanvas.alpha = 0;
			}
		}
	}
}

