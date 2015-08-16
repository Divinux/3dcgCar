using UnityEngine;
using System.Collections;

using System.Collections.Generic;
public class CamChanger : MonoBehaviour {

	public List<GameObject> vPositions = new List<GameObject>();
	public Camera vCamera;
	public int vCurrent = 0;
	// Update is called once per frame
	public void Change() 
	{
		if(vCurrent == vPositions.Count-1)
		{
			vCurrent = 0;
		}
		else
		{
			vCurrent++;
		}
		vCamera.transform.parent.position = vPositions[vCurrent].transform.position;
	}
	
	void Update()
	{
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{if(vCamera.fieldOfView-3 > 0)
			{
			vCamera.fieldOfView -= 3;}
			
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			vCamera.fieldOfView += 3;
			if(vCamera.fieldOfView > 140)
			{
				vCamera.fieldOfView = 140;
			}
		}
	}
}
