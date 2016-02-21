using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour {
	public CarDatabase db;
//shop stuff
	public int vCurrentShop = 0;
	public GameObject DisplayCar;
	public GameObject ShopPos;
	
	void Awake()
	{
		db = GetComponent<CarDatabase>();
	}
	//triggered when coming into the shop
	public void ComingIn()
	{
		Display();
	}
	public void ShowNext()
	{
		if(vCurrentShop+1 < db.vAllCars.Count)
		{
			vCurrentShop++;
			
		}
		else
		{
			vCurrentShop = 0;
		}
		Display();
	}
	public void ShowPrev()
	{
		if(vCurrentShop-1 >= 0)
		{
			vCurrentShop--;
			
		}
		else
		{
			vCurrentShop = db.vAllCars.Count-1;
		}
		Display();
	}
	//displays the current car
	public void Display()
	{
		if(DisplayCar != null)
		{
			Destroy(DisplayCar);
		}
		DisplayCar = Instantiate(db.vAllCars[vCurrentShop].vShopCar) as GameObject;
		DisplayCar.transform.position = ShopPos.transform.position;
		DisplayCar.transform.parent = ShopPos.transform;
	}
}
