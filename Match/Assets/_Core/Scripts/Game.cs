using UnityEngine;

namespace MatchDot
{
    /// <summary>
    /// Used to house widely used values and game configuration
    /// </summary>
    public class Game : Singleton<Game>
    {
       

        public bool useRandomSeed = true;
        public int seed;

        public GameSession session { get; set; }
        public DotsTheme selectedTheme = DotsTheme.defaultTheme;
     
        protected override void Awake()
        {
            int width = 750; // or something else
            int height = 1334; // or something else
            bool isFullScreen = false; // should be windowed to run in arbitrary resolution
            int desiredFPS = 60; // or something else

            Screen.SetResolution(width, height, isFullScreen, desiredFPS);
            base.Awake();
            if (!useRandomSeed)
            {
                Random.InitState(seed);
            }
            session = new GameSession();
            Camera.main.backgroundColor = selectedTheme.backgroundColor;

        }
     
    }
}