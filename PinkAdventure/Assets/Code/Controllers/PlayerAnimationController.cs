

using System;

namespace Adventure
{
    public sealed class PlayerAnimationController : IExecute, ICleanup
    {
        #region Fields

        private readonly PlayerConfig _playerConfig;
        private readonly LevelObjectView _view;
        private readonly SpriteAnimator _animator;

        #endregion


        #region ClassLifeCycles

        public PlayerAnimationController(PlayerConfig playerConfig, LevelObjectView view)
        {
            _playerConfig = playerConfig;
            _view = view;
            _animator = new SpriteAnimator(playerConfig.SpriteAnimationsConfig);
            _view.OnStateChange += ChangeAnimation;
        }

        #endregion


        #region Methods

        private void ChangeAnimation(Track track)
        {
            _animator.StartAnimation(_view.CharacterSprite, GetAnimationTrack(track),
                true, _playerConfig.AnimationSpeed);
        }

        private Track GetAnimationTrack(Track track)
        {
            return track switch
            {
                Track.Run => Track.Run,
                Track.Idle => Track.Idle,
                Track.Jump => Track.Jump,
                Track.DoubleJump => Track.DoubleJump,
                Track.Fall => Track.Fall,
                Track.Hit => Track.Hit,
                Track.WallJump => Track.WallJump
            };
        }

        public void Cleanup()
        {
            _animator.Cleanup();
        }

        public void Execute(float deltaTime)
        {
            _animator.Execute(deltaTime);
        }

        #endregion
    }
}