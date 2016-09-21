using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainUi : MonoBehaviour {

	PitchBendController pbc;

	public OVRRaycaster raycaster;
	public static float meshRotation;
	public Image uiImage;
	public Text uiText;
	public Transform light;
	public ScrollRect myScrollRect;

	[Range (0f,1f)] public float scrollRange;
	[Range (1f,3f)] public float zoomRange=1;

	public void Start()
	{
		pbc = GameObject.Find("GameController").GetComponent<PitchBendController>();
	
	}

	public void Update()
	{
		if (raycaster.highlightText) {
			//Change the current vertical scroll position.

			scrollRange += pbc.left / 1000;
			scrollRange -= pbc.right / 1000;
			myScrollRect.verticalNormalizedPosition = scrollRange;
		}
		if (raycaster.highlightGraph) {
			zoomRange += pbc.left / 1000;
			zoomRange -= pbc.right / 1000;
			uiImage.rectTransform.localScale = new Vector2(zoomRange, zoomRange);
		}
	}
}





