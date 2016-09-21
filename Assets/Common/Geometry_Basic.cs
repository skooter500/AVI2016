using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class Geometry
{
	public readonly List<Vector3> vertices;
	public readonly List<Vector3> normals;
	public readonly List<Color32> colors;
	public readonly List<Vector2> uvs;
	public readonly List<int> indices;

	public Geometry()
	{
		vertices = new List<Vector3>(500);
		normals = new List<Vector3>(500);
		colors = new List<Color32>(500);
		uvs = new List<Vector2>(500);
		indices = new List<int>(500);
	}

	public Geometry(Mesh unityMesh)
	{
		vertices = new List<Vector3>(unityMesh.vertices);
		normals = new List<Vector3>(unityMesh.normals);
		colors = new List<Color32>(unityMesh.colors32);
		uvs = new List<Vector2>(unityMesh.uv);
		indices = new List<int>(unityMesh.triangles);
	}

	public bool IsEmpty()
	{
		return vertices.Count == 0;
	}

	public void Clear()
	{
		vertices.Clear();
		normals.Clear();
		colors.Clear();
		uvs.Clear();
		indices.Clear();
	}

	public static Mesh ConvertToSubmeshes(IList<Geometry> geometries, Mesh meshToReuse = null)
	{
		if (geometries == null || geometries.Count == 0)
		{
			throw new Exception("There are no meshes to combine.");
		}

		var vertices = new List<Vector3>();
		var uvs = new List<Vector2>();
		var normals = new List<Vector3>();
		var colors = new List<Color32>();
		var tangents = new List<Vector4>();

		foreach (var geometry in geometries)
		{
			vertices.AddRange(geometry.vertices);
			uvs.AddRange(geometry.uvs);
			normals.AddRange(geometry.normals);
			colors.AddRange(geometry.colors);
			tangents.AddRange(geometry.CalculateTangents());
		}

		if (meshToReuse != null)
		{
			meshToReuse.Clear(true);
		}
		else
		{
			meshToReuse = new Mesh();
		}

		meshToReuse.vertices = vertices.ToArray();
		meshToReuse.uv = uvs.ToArray();
		meshToReuse.normals = normals.ToArray();
		meshToReuse.colors32 = colors.ToArray();
		meshToReuse.tangents = tangents.ToArray();
		meshToReuse.subMeshCount = geometries.Count;

		int vertexShift = 0;
		for (int submeshIndex = 0; submeshIndex < geometries.Count; submeshIndex++)
		{
			var geometry = geometries[submeshIndex];

			var indices = geometry.indices.Select(t => t + vertexShift).ToArray();
			meshToReuse.SetTriangles(indices, submeshIndex);

			vertexShift += geometry.vertices.Count;
		}
		meshToReuse.Optimize();

		return meshToReuse;
	}

	public static Geometry Combine(IList<Geometry> geometries)
	{
		if (geometries == null || geometries.Count == 0)
		{
			throw new Exception("There are no meshes to combine.");
		}
		var result = new Geometry();

		foreach (var geometry in geometries)
		{
			result.vertices.AddRange(geometry.vertices);
			result.uvs.AddRange(geometry.uvs);
			result.normals.AddRange(geometry.normals);
			result.colors.AddRange(geometry.colors);
		}

		int vertexShift = 0;
		foreach (var geometry in geometries)
		{
			int shift = vertexShift;
			var indices = geometry.indices.Select(t => t + shift);
			result.indices.AddRange(indices);

			vertexShift += geometry.vertices.Count;
		}

		return result;
	}

	public Mesh ConvertToMesh(Mesh meshToReuse = null, bool colliderMesh = false)
	{
		try
		{
			if (meshToReuse != null)
			{
				meshToReuse.Clear();
			}
			else
			{
				meshToReuse = new Mesh();
			}

			meshToReuse.vertices = vertices.ToArray();
			meshToReuse.SetTriangles(indices.ToArray(), submesh: 0);

			if (colliderMesh == false)
			{
				meshToReuse.normals = normals.ToArray();
				meshToReuse.uv = uvs.ToArray();
				meshToReuse.colors32 = colors.ToArray();
				if (uvs.Count == vertices.Count)
				{
					meshToReuse.tangents = CalculateTangents();
				}
			}
			meshToReuse.Optimize();

			return meshToReuse;
		}
		catch
		{
			Debug.LogError(string.Format("Vertices: {0}, triangles: {1}", vertices.Count, indices.Count));
			throw;
		}
	}

	public void AppendGeometry(Vector3 offset, Geometry geometry)
	{
		AppendGeometry(offset, geometry.vertices, geometry.normals, geometry.uvs, geometry.colors, geometry.indices);
	}

	#region Protected

	protected Vector4[] CalculateTangents()
	{
		int triangleCount = indices.Count;
		int vertexCount = vertices.Count;

		var tan1 = new Vector3[vertexCount];
		var tan2 = new Vector3[vertexCount];

		var tangents = new Vector4[vertexCount];

		for (int a = 0; a < triangleCount; a += 3)
		{
			int i1 = indices[a + 0];
			int i2 = indices[a + 1];
			int i3 = indices[a + 2];

			var v1 = vertices[i1];
			var v2 = vertices[i2];
			var v3 = vertices[i3];

			var w1 = uvs[i1];
			var w2 = uvs[i2];
			var w3 = uvs[i3];

			float x1 = v2.x - v1.x;
			float x2 = v3.x - v1.x;
			float y1 = v2.y - v1.y;
			float y2 = v3.y - v1.y;
			float z1 = v2.z - v1.z;
			float z2 = v3.z - v1.z;

			float s1 = w2.x - w1.x;
			float s2 = w3.x - w1.x;
			float t1 = w2.y - w1.y;
			float t2 = w3.y - w1.y;

			float r = 1.0f / (s1 * t2 - s2 * t1);

			var sdir = new Vector3((t2 * x1 - t1 * x2) * r, (t2 * y1 - t1 * y2) * r, (t2 * z1 - t1 * z2) * r);
			var tdir = new Vector3((s1 * x2 - s2 * x1) * r, (s1 * y2 - s2 * y1) * r, (s1 * z2 - s2 * z1) * r);

			tan1[i1] += sdir;
			tan1[i2] += sdir;
			tan1[i3] += sdir;

			tan2[i1] += tdir;
			tan2[i2] += tdir;
			tan2[i3] += tdir;
		}

		for (int a = 0; a < vertexCount; ++a)
		{
			var n = normals[a];
			var t = tan1[a];

			var tmp = (t - n * Vector3.Dot(n, t)).normalized;
			tangents[a] = new Vector4(tmp.x, tmp.y, tmp.z);
			tangents[a].w = Vector3.Dot(Vector3.Cross(n, t), tan2[a]) < 0.0f ? -1.0f : 1.0f;
		}

		return tangents;
	}

	protected int AppendGeometry(
		Vector3 offset,
		IEnumerable<Vector3> extraVertices,
		IEnumerable<Vector3> extraNormals,
		IEnumerable<Vector2> extraUvs,
		IEnumerable<Color32> extraLightings,
		IEnumerable<int> extraIndices)
	{
		int v = vertices.Count;

		foreach (var vertex in extraVertices)
		{
			vertices.Add(offset + vertex);
		}

		colors.AddRange(extraLightings);
		normals.AddRange(extraNormals);
		uvs.AddRange(extraUvs);

		foreach (int triangle in extraIndices)
		{
			indices.Add(v + triangle);
		}

		return v;
	}

	#endregion
}