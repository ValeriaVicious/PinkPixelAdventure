using UnityEngine;


namespace Adventure
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/" + nameof(PlayerConfig), order = 1)]
    public sealed class PlayerConfig : ScriptableObject
    {
        #region Fields

        public LevelObjectView View;
        public SpriteAnimationsConfig SpriteAnimationsConfig;
        public int AnimationSpeed = 10;
        public float WalkSpeed = 3.0f;
        public float JumpStartSpeed = 8.0f;
        public float MovingThresh = 0.1f;
        public float FlyThresh = 1.0f;
        public float GroundLevel = 0.5f;

        #endregion
    }
}
