using System.Collections.Generic;
using UnityEngine;


namespace Adventure
{
    public sealed class CannonView : MonoBehaviour
    {
        #region Fields

        public Transform MuzzleTransform;
        public Transform EmmiterTransform;
        public List<BulletView> Bullets;

        #endregion
    }
}
