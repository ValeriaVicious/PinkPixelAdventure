using UnityEngine;


namespace Adventure
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 1)]
    public sealed class PlayerConfig : ScriptableObject
    {
        [SerializeField] private LevelObjectView _characterView;
        [SerializeField] private SpriteAnimationsConfig _spriteAnimations;
        [SerializeField] private float _animationSpeed = 10.0f;
        [SerializeField] private float _speed = 3.0f;
        [SerializeField] private float _accelerationOfGravity = -10.0f;
        [SerializeField] private float _flyThresh = 1.0f;
        [SerializeField] private float _jumpStartSpeed = 8.0f;
        [SerializeField] private float _groundLevel = 0.0f;
        [SerializeField] 
    }
}