using System;
using System.Collections.Generic;
using UnityEngine;


namespace Adventure
{
    [CreateAssetMenu(fileName = nameof(SpriteAnimationsConfig), menuName = "Configs/" + nameof(SpriteAnimationsConfig), order = 1)]
    public sealed class SpriteAnimationsConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpritesSequence
        {
            #region Fields

            public Track Track;
            public List<Sprite> Sprites = new List<Sprite>();

            #endregion
        }

        #region Fields

        public List<SpritesSequence> Sequences = new List<SpritesSequence>();

        #endregion

    }
}
