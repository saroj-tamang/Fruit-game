using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
	//public static AudioManager instance;
	public Sound[] sounds;
//	public AudioClip[]audiolist;
//	List<AudioSource>Asource=new List<AudioSource>();
	/*public static AudioManager Instance
	{
		get{
			if(instance==null){
				instance=FindObjectOfType<AudioManager>();
				if(instance==null){
					instance=new GameObject("Spawned AudioManager",typeof(AudioManager)).GetComponent<AudioManager>();
				}

			}

		}
		private set{
			instance=value;
		}

	}
	*/
	void Awake(){
		// if(instance==null){
		// 	instance=this;
		// }

		 foreach(Sound s in sounds){
		 	s.source=gameObject.AddComponent<AudioSource>();
		 	s.source.clip=s.clip;
		 	s.source.volume=s.volume;
		 	s.source.pitch=s.pitch;
			s.source.loop=s.loop;
		 }

	}
    // Start is called before the first frame update
    void Start()
    {
		// for(int i=0;i<audiolist.Length;i++){
		// 	Asource.Add(new AudioSource());
		// 	Asource[i]=gameObject.AddComponent<AudioSource>();
		// 	Asource[i].clip=audiolist[i];

		// }
		// Asource[1].Play();
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	 public void Play(string name){
	 Sound s=Array.Find(sounds,sound=>sound.Name==name);
	 s.source.Play();
	 }

	//  public void AudioPlay(int s){
	//  	Asource[s].Play();
	// }
}
