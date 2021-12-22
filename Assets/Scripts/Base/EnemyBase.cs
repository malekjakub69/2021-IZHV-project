using UnityEngine;

namespace Game.Base
{
    [RequireComponent(typeof(Stats.Stats))]
    public class EnemyBase: Base
    {
        [HideInInspector]
        public Transform EnemyBasePosition;
        
        private Stats.Stats playerStats;

        private void Awake()
        {
            EnemyBasePosition = FindObjectOfType<EnemyBase>().transform;
        }
    }
}