using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {
    public GameObject HowToMenu;
    public GameObject PlayMenu;
    public GameObject[] Images;
    public int index;
   

    // Use this for initialization
    void Start () {
        Images[index].SetActive(true);

	}
	
	// Update is called once per frame
	public void NextTutorial () {

        if (index < 4)
        {
            Images[index].SetActive(false);
            index += 1;
            Images[index].SetActive(true);
        }
        else
        {
            foreach (GameObject images in Images)
            {
                images.SetActive(false) ;
            }
            HowToMenu.SetActive(false);
            PlayMenu.SetActive(true);
            index = 0;
        }


    }
    private void Awake()
    {
        Images[index].SetActive(true);
        index = 0;
    }

    public void PreviousTutorial()
    {

        if (index > 0)
        {
            Images[index].SetActive(false);
            index -= 1;
            Images[index].SetActive(true);
        }
        else
        {
            foreach (GameObject images in Images)
            {
                images.SetActive(false);
            }
            HowToMenu.SetActive(false);
            PlayMenu.SetActive(true);
            index = 0;
        }


    }
}
