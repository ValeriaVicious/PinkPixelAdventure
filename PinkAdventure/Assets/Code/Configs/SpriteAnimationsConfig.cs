using System;
using System.Collections.Generic;
using UnityEngine;


namespace PinkAdventure
{
    public enum Track
    {
        DoubleJump,
        Fall,
        Hit,
        Idle,
        Jump,
        Run,
        WallJump
    }


    [CreateAssetMenu(fileName = "SpriteAnimationsConfig",
        menuName = "Configs/SpriteAnimationsConfig", order = 1)]
    public sealed class SpriteAnimationsConfig : ScriptableObject
    {
        #region Fields

        public Track Track;
        public List<SpritesSequence> Sequences = new List<SpritesSequence>();

        #endregion

        [Serializable]
        public class SpritesSequence
        {
            #region Fields

            public Track Track;
            public List<Sprite> Sprites = new List<Sprite>();

            #endregion
        }
    }
}
