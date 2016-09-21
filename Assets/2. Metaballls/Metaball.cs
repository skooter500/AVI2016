using UnityEngine;

public class Metaball : MonoBehaviour
{
	[Range(.1f, 10)]
	public float radius = 1;

	public Bounds GetBounds()
	{
		return new Bounds(transform.position, 20 * radius * Vector3.one);
	}
}