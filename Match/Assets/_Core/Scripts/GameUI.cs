using UnityEngine;
using UnityEngine.UI;

namespace MatchDot
{
   
    /// <summary>
    /// Updates the game's UI
    /// </summary>
    public class GameUI : MonoBehaviour
    {
        
        public Text dotsClearedLabel;

        private int dotsCleared;
        private float dotsClearedLerp;
        public AudioSource dotsScored;
        public int temp;
        public bool soundPlayed;
        private float delay;
       

        private void Update()
        {


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
            temp = dotsCleared;
            soundPlayed = false;
            delay = 0;
        }
     
    }

 }
