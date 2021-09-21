﻿using UnityEngine;


namespace Adventure
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "Configs/" + nameof(GameConfig), order = 1)]
    public sealed class GameConfig : ScriptableObject
    {
        public PlayerConfig PlayerConfig;
        public BulletConfig BulletConfig;
        public CannonView CannonView;
        public GameObject Back;
    }
}
