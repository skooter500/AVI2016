using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class SimpleSphere : MonoBehaviour
{
	private const int RESOLUTION = 40;
	private const float RADIUS = 5;

	private void Start()
	{
		var bounds = new Bounds(Vector3.zero, RADIUS * 2 * Vector3.one);

		Func<Vector3, float> scalarField = position => Vector3.Distance(position, Vector3.zero) - RADIUS;

		var geometry = new Geometry();
		geometry.AppendIsosurface(scalarField, bounds, RESOLUTION);
		var meshFilter = GetComponent<MeshFilter>();
		meshFilter.mesh = geometry.ConvertToMesh(meshFilter.mesh);
	}
}