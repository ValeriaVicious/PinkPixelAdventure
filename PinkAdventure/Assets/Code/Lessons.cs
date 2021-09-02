using UnityEngine;


namespace PinkAdventure
{
    public class Lessons : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Camera _mainCamera;
        [SerializeField] private SpriteRenderer _back;

        private SpriteAnimationsConfig _animationsConfig;
        private SpriteAnimator _spriteAnimator;
        private CharacterView _characterView;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _animationsConfig = Resources.Load<SpriteAnimationsConfig>(Constants.SpriteAnimationsConfig);
            _spriteAnimator = new SpriteAnimator(_animationsConfig);
            _spriteAnimator.StartAnimation(_characterView.CharacterSprite, Track.Idle, true, 10.0f);
        }

        private void Update()
        {
            _spriteAnimator.Execute();
        }

        private void FixedUpdate()
        {

        }

        private void OnDestroy()
        {

        }

        #endregion
    }
}

