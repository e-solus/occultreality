using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;
	[System.Serializable]

	public class SoundGroup{
		public string soundName;
		public AudioClip audioClip;
	}

	public List<SoundGroup> sound_List = new List<SoundGroup>();
	public AudioSource bgSound;

	// Use this for initialization
	public void Start(){
		instance = this;	
		
	}
	
	public void PlaySound(string _soundName){
		bgSound.PlayOneShot(sound_List[FindSound(_soundName)].audioClip);
	}
	
	private int FindSound(string _soundName){
		int i = 0;
		while( i < sound_List.Count ){
			if(sound_List[i].soundName == _soundName){
				return i;	
			}
			i++;
		}
		return i;
	}
	
}
