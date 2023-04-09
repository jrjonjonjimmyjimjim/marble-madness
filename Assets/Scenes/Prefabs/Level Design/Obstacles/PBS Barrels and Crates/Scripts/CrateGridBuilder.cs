using UnityEngine;
using System.Collections;

public class CrateGridBuilder : MonoBehaviour 
{
	public GameObject cratePrefab;
	public Vector3 XYZCount;
	public float length;
	public float width;
	public float height;
	public Vector3 XYZOffset;

	void Start () 
	{
		for (int x = 0; x < XYZCount.x; x++)
		{
			for (int y = 0; y < XYZCount.y; y++) 
			{
				for (int z = 0; z < XYZCount.z; z++) 
				{
					Instantiate (cratePrefab, 
						new Vector3(
						width * x + XYZOffset.x, 
						height * y + XYZOffset.y, 
						length * z + XYZOffset.z),
						Quaternion.identity);
				}
			}
		}
	}
}
