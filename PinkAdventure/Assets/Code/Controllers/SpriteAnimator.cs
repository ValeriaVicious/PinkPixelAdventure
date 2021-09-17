using System;
using System.Collections.Generic;
using UnityEngine;


namespace Adventure
{
    public class SpriteAnimator : IExecute, ICleanup
    {
        private sealed class Animation
        {
            #region Fields

            public Track Track;
            public List<Sprite> Sprites;
            public bool IsLoop;
            public bool IsSleep;
            public float Speed = 10.0f;
            public float Counter = 0.0f;

            #endregion


            #region Methods

            public void Execute(float deltaTime)
            {
                if (IsSleep)
                {
                    return;
                }
                Counter += deltaTime * Speed;

                if (IsLoop)
                {
                    while (Counter > Sprites.Count)
                    {
                        Counter -= Sprites.Count;
                    }
                }
                else if (Counter > Sprites.Count)
                {
                    Counter = Sprites.Count;
                    IsSleep = true;
                }
            }

            #endregion
        }

        #region Fields

        private SpriteAnimationsConfig _configAnimations;
        private Dictionary<SpriteRenderer, Animation> _activeAnimation = new Dictionary<SpriteRenderer, Animation>();

        #endregion


        #region ClassLifeCycles

        public SpriteAnimator(SpriteAnimationsConfig spriteAnimationsConfig)
        {
            _configAnimations = spriteAnimationsConfig;
        }

        #endregion


        #region Methods

        public void StartAnimation(SpriteRenderer spriteRenderer, Track track,
            bool isLoop, float speed)
        {
            if (_activeAnimation.TryGetValue(spriteRenderer, out var animation))
            {
                animation.IsLoop = isLoop;
                animation.Speed = speed;
                animation.IsSleep = false;

                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _configAnimations.Sequences.
                        Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = 0.0f;
                }
            }
            else
            {
                _activeAnimation.Add(spriteRenderer, new Animation()
                {
                    Track = track,
                    Sprites = _configAnimations.Sequences.Find(sequence =>
                    sequence.Track == track).Sprites,
                    IsLoop = isLoop,
                    Speed = speed
                });
            }
        }

        public void StopAnimation(SpriteRenderer spriteRenderer)
        {
            if (_activeAnimation.ContainsKey(spriteRenderer))
            {
                _activeAnimation.Remove(spriteRenderer);
            }
        }

        public void Execute()
        {
            foreach (var animation in _activeAnimation)
            {
                animation.Value.Execute(Time.deltaTime);
                if (animation.Value.Counter < animation.Value.Sprites.Count)
                {
                    animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                }

            }
        }

        public void Cleanup()
        {
            _activeAnimation.Clear();
        }

        public void Execute(float deltaTime)
        {
            foreach (var item in _activeAnimation)
            {
                item.Value.Execute(deltaTime);
                item.Key.sprite = item.Value.Sprites[(int)item.Value.Counter];
            }
        }

        #endregion
    }
}
