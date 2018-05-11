using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    public Image Black;
    public Animator anim;

    [SerializeField] private float delay = 1f;
    public string level;

    //function to be called on button click
    public void LoadNextLevel(string level)
    {
        StartCoroutine(LevelLoad(level));
    }

    //load level after one sceond delay
    IEnumerator LevelLoad(string name)
    {

        StartCoroutine(Fading());
        float elapsedTime = 0;
        float currentVolume = AudioListener.volume;

      
        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            AudioListener.volume = Mathf.Lerp(currentVolume, 0, elapsedTime / delay);
        }
       

        yield return null;
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(3);
        anim.SetBool("Fade", false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(level);
    }

    public void OnMouseOver()
    {
        FindObjectOfType<AudioM>().Play("HoverOver");
    }

}




