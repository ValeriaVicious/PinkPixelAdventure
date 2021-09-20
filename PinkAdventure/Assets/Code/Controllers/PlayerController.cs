using UnityEngine;


namespace Adventure
{
    public sealed class PlayerController : IFixedExecute
    {
        #region Fields

        private readonly PlayerConfig _playerConfig;
        private readonly LevelObjectView _view;
        private readonly ContactPoller _contactPoller;
        private Track _currentTrack = Track.Idle;
        private Vector3 _rightVector = new Vector3(1.0f, 0.0f, 0.0f);
        private Vector3 _upVector = new Vector3(0.0f, 1.0f, 0.0f);
        private Vector3 _leftScale = new Vector3(-1.0f, 1.0f, 1.0f);
        private Vector3 _rightScale = new Vector3(1.0f, 1.0f, 1.0f);
        private float _yVelocity = 0.0f;
        private float _xVelocity = 0.0f;
        private float _xAxisInput;
        private float _accelerationOfGravity = -9.8f;
        private bool _isJump;

        #endregion


        #region ClassLifeCycles

        public PlayerController(PlayerConfig player, LevelObjectView view)
        {
            _playerConfig = player;
            _view = view;
            _contactPoller = new ContactPoller(_view.Collider);
        }

        #endregion


        #region Methods

        private void GoSideAway(float deltaTime)
        {
            _xVelocity = _playerConfig.WalkSpeed * deltaTime * (_xAxisInput < 0 ? -1.0f : 1.0f);
            _view.Rigidbody.velocity = _view.Rigidbody.velocity.Change(x: _xVelocity);
            _view.Transform.localScale = (_xAxisInput < 0.0f ? _leftScale : _rightScale);
        }

        private bool IsGrounded()
        {
            return _view.Transform.position.y <= _playerConfig.GroundLevel +
                float.Epsilon && _yVelocity <= 0.0f;
        }

        public void FixedExecute(float deltaTime)
        {
            _contactPoller.FixedExecute(deltaTime);
            _isJump = Input.GetAxis(Constants.VerticalInput) > 0.0f;
            _xAxisInput = Input.GetAxis(Constants.HorizontalInput);
            _yVelocity = _view.Rigidbody.velocity.y;

            var goSideAway = Mathf.Abs(_xAxisInput) > _playerConfig.MovingThreshold;
            var previousTrack = _currentTrack;

            if (goSideAway)
            {
                GoSideAway(deltaTime);
            }

            if (_contactPoller.IsGrounded)
            {
                _currentTrack = goSideAway ? Track.Run : Track.Idle;

                if (_isJump && Mathf.Abs(_yVelocity) <= _playerConfig.JumpThreshold)
                {
                    _view.Rigidbody.AddForce(_upVector * _playerConfig.JumpForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (goSideAway)
                {
                    GoSideAway(deltaTime);
                }
                if (Mathf.Abs(_yVelocity) > _playerConfig.JumpThreshold)
                {
                    _currentTrack = Track.Jump;
                }
            }

            if (_currentTrack != previousTrack)
            {
                _view.OnStateChange?.Invoke(_currentTrack);
            }
        }

        #endregion
    }
}
