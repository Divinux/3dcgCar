using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadingScreen : MonoBehaviour {
	public string Levelname = "MainMenu";
	public Image loopy;
	public static AsyncOperation async;
	public void Awake()
	{
		//Debug.Log("start loading screen");
		Levelname = PlayerPrefs.GetString("toload");
		//Debug.Log("pref loaded: " + Levelname);
		if(Levelname == "")
		{
			Levelname = "MainMenu";
		}
		Debug.Log("strt cor");
		StartCoroutine(Loada());
		async.allowSceneActivation = true;
	}
	
    IEnumerator Loada()
	{
		
		async = Application.LoadLevelAsync(Levelname);
		async.allowSceneActivation = false;
		
        loopy.fillAmount = async.progress;
		Debug.Log(async.progress);
		
		yield return async;
		
    }
}