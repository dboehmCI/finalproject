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
        public AudioSource GameOverSound;
        public int temp;
        public bool soundPlayed;
        public bool LevelSoundPlayed;
        private float delay;
        public Canvas LevelStatus;
        public Canvas GameOver;
        public int currLevel;


        private void Update()
        {
            // Could be more efficient using events, but good enough
            dotsClearedLerp = Mathf.Lerp(dotsClearedLerp, Game.get.session.dotsCleared, Time.deltaTime * 3f);
            dotsCleared = Mathf.CeilToInt(dotsClearedLerp);
            dotsClearedLabel.text = dotsCleared.ToString();

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
                else if (Game.get.session.gameOver)
                {
                    Game.get.session.dotsCleared = 0;
                    GameOver.gameObject.SetActive(true);
                    if (LevelSoundPlayed == false)
                    {
                        GameOverSound.Play();
                        LevelSoundPlayed = true;

                    }
                }
            }
            else if (currLevel == 2)
            {
                
                if (dotsCleared >= 20)
                {
                    Game.get.session.dotsCleared = 0;
                    LevelStatus.gameObject.SetActive(true);
                    if (LevelSoundPlayed == false)
                    {
                        LevelComplete.Play();
                        LevelSoundPlayed = true;
                        Debug.Log("I played");
                    }
                }
                else if (Game.get.session.gameOver)
                {
                    Game.get.session.dotsCleared = 0;
                    GameOver.gameObject.SetActive(true);
                    if (LevelSoundPlayed == false)
                    {
                        GameOverSound.Play();
                        LevelSoundPlayed = true;
                        
                    }
                }
            }
            else if (currLevel == 3)
            {
                
                if (dotsCleared > 30)
                {
                    Game.get.session.dotsCleared = 0;
                    LevelStatus.gameObject.SetActive(true);
                    if (LevelSoundPlayed == false)
                    {
                        LevelComplete.Play();
                        LevelSoundPlayed = true;
                        Debug.Log("I played");
                    }
                }
                else if (Game.get.session.gameOver)
                {
                    Game.get.session.dotsCleared = 0;
                    GameOver.gameObject.SetActive(true);
                    if (LevelSoundPlayed == false)
                    {
                        GameOverSound.Play();
                        LevelSoundPlayed = true;

                    }
                }
            }
              
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
            Game.get.session.dotsCleared = 0;
            Game.get.session.gameOver = false;
            LevelStatus.gameObject.SetActive(false);
            GameOver.gameObject.SetActive(false);
            currLevel = SceneManager.GetActiveScene().buildIndex;
            temp = 0;
            soundPlayed = false;
            LevelSoundPlayed = false;
            delay = 0;
        }
     
    }

 }
