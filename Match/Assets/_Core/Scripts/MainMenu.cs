using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    public Image Black;

    [SerializeField] private float delay = 1f;
    public string level;

    //function to be called on button click
    public void LoadNextLevel(string level)
    {
        StartCoroutine(LevelLoad(level));
        SceneManager.LoadScene(1);
    }

    //load level after one sceond delay
    IEnumerator LevelLoad(string name)
    {

        float elapsedTime = 0;
        float currentVolume = AudioListener.volume;

      
        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            AudioListener.volume = Mathf.Lerp(currentVolume, 0, elapsedTime / delay);
        }

        // fade out the game and load a new level
        float fadeTime = GameObject.Find("_GM").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        
        
        
    }


    public void OnMouseOver()
    {
        FindObjectOfType<AudioM>().Play("HoverOver");
    }

}




