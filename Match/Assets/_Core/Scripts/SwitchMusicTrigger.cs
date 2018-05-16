using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour {

    public AudioClip newTrack;
    private AudioManager theAM;

	// Use this for initialization
	void Start () {
        //theAM = FindObjectOfType<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUpAsButton()
    {
        if (newTrack  != null)
        {
            theAM = FindObjectOfType<AudioManager>();
            theAM.ChangeBGM(newTrack);
        }
    }
}
