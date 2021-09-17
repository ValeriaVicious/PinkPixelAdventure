using UnityEngine;


namespace Adventure
{
    internal sealed class PlayerInitialization : IInitialization
    {
        #region Fields

        private readonly LevelObjectView _view;

        #endregion


        #region ClassLufeCycles

        public PlayerInitialization(LevelObjectView objectView)
        {
            _view = Object.Instantiate(objectView);
        }

        #endregion


        #region Methods

        public LevelObjectView GetLevelObject()
        {
            return _view;
        }

        public void Initialization() { }

        #endregion
    }
}
