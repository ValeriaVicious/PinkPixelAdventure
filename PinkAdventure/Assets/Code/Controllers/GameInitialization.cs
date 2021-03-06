using UnityEngine;


namespace Adventure
{
    internal sealed class GameInitialization
    {
        public GameInitialization(CompositeControllers compositeControllers, GameConfig gameConfig)
        {
            Camera camera = Camera.main;
            var playerIntialization = new PlayerInitialization(gameConfig.PlayerConfig.View);
            var player = playerIntialization.GetLevelObject();

            compositeControllers.Add(playerIntialization);
            compositeControllers.Add(new PlayerAnimationController(gameConfig.PlayerConfig, player));
            compositeControllers.Add(new PlayerController(gameConfig.PlayerConfig, player));
        }
    }
}
