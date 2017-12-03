using UnityEngine;
using System.Collections;

public static class Vector2Ex
{
	public static Vector2 Rotate(Vector2 v, float d)
	{
		float sin = Mathf.Sin(d * Mathf.Deg2Rad);
		float cos = Mathf.Cos(d * Mathf.Deg2Rad);

		float vx = v.x;
		float vy = v.y;
		v.x = (cos * vx) - (sin * vy);
		v.y = (sin * vx) + (cos * vy);

		return v;
	}
}

