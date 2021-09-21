using UnityEngine;


namespace Adventure
{
    [CreateAssetMenu(fileName = nameof(BulletConfig), menuName = "Configs/" + nameof(BulletConfig), order = 1)]
    public sealed class BulletConfig : ScriptableObject
    {
        #region Fields

        public BulletView BulletView;

        #endregion
    }
}
