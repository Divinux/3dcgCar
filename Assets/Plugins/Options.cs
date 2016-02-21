using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Options : MonoBehaviour {

	public GameObject panelOptions;
	public GameObject logo;
	public Slider sliderMusic;
	float musicVolume = 0f;
	public GameObject musicPlayer;
	public AudioSource asrc;
	
	void Awake()
	{
		
		musicPlayer = GameObject.FindWithTag("MP");
		asrc = musicPlayer.GetComponent<AudioSource>();
		if(PlayerPrefs.HasKey("MusicVolume"))
	 {
		 musicVolume = PlayerPrefs.GetFloat("MusicVolume");
		 sliderMusic.value = musicVolume;
	 }
	 panelOptions.SetActive(false);
	}
	public void ChangeMusicVol() 
	{
	musicVolume = sliderMusic.value;
	PlayerPrefs.SetFloat("MusicVolume", musicVolume);
	if(asrc != null)
	{
		asrc.volume = musicVolume;
	}
	}
	
	// Update is called once per frame
	public void OptionsOpen () 
	{
	panelOptions.SetActive(true);
	logo.SetActive(false);
	}
}
