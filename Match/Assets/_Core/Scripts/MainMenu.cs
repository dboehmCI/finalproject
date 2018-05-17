using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    public Image Black;

    [SerializeField] private float delay = 100f;
    public string level;

    private float elapsedTime;
    private float currentVolume;

    //function to be called on button click
    public void LoadNextLevel(string level)
    {
        StartCoroutine(LevelLoad(level));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //load level after one sceond delay
    IEnumerator LevelLoad(string name)
    {

        currentVolume = AudioListener.volume;
        elapsedTime = 0;
        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
           AudioListener.volume = Mathf.Lerp(currentVolume, 0, elapsedTime / delay);
        }

        // fade out the game and load a new level
        float fadeTime = GameObject.Find("_GM").GetComponent<Fading>().BeginFade(1);
        elapsedTime = 0;
        yield return new WaitForSeconds(fadeTime);

    }


    public void OnMouseOver()
    {
        FindObjectOfType<AudioM>().Play("HoverOver");
    }

}




