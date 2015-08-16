using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour 
{

	public float shake = 0f;
	public float shakeAmount = 0.2f;
	public float decreaseFactor = 1f;
	
	public bool infinite = true;
	// Update is called once per frame
	void Update () 
	{
		if (shake > 0|| infinite) 
		{
			transform.localPosition = Random.insideUnitSphere * shakeAmount;
			if(!infinite)
			{
			shake -= Time.deltaTime * decreaseFactor;
			}
		} 
		else 
		{
			shake = 0.0f;
		}
	}
}
