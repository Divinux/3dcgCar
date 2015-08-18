using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour 
{
	public GameObject vTarget;
	public GameObject vBarrel;
	public float speed = 1f;
	
	Vector3 vTargetDir = new Vector3(0,0,0);
	Vector3 newDir = new Vector3(0,0,0);
	float step;
	
	void Start () {
		
	}
	
	void Update () 
	{
		Target();
	}
	
	//look at the target car
	void Target()
	{
		if(vTarget != null)
		{
			step = speed * Time.deltaTime;
			vTargetDir = vTarget.transform.position - transform.position;
			newDir = Vector3.RotateTowards(vBarrel.transform.forward, vTargetDir, step, 0.0F);
			vBarrel.transform.rotation = Quaternion.LookRotation(newDir);
		}
	}
}
