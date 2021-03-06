using System;
using UnityEngine;


namespace Adventure
{
    public sealed class LevelObjectView : MonoBehaviour
    {
        #region Fields

        public Transform Transform;
        public SpriteRenderer CharacterSprite;
        public Collider2D Collider;
        public Rigidbody2D Rigidbody;

        public Action<Track> OnStateChange;

        #endregion


        #region UnityMethods

        private void Start()
        {
            Transform = GetComponent<Transform>();
            CharacterSprite = GetComponent<SpriteRenderer>();
        }

        #endregion
    }
}
