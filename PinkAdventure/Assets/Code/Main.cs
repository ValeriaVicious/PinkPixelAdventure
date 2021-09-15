using UnityEngine;


namespace Adventure
{
    public class Main : MonoBehaviour
    {
        #region Fields

        [SerializeField] private SpriteAnimationsConfig _playerAnimationsConfig;
        [SerializeField] private LevelObjectView _playerView;

        private SpriteAnimator _spriteAnimator;
        private PlayerController _playerController;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _playerAnimationsConfig = Resources.Load<SpriteAnimationsConfig>(Constants.SpriteAnimationsConfig);

            if (_playerAnimationsConfig)
            {
                _spriteAnimator = new SpriteAnimator(_playerAnimationsConfig);
            }

            if (_playerView)
            {
                _spriteAnimator.StartAnimation(_playerView.CharacterSprite, Track.Idle, true, 10.0f);
            }
            _playerController = new PlayerController(_playerView, _spriteAnimator);
        }

        private void Update()
        {
            _playerController.Execute();
        }

        private void FixedUpdate()
        {

        }

        private void OnDestroy()
        {

        }

        #endregion
    }
}

