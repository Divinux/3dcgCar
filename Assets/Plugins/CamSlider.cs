using UnityEngine;
using System.Collections;

public class CamSlider : MonoBehaviour {

	public GameObject vTarget;
	Vector3 v = new Vector3(0,0,0);
	// Update is called once per frame
	void Update () 
	{
	v = transform.position;
	v.z = vTarget.transform.position.z;
	transform.position = v;
	}
}
