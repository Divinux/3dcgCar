using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadingScreen : MonoBehaviour {
	public string Levelname = "MainMenu";
	public Image loopy;
	
	public void Awake()
	{
		//Debug.Log("start loading screen");
		Levelname = PlayerPrefs.GetString("toload");
		//Debug.Log("pref loaded: " + Levelname);
		if(Levelname == "")
		{
			Levelname = "MainMenu";
		}
		
		StartCoroutine(Loada());
		//Debug.Log("end cor");
	}
	
    IEnumerator Loada() 
	{
		//
        AsyncOperation async = Application.LoadLevelAsync(Levelname);
		loopy.fillAmount = async.progress;
		Debug.Log(async.progress);
        yield return async;
        //Debug.Log("Loading complete");
    }
}