using UnityEngine;
using System.Collections;

public class MoveCamForward : MonoBehaviour 
{
	public float minZ = 0;
	public float maxZ = 10;
	public float speed = 1;
	private float z;

	void FixedUpdate () 
	{
		z = transform.localPosition.z;

		if (Input.GetKey ("x") && z > minZ)
			transform.Translate (new Vector3 (0, 0, speed * 0.01f), transform);

		else if (Input.GetKey ("z") && z < maxZ)
			transform.Translate (new Vector3 (0, 0, -speed * 0.01f), transform);
		
	}
}
