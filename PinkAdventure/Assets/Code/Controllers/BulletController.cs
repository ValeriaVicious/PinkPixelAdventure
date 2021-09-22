using UnityEngine;


namespace Adventure
{
    public sealed class BulletController : IExecute
    {
        #region Fields

        private BulletView _bulletView;
        private Vector3 _velocity;
        private Vector3 _upVector = new Vector3(0.0f, 1.0f, 0.0f);
        private float _groundLevel = 0.0f;
        private float _radius = 0.5f;
        private float _accelerationOfGravity = -10.0f;

        #endregion


        #region ClassLifeCycles

        public BulletController(BulletView bulletView)
        {
            _bulletView = bulletView;
            _bulletView.SetVisible(false);
        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            if (IsGrounded())
            {
                SetVelocity(_velocity.Change(y: -_velocity.y));
                _bulletView.Transform.position = _bulletView.Transform.position.Change(y: _groundLevel + _radius);
            }
            else
            {
                SetVelocity(_velocity + _upVector * _accelerationOfGravity * deltaTime);
                _bulletView.Transform.position += _velocity * deltaTime;
            }
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _bulletView.Transform.position = position;
            SetVelocity(velocity);
            _bulletView.SetVisible(true);
        }

        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            var angle = Vector3.Angle(Vector3.left, _velocity);
            var axis = Vector3.Cross(Vector3.left, _velocity);
            _bulletView.Transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        private bool IsGrounded()
        {
            return _bulletView.Transform.position.y <= _groundLevel + _radius + float.Epsilon &&
                _velocity.y <= 0.0f;
        }

        #endregion
    }
}
