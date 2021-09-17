using System.Collections.Generic;


namespace Adventure
{
    internal sealed class CompositeControllers : IInitialization, IExecute, IFixedExecute, ICleanup
    {
        #region Fields

        private readonly List<IInitialization> _initializationsControllers;
        private readonly List<IExecute> _executesControllers;
        private readonly List<IFixedExecute> _fixedExecutesControllers;
        private readonly List<ICleanup> _cleanupsControllers;

        #endregion


        #region ClassLifeCycles

        public CompositeControllers()
        {
            _initializationsControllers = new List<IInitialization>();
            _executesControllers = new List<IExecute>();
            _fixedExecutesControllers = new List<IFixedExecute>();
            _cleanupsControllers = new List<ICleanup>();
        }

        #endregion


        #region Methods

        public void Add(IController controller)
        {
            if (controller is IInitialization initialization)
            {
                _initializationsControllers.Add(initialization);
            }

            if (controller is IExecute execute)
            {
                _executesControllers.Add(execute);
            }

            if (controller is IFixedExecute fixedExecute)
            {
                _fixedExecutesControllers.Add(fixedExecute);
            }

            if (controller is ICleanup cleanup)
            {
                _cleanupsControllers.Add(cleanup);
            }
        }

        public void Cleanup()
        {
            for (int i = 0; i < _cleanupsControllers.Count; i++)
            {
                _cleanupsControllers[i].Cleanup();
            }
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _executesControllers.Count; i++)
            {
                _executesControllers[i].Execute(deltaTime);
            }
        }

        public void FixedExecute(float deltaTime)
        {
            for (int i = 0; i < _fixedExecutesControllers.Count; i++)
            {
                _fixedExecutesControllers[i].FixedExecute(deltaTime);
            }
        }

        public void Initialization()
        {
            for (int i = 0; i < _initializationsControllers.Count; i++)
            {
                _initializationsControllers[i].Initialization();
            }
        }

        #endregion
    }
}
