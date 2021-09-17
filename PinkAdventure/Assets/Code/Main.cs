using System;
using UnityEngine;


namespace Adventure
{
    public class Main : MonoBehaviour, IDisposable
    {
        #region Fields

        [SerializeField] private GameConfig _gameConfig;
/*        [SerializeField] private SpriteAnimationsConfig _playerAnimationsConfig;
        [SerializeField] private LevelObjectView _playerView;*/

/*        private SpriteAnimator _spriteAnimator;*/
        private CompositeControllers _controllers;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _controllers = new CompositeControllers();
            var gameInitialization = new GameInitialization(_controllers, _gameConfig);

           /* _playerAnimationsConfig = Resources.Load<SpriteAnimationsConfig>(Constants.SpriteAnimationsConfig);

            if (_playerAnimationsConfig)
            {
                _spriteAnimator = new SpriteAnimator(_playerAnimationsConfig);
            }

            if (_playerView)
            {
                _spriteAnimator.StartAnimation(_playerView.CharacterSprite, Track.Idle, true, 10.0f);
            }*/

        }

        private void Start()
        {
            _controllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            /* _spriteAnimator.Execute();*/
            _controllers.Execute(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.FixedExecute(deltaTime);
        }

        private void OnDestroy()
        {

        }

        public void Dispose()
        {
            _controllers.Cleanup();
        }

        #endregion
    }
}

