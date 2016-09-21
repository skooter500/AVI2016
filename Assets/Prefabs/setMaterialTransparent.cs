using UnityEngine;
using System.Collections;

public class setMaterialTransparent : MonoBehaviour {
	public Material material;
	// Use this for initialization
	void Start () {


		material.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Front);
		//material.SetFloat("_Mode", 2);
//		material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
//		material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
//		material.SetInt("_ZWrite", 0);
//		material.DisableKeyword("_ALPHATEST_ON");
//		material.EnableKeyword("_ALPHABLEND_ON");
//		material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
//		material.renderQueue = 3000;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
