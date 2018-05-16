using UnityEngine;

namespace MatchDot
{
    /// <summary>
    /// Stores current game stats
    /// Potential stats to add:
    ///     Abilities left
    ///     Score
    ///     Timer
    ///     Moves left
    /// </summary>
    public class GameSession
    {
        public bool gameOver = false;
        public int dotsCleared { get; set; }
       

    }
}