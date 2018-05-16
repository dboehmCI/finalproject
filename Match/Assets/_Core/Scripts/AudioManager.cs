using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource BGM;

	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(gameObject);

        if(FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);
        }
	}
    private void Awake()
    {
       

    }

    // Update is called once per frame
    void Update () {
        
    }

    public void ChangeBGM(AudioClip music)
    {
        if (BGM.clip.name == music.name)
        {
            Debug.Log("Same Song");
            return;
        }
            

        BGM.Stop();
        BGM.clip = music;
        Debug.Log("Loaded New Track and Playing");
        BGM.Play();
        Debug.Log("Called to Play!");
    }
}
