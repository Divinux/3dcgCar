using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Team : MonoBehaviour {

	public List<GameObject> vCars = new List<GameObject>();
	public int vCurrent = 0;
	//distance the car moves per order
	public int vDistance = 5;
	
	public CamSlider slider;
	public LookAt la;
	//function for car selection buttons
	public void Select(int i) 
	{
		vCurrent = i;
		slider.vTarget = vCars[vCurrent];
		la.vTarget = vCars[vCurrent].transform;
	}
	
	//functions that give cars orders
	public void Right()
	{
		RPGCar cs = vCars[vCurrent].GetComponent<RPGCar>();
		cs.MoveTo(cs.TargetX + 5, cs.TargetY);
	}
	public void Left()
	{
		RPGCar cs = vCars[vCurrent].GetComponent<RPGCar>();
		cs.MoveTo(cs.TargetX - 5, cs.TargetY);
	}
	public void Forward()
	{
		RPGCar cs = vCars[vCurrent].GetComponent<RPGCar>();
		cs.MoveTo(cs.TargetX, cs.TargetY+10);
	}
	public void Back()
	{
		RPGCar cs = vCars[vCurrent].GetComponent<RPGCar>();
		cs.MoveTo(cs.TargetX, cs.TargetY-10);
	}
}
