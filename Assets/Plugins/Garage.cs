using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

//created rotating shop object
//created shop spawn position

//gotta 
//move out car database into own script

public class Garage : MonoBehaviour 
{
	//general car stuff
	//list of all cars you can buy
	public CarDatabase db;
	//public List<Car> vAllCars = new List<Car>();
	

	//game loading stuff
	public string[] splitString;
	
	//garage stuff
	//currently selected car in garage
	public int vCurrent = 0;
	//list of cars you own
	public List<Car> vOwnCars = new List<Car>();
	//instances of own cars to be displayed in the shop
	public List<GameObject> vOwnDisplay = new List<GameObject>();
	//gameobjects of the garage positions
	public List<GameObject> vGaragePos = new List<GameObject>();
	//no need to assign this
	public List<Vector3> vGaragePosOriginal = new List<Vector3>();
	//UI stuff
	public GameObject ButtonShop;
	public GameObject ButtonGarage;
	public GameObject Camera;
	
	public GameObject PosGarage;
	public GameObject PosShop;
	
	[System.Serializable]
	public class Car 
	{
		public GameObject vShopCar;
		public GameObject vRaceCar;
		public CarStats vStats;
		public int vShopNumber = 0;
	}
	
	[System.Serializable]
	public class CarStats 
	{
		public string Name = "";
		public int Price = 1000;
		
		public int Level = 1;
		public int Exp = 0;
		public int ExpToLevel = 100;
		
		public int Speed = 200;
		public int Health = 100;
		public int Damage = 1;
	}
	
	void Awake()
	{
		db = GetComponent<CarDatabase>();
		//set original garage positions
		for(int a = 0; a < vGaragePosOriginal.Count; a++)
		{
			vGaragePosOriginal[a] = vGaragePos[a].transform.position;
			Debug.Log("setting");
		}
	}
	
	//moves all display cars in the garage to their positions
	public void GarageDisplayCar(int i)
	{
		MoveDisplayCar(i,0);
		switch (i)
		{
		case 0:
			MoveDisplayCar(1,1);
			MoveDisplayCar(2,2);
			break;
		case 1:
			MoveDisplayCar(2,1);
			MoveDisplayCar(0,2);
			break;
		case 2:
			MoveDisplayCar(0,1);
			MoveDisplayCar(1,2);
			break;
		}
	}
	//moves one own car to a specific position in the garage
	void MoveDisplayCar(int c, int p)
	{
		if(vOwnDisplay[c] != null)
		{
			vOwnDisplay[c].transform.position = vGaragePosOriginal[p];
		}
	}
	//instantiates all own display cars
	void InstDisplay()
	{
		LoadCar(0);
	}
	void LoadCar(int b)
	{
		string lKey = "Car" + b;
		string carl;
		if(PlayerPrefs.HasKey(lKey))
		{
			carl = PlayerPrefs.GetString(lKey);
			splitString = carl.Split(new string[]{"&"}, StringSplitOptions.None);
			
			vOwnCars[b] = new Car();
			int temp = int.Parse(splitString[1]);
			vOwnCars[b].vShopCar = db.vAllCars[temp].vShopCar;
			vOwnCars[b].vRaceCar = db.vAllCars[temp].vRaceCar;
			vOwnCars[b].vShopNumber = temp;
			vOwnCars[b].vStats.Name = splitString[2];
			vOwnCars[b].vStats.Price = int.Parse(splitString[3]);
			vOwnCars[b].vStats.Level = int.Parse(splitString[4]);
			vOwnCars[b].vStats.Exp = int.Parse(splitString[5]);
			vOwnCars[b].vStats.ExpToLevel = int.Parse(splitString[6]);
			vOwnCars[b].vStats.Speed = int.Parse(splitString[7]);
			vOwnCars[b].vStats.Health = int.Parse(splitString[8]);
			vOwnCars[b].vStats.Damage = int.Parse(splitString[9]);
			
			vOwnDisplay[b] = Instantiate(vOwnCars[b].vShopCar, transform.position, transform.rotation) as GameObject;
		}
	}
	void SaveCar(int a)
	{
		if(vOwnCars[a].vShopCar != null)
		{
			string carst = a + "&" 
			+ vOwnCars[a].vShopNumber + "&" 
			+ vOwnCars[a].vStats.Name + "&" 
			+ vOwnCars[a].vStats.Price + "&"
			+ vOwnCars[a].vStats.Level + "&"
			+ vOwnCars[a].vStats.Exp + "&"
			+ vOwnCars[a].vStats.ExpToLevel + "&"
			+ vOwnCars[a].vStats.Speed + "&"
			+ vOwnCars[a].vStats.Health + "&"
			+ vOwnCars[a].vStats.Damage;
			string sKey = "Car" + a;
			PlayerPrefs.SetString(sKey, carst);
		}
		
	}
	//shop and garage buttons
	public void GotoShop()
	{
		ButtonShop.SetActive(false);
		ButtonGarage.SetActive(true);
		
		Camera.transform.position = PosShop.transform.position;
	}
	public void GotoGarage()
	{
		ButtonShop.SetActive(true);
		ButtonGarage.SetActive(false);
		
		Camera.transform.position = PosGarage.transform.position;
	}
}
