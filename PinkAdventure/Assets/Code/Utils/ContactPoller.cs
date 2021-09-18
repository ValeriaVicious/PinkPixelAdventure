using UnityEngine;


namespace Adventure
{
    public sealed class ContactPoller : IExecute
    {
        #region Fields

        private ContactPoint2D[] _contacts = new ContactPoint2D[10];
        private Collider2D _collider;
        private const float _colliderThreshold = 0.6f;
        private int _contactCount;

        #endregion


        #region Properties

        public bool IsGrounded { get; private set; }
        public bool HasLeftContact { get; private set; }
        public bool HasRightContact { get; private set; }

        #endregion


        #region ClassLifeCycles

        public ContactPoller(Collider2D collider)
        {
            _collider = collider;
        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            IsGrounded = false;
            HasLeftContact = false;
            HasRightContact = false;

            _contactCount = _collider.GetContacts(_contacts);

            for (int i = 0; i < _contactCount; i++)
            {
                if (_contacts[i].normal.y > _colliderThreshold)
                {
                    IsGrounded = true;
                }
                if (_contacts[i].normal.x > _colliderThreshold)
                {
                    HasLeftContact = true;
                }
                if (_contacts[i].normal.x > -_colliderThreshold)
                {
                    HasRightContact = true;
                }
            }
        }

        #endregion

    }
}
