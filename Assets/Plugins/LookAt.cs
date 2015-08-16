using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public Transform vTarget;
	
	// Update is called once per frame
	void Update () 
	{
		if(vTarget != null)
		{
		transform.LookAt(vTarget);
		}
	}
}
