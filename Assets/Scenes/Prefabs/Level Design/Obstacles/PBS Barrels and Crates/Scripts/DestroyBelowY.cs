using UnityEngine;
using System.Collections;

public class DestroyBelowY : MonoBehaviour 
{
	public float minY = 0;
	public float waitTime = 5;

	private WaitForSeconds wait;

	void Start()
	{
		wait = new WaitForSeconds (waitTime);
		StartCoroutine (SimpleCoroutine());
	}

	IEnumerator SimpleCoroutine()
	{
		while (true) 
		{
			if (transform.position.y < minY)
				Destroy (gameObject);

			// do nothing until wait time is over
			yield return wait;
		}
	}
}
