using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	//PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	public void LoadLvl(string a) 
	{
		PlayerPrefs.SetString("toload", a);
		//Debug.Log("pref set");
		Application.LoadLevel("Loading");
		//Debug.Log("changing to load scene");
	}
}