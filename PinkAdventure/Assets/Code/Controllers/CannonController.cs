using UnityEngine;


namespace Adventure
{
    public sealed class CannonController : IExecute
    {
        #region Fields

        private Transform _muzzleTransform;
        private Transform _targetTransform;
        private Vector3 _direction;
        private Vector3 _axis;
        private float _angle;

        #endregion


        #region ClassLifeCycles

        public CannonController(Transform muzzleTransform, Transform targetTransform)
        {
            _muzzleTransform = muzzleTransform;
            _targetTransform = targetTransform;
        }

        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            _direction = _targetTransform.position - _muzzleTransform.position;
            _angle = Vector2.Angle(Vector2.down, _direction);
            _axis = Vector3.Cross(Vector3.down, _direction);
            _muzzleTransform.rotation = Quaternion.AngleAxis(_angle, _axis);
        }

        #endregion
    }
}
