using System;
using UnityEngine;


namespace Adventure
{
    public class Main : MonoBehaviour, ICleanup
    {
        #region Fields

        [SerializeField] private GameConfig _gameConfig;
        private CompositeControllers _controllers;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _controllers = new CompositeControllers();
            var gameInitialization = new GameInitialization(_controllers, _gameConfig);
        }

        private void Start()
        {
            _controllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            _controllers.FixedExecute(deltaTime);
        }

        private void OnDestroy()
        {

        }

        public void Cleanup()
        {
            _controllers.Cleanup();
        }

        #endregion
    }
}

