using System;
using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Metaballs : MonoBehaviour
{
	[Range(0f, 10f)]
	public float threshold = 5;

	[Range(1, 100)]
	public int resolution = 80;

	[Range(0, 50)]
	public float rebuildRate = 5f;

	[Range(1f, 5f)]
	public float volumeSize = 5;
	[Range(.01f, 1)]
	public float frequency = .1f;
	public bool isFreezed = false;

	private Func<Vector3, float> scalarField;
	private MeshFilter meshFilter;
	private new Transform transform;
	private Geometry geometry;

	private void Awake()
	{
		scalarField = position =>
			{
				float sum = 0;
				foreach (var ball in transform.GetComponentsInChildren<Metaball>())
				{
					sum += ball.radius / Vector3.Distance(position, ball.transform.position);
				}
				return threshold - sum;
			};

		meshFilter = GetComponent<MeshFilter>();
		transform = GetComponent<Transform>();
		geometry = new Geometry();

		StartCoroutine(RebuildGeometry());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	private void Update()
	{
		if (isFreezed)
		{
			return;
		}

		var childCount = transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			var time = Time.time * frequency * Mathf.Pow(1.1f, i);
			var x = volumeSize * (Mathf.PerlinNoise(time + i * 2, time + i * 3) - .5f);
			var y = volumeSize * (Mathf.PerlinNoise(time + i * 4, 0) - .5f);
			var z = volumeSize * (Mathf.PerlinNoise(0, time + i * 5) - .5f);

			transform.GetChild(i).position = new Vector3(x, y, z);
		}

		//Camera.main.transform.LookAt(GetComponent<Renderer>().bounds.center);
	}

	private IEnumerator RebuildGeometry()
	{
//		while (Application.isPlaying)
//		{
			yield return new WaitForSeconds(0.5f);
			geometry.Clear();

			var balls = transform.GetComponentsInChildren<Metaball>().ToArray();
			if (balls.Any())
			{
				var metaballBounds = balls[0].GetBounds();
				for (int i = 1; i < balls.Length; i++)
				{
					metaballBounds.Encapsulate(balls[i].GetBounds());
				}

				geometry.AppendIsosurface(scalarField, metaballBounds, resolution);
			}
			meshFilter.mesh = geometry.ConvertToMesh(meshFilter.mesh);

			yield return new WaitForSeconds(rebuildRate);
//		}
	}
}