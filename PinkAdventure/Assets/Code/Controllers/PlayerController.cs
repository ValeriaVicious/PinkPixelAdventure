using UnityEngine;


namespace Adventure
{
    public sealed class PlayerController : IExecute
    {
        #region Fields

        private Vector3 _rightVector = new Vector3(1.0f, 0.0f, 0.0f);
        private Vector3 _leftVector = new Vector3(0.0f, 1.0f, 0.0f);

        #endregion


        #region ClassLifeCycles
        #endregion


        #region Methods

        public void Execute(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
