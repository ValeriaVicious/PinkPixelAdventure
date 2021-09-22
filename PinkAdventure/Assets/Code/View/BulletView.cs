using UnityEngine;


namespace Adventure
{
    public sealed class BulletView : MonoBehaviour
    {
        #region Fields

        public TrailRenderer TrailRenderer;
        public Transform Transform;
        public Rigidbody2D Rigidbody;
        public Collider2D Collider;

        #endregion


        #region Methods

        public void SetVisible(bool value)
        {
            if (TrailRenderer)
            {
                TrailRenderer.enabled = value;
            }
            if (TrailRenderer)
            {
                TrailRenderer.Clear();
            }
            gameObject.SetActive(value);
        }

        #endregion
    }
}
