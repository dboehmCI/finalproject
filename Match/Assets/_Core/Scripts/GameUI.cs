using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MatchDot
{
   
    /// <summary>
    /// Updates the game's UI
    /// </summary>
    public class GameUI : MonoBehaviour
    {
        
        public Text dotsClearedLabel;

        public int dotsCleared;
        private float dotsClearedLerp;
        public AudioSource dotsScored;
        public AudioSource LevelComplete;
        public int temp;
        public bool soundPlayed;
        public bool LevelSoundPlayed;
        private float delay;
        public Canvas LevelStatus;
        public int currLevel;


        private void Update()
        {


            if (currLevel == 1)
            {
                if (dotsCleared >= 10)
                {
                    LevelStatus.gameObject.SetActive(true);
                    if (LevelSoundPlayed == false)
                    {
                        LevelComplete.Play();
                        LevelSoundPlayed = true;
                        Debug.Log("I played");
                    }
                }
            }
            else if (currLevel == 2)
            {
                
                if (dotsCleared >= 20)
                {
                    LevelStatus.gameObject.SetActive(true);
                    if (LevelSoundPlayed == false)
                    {
                        LevelComplete.Play();
                        LevelSoundPlayed = true;
                        Debug.Log("I played");
                    }
                }
            }
            else if (currLevel == 3)
            {
                
                if (dotsCleared > 30)
                {
                    LevelStatus.gameObject.SetActive(true);
                    if (LevelSoundPlayed == false)
                    {
                        LevelComplete.Play();
                        LevelSoundPlayed = true;
                        Debug.Log("I played");
                    }
                }
            }
                // Could be more efficient using events, but good enough
                dotsClearedLerp = Mathf.Lerp(dotsClearedLerp, Game.get.session.dotsCleared, Time.deltaTime * 3f);
                dotsCleared = Mathf.CeilToInt(dotsClearedLerp);
                dotsClearedLabel.text = dotsCleared.ToString();

            //  Creates a delay of roughly 2 seconds where a "Scored Points" sound cannot play again.
            //  This makes the sound for scoring play per sequence of dots being scored versus playing a sound for each dot being scored individually.
            if (dotsCleared != temp && dotsCleared != 0)
                {
                    if (soundPlayed == false)
                    {
                        dotsScored.Play();
                        soundPlayed = true;
                    }
                    temp = dotsCleared;
                }

                if (soundPlayed == true)
                {
                    delay += Time.deltaTime * 3f;
                }

                if (delay > 2)
                 {
                    soundPlayed = false;
                    delay = 0;
                 }
               

        }

        private void Awake()
        {
            dotsCleared = 0;
            dotsClearedLabel.text = dotsCleared.ToString();
            currLevel = SceneManager.GetActiveScene().buildIndex;
            temp = dotsCleared;
            soundPlayed = false;
            LevelSoundPlayed = false;
            delay = 0;
        }
     
    }

 }
