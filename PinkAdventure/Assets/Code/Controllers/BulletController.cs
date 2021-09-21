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
            SetActive(false);
        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            if (IsGrounded())
            {
                SetVelocity(_velocity.Change(y: -_velocity.y));
                _bulletView.transform.position = _bulletView.transform.position.Change(y: _groundLevel + _radius);
            }
            else
            {
                SetVelocity(_velocity + _upVector * _accelerationOfGravity * deltaTime);
                _bulletView.transform.position += _velocity * deltaTime;
            }
        }

        private void Throw(Vector3 position, Vector3 velocity)
        {
            SetActive(true);
            _bulletView.transform.position = position;
            _bulletView.Rigidbody.velocity = Vector2.zero;
            _bulletView.Rigidbody.angularVelocity = 0.0f;
            _bulletView.Rigidbody.AddForce(velocity, ForceMode2D.Impulse);
        }

        private void SetActive(bool value)
        {
            _bulletView.gameObject.SetActive(value);
        }

        private void SetVelocity(Vector3 position, Vector3 velocity)
        {
            _bulletView.transform.position = position;
            SetVelocity(velocity);
            _bulletView.SetVisible(true);
        }

        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            var angle = Vector3.Angle(Vector3.left, _velocity);
            var axis = Vector3.Cross(Vector3.left, _velocity);
            _bulletView.transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        private bool IsGrounded()
        {
            return _bulletView.transform.position.y <= _groundLevel + _radius + float.Epsilon &&
                _velocity.y <= 0.0f;
        }

        #endregion
    }
}
