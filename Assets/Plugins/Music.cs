using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Music : MonoBehaviour {
	public List<Songs> songList = new List<Songs>();
  AudioSource asrc;
  
  public int vCurrent = 0;
  
	[System.Serializable]
	public class Songs 
	{
		public string name = "";
		public AudioClip song;
	}
	
	void Awake () {
	 DontDestroyOnLoad(gameObject);
	 asrc = GetComponent<AudioSource>();
	 StartAudio();
	}
	
	/*void OnLevelWasLoaded()
	{
		
		
	}*/
	
	void StartAudio()
	{
		asrc.Stop();
		asrc.clip = songList[vCurrent].song;
		asrc.Play();
		
		
		 if(vCurrent<=songList.Count-1)
		 {
			 vCurrent++;
		 }
		 else
		 {
			 vCurrent = 0;
		 }
		 
		Invoke("StartAudio",asrc.clip.length+0.1f);  
	}
}
