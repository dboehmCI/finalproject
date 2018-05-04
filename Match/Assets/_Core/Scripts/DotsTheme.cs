using UnityEngine;

namespace DotsClone
{
    /// <summary>
    /// Defines a color scheme for the game
    /// Uses a scriptable object so themes can be created as asset files
    /// </summary>
    [CreateAssetMenu]
    public class DotsTheme : ScriptableObject
    {
        public static DotsTheme defaultTheme;

        public Color backgroundColor = Color.white;
        public Color dotA = new Color32(229, 55, 95, 120);
        public Color dotB = new Color32(56, 178, 255, 120);
        public Color dotC = new Color32(138, 233, 145, 120);
        public Color dotD = new Color32(142, 109, 232, 120);
        public Color dotE = new Color32(255, 211, 45, 120);
        public Color dotG = new Color32(189, 189, 189, 0);

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            defaultTheme = CreateInstance<DotsTheme>();
        }

        /// <summary>
        /// Returns the color for a dot for the current theme.
        /// </summary>
        public Color FromDotType(DotType type)
        {
            switch (type)
            {
                case DotType.Cleared:
                    return dotG;
                case DotType.DotA:
                    return dotA;
                case DotType.DotB:
                    return dotB;
                case DotType.DotC:
                    return dotC;
                case DotType.DotD:
                    return dotD;
                case DotType.DotE:
                    return dotE;
                case DotType.DotG:
                    return dotG;
                default:
                    return Color.white; // Easy to notice invalid behaviour
            }
        }
    }
}