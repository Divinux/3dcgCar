using UnityEngine;
using System.Collections;

public class DustEnabler : MonoBehaviour 
{

public ParticleSystem particles;
 
	void Update () 
	{
	if(transform.position.y >= 0.5f)
	{
		particles.Stop(true);
	}
	else
	{
		particles.Play(true);
	}
	}
}
