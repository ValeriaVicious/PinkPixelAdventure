using System.Collections.Generic;
using UnityEngine;


namespace Adventure
{
    public sealed class BulletEmitterController : IExecute
    {
        #region Fields

        private Transform _transform;
        private List<PhysicsBullet> _physicsBullets = new List<PhysicsBullet>();
        private const float _delay = 1.0f;
        private const float _startSpeed = 5.0f;
        private float _timeTillNextBullet;
        private int _currentIndex;

        #endregion


        #region ClassLifeCycles

        public BulletEmitterController(List<BulletView> bulletViews, Transform transform)
        {
            _transform = transform;
            foreach (var item in bulletViews)
            {
                _physicsBullets.Add(new PhysicsBullet(item));
            }
        }

        #endregion

        #region Methods

        public void Execute(float deltaTime)
        {
            if (_timeTillNextBullet > 0)
            {
                _timeTillNextBullet -= deltaTime;
            }
            else
            {
                _timeTillNextBullet = _delay;
                _physicsBullets[_currentIndex].Throw(_transform.position, _transform.up * _startSpeed);
                _currentIndex++;
                if (_currentIndex >= _physicsBullets.Count)
                {
                    _currentIndex = 0;
                }
            }
        }

        #endregion
    }
}
