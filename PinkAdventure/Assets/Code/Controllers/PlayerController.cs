using UnityEngine;


namespace Adventure
{
    internal sealed class PlayerController
    {
        #region Fields

        private LevelObjectView _view;
        private SpriteAnimator _spriteAnimator;
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private Vector3 _vectorRight = new Vector3(1, 0, 0);
        private Vector3 _vectorUp = new Vector3(0, 1, 0);

        private float _speed = 3.0f;
        private float _accelerationOfGravity = -10.0f;
        private float _animationSpeed = 10.0f;
        private float _jumpStartSpeed = 8.0f;
        private float _movingTresh = 0.1f;
        private float _flyThresh = 1.0f;
        private float _groundLevel = 0.0f;
        private float _xAxisInput = 0.0f;
        private float _yVelocity = 0.0f;
        private float _xVelocity = 0.0f;
        private float _jumpTresh = 1.0f;
        private bool _isJump;
        private bool _isMoving;

        #endregion


        #region ClassLifeCycles

        public PlayerController(LevelObjectView pleyrView, SpriteAnimator spriteAnimator)
        {
            _view = pleyrView;
            _spriteAnimator = spriteAnimator;

            _spriteAnimator.StartAnimation(_view.CharacterSprite, Track.Idle, true, _animationSpeed);
        }

        #endregion


        #region Methods

        public void Execute()
        {
            _spriteAnimator.Execute();
            _isJump = Input.GetAxis(Constants.VerticalInput) > 0.0f;
            _xAxisInput = Input.GetAxis(Constants.HorizontalInput);
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTresh;

            if (_isMoving)
            {
                GoSideWay();
            }
            if (IsGrounded())
            {
                _spriteAnimator.StartAnimation(_view.CharacterSprite,
                    _isMoving ? Track.Run : Track.Idle, true, _animationSpeed);

                if (_isJump && _yVelocity == 0.0f)
                {
                    _yVelocity = _jumpStartSpeed;
                }
                else if (_yVelocity < 0.0f)
                {
                    _yVelocity = 0.0f;
                    _view.Transform.position = _view.Transform.position.Change(y: _groundLevel);
                }
            }
            else
            {
                if (Mathf.Abs(_yVelocity) > _flyThresh)
                {
                    _spriteAnimator.StartAnimation(_view.CharacterSprite,
                        Track.Jump, true, _animationSpeed);
                }
                _yVelocity += _accelerationOfGravity * Time.deltaTime;
                _view.Transform.position += _vectorUp * (Time.deltaTime * _yVelocity);
            }
        }

        private void GoSideWay()
        {
            _view.Transform.position += _vectorRight * (Time.deltaTime * _speed *
                (_xAxisInput < 0.0f ? -1.0f : 1.0f));
            _view.Transform.localScale = (_xAxisInput < 0.0f ? _leftScale : _rightScale);
        }

        public bool IsGrounded()
        {
            return _view.Transform.position.y <= _groundLevel + float.Epsilon &&
                _yVelocity <= 0.0f;
        }

        #endregion
    }
}