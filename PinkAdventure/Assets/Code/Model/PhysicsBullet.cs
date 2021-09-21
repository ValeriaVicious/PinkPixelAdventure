using UnityEngine;


namespace Adventure
{
    public sealed class PhysicsBullet
    {
        #region Fields

        private BulletView _bulletView;

        #endregion


        #region ClassLifeCycles

        public PhysicsBullet(BulletView bulletView)
        {
            _bulletView = bulletView;
            _bulletView.SetVisible(false);
        }

        #endregion


        #region Methods

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _bulletView.SetVisible(false);
            _bulletView.transform.position = position;
            _bulletView.Rigidbody.velocity = Vector2.zero;
            _bulletView.Rigidbody.angularVelocity = 0.0f;
            _bulletView.SetVisible(true);
            _bulletView.Rigidbody.AddForce(velocity, ForceMode2D.Impulse);
        }

        #endregion
    }
}
