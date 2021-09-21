using UnityEngine;


namespace Adventure
{
    public sealed class BulletController : IExecute
    {
        #region Fields

        private Vector3 _velocity;
        private BulletView _bulletView;

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

        #endregion
    }
}
