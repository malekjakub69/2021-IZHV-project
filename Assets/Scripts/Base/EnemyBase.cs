using UnityEngine;

namespace Game.Base
{
    public class EnemyBase: Base
    {
        [HideInInspector]
        public Transform EnemyBasePosition;

        private void Awake()
        {
            EnemyBasePosition = FindObjectOfType<EnemyBase>().transform;
        }
    }
}