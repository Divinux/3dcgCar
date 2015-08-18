using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Team : MonoBehaviour {

	//one list for owned and enemy cars each
	public List<GameObject> vCars = new List<GameObject>();
	public List<GameObject> vEnemyCars = new List<GameObject>();
	//currently selected car
	public int vCurrent = 0;
	//distance the car moves per order
	public int vDistance = 5;
	
	//object that slides the camera along
	public CamSlider slider;
	//lookat component on the camera rig
	public LookAt la;
	
	//target position indicator objects
	public GameObject vPosIndX;
	public GameObject vPosIndY;
	
	
	Vector3 t = new Vector3(0,0,0);
	RPGCar cs;
	//function for car selection buttons
	public void Select(int i) 
	{
		vCurrent = i;
		slider.vTarget = vCars[vCurrent];
		la.vTarget = vCars[vCurrent].transform;
		cs = vCars[vCurrent].GetComponent<RPGCar>();
	}
	
	//functions that give cars orders
	public void Right()
	{
		cs.MoveTo(cs.TargetX + 5, cs.TargetY);
	}
	public void Left()
	{
		cs.MoveTo(cs.TargetX - 5, cs.TargetY);
	}
	public void Forward()
	{
		cs.MoveTo(cs.TargetX, cs.TargetY+10);
	}
	public void Back()
	{
		cs.MoveTo(cs.TargetX, cs.TargetY-10);
	}
	
	//updates target position indicators
	void UpdateIndicators()
	{
		if(cs == null)
		{
			Select(vCurrent);
		}
		
		t = new Vector3(cs.TargetX,0,0);
		vPosIndX.transform.position = t;
		//Debug.Log(vPosIndX.transform.position);
		t = new Vector3(0,0,cs.TargetY);
		vPosIndY.transform.position = t;
	}
	
	void Update()
	{	
	UpdateIndicators();
	
	}
}
