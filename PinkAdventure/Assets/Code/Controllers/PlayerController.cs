using UnityEngine;


namespace Adventure
{
    public sealed class PlayerController : IExecute
    {
        #region Fields

        private readonly PlayerConfig _playerConfig;
        private readonly LevelObjectView _view;
        private Track _currentTrack = Track.Idle;

        private Vector3 _rightVector = new Vector3(1.0f, 0.0f, 0.0f);
        private Vector3 _upVector = new Vector3(0.0f, 1.0f, 0.0f);
        private Vector3 _leftScale = new Vector3(-1.0f, 1.0f, 1.0f);
        private Vector3 _rightScale = new Vector3(1.0f, 1.0f, 1.0f);
        private float _yVelocity;
        private float _xAxisInput;
        private float _accelerationOfGravity = -9.8f;
        private bool _isJump;
        private bool _isGrounded;

        #endregion


        #region ClassLifeCycles

        public PlayerController(PlayerConfig player, LevelObjectView view)
        {
            _playerConfig = player;
            _view = view;
        }

        #endregion


        #region Methods

        private void GoSideAway(float deltaTime)
        {
            var speed = deltaTime * _playerConfig.WalkSpeed;
            _rightVector.Set(speed * _xAxisInput, 0.0f, 0.0f);
            _leftScale.Set(Mathf.Sign(_xAxisInput), _leftScale.y, _leftScale.z);

            _view.Transform.position += _rightVector;
            _view.Transform.localScale = _leftScale;
        }

        private bool IsGrounded()
        {
            return _view.Transform.position.y <= _playerConfig.GroundLevel +
                float.Epsilon && _yVelocity <= 0.0f;
        }

        public void Execute(float deltaTime)
        {
            _isJump = Input.GetAxis(Constants.VerticalInput) > 0.0f;
            _xAxisInput = Input.GetAxis(Constants.HorizontalInput);
            var goSideAway = Mathf.Abs(_xAxisInput) > _playerConfig.MovingThresh;
            var previousTrack = _currentTrack;

            if (IsGrounded())
            {
                if (goSideAway)
                {
                    GoSideAway(deltaTime);
                }
                _currentTrack = goSideAway ? Track.Run : Track.Idle;

                if (_isJump && _yVelocity == 0.0f)
                {
                    _yVelocity = _playerConfig.JumpStartSpeed;
                }
                else if (_yVelocity < 0.0f)
                {
                    _yVelocity = 0.0f;
                    _view.Transform.position = _view.Transform.position.Change(y: _playerConfig.GroundLevel);
                }
            }
            else
            {
                if (goSideAway)
                {
                    GoSideAway(deltaTime);
                }
                if (Mathf.Abs(_yVelocity) > _playerConfig.FlyThresh)
                {
                    _currentTrack = Track.Jump;
                }
                _yVelocity += _accelerationOfGravity * Time.deltaTime;
                _view.Transform.position += _upVector * (Time.deltaTime * _yVelocity);
            }

            if (_currentTrack != previousTrack)
            {
                _view.OnStateChange?.Invoke(_currentTrack);
            }
        }

        #endregion
    }
}
