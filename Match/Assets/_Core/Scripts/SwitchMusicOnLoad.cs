using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour {

    public AudioClip newTrack;
    private AudioManager theAM;
    private float elapsedTime;
    private float currentVolume;
    private float delay = 8;

    // Use this for initialization
    void Start () {
        theAM = FindObjectOfType<AudioManager>();

        if(newTrack != null)
        theAM.ChangeBGM(newTrack);
	}

    private void Awake()
    {
        AudioListener.volume = 0;
       
    }
    // Update is called once per frame
    void Update () {

        if (AudioListener.volume!= 1)
        {
            AudioListener.volume += 0.1f * Time.deltaTime;
        }
      
        }

}
