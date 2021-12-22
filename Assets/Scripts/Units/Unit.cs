using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Units
{
    //třída ze které dědí (budou dědit) různe jednotky 
    [RequireComponent(typeof(NavMeshAgent))]
    public class Unit : MonoBehaviour
    {
        [Header("Basic Information")]
        
        public string Name;
        public string Description;
        public Sprite Image;
        public int Price;
        public float BuildingTime = 1f;
        [Header("Stats")] 
        
        public float MovementSpeed;


        public float AttackDamage;
        public float AttackSpeed;
        public float AttackRange;
        public float Health;

        [Header("Rewards")]
        public float RewardExp;
        public float RewardMoney;
        [Header("Collision Radius")]
        public float Radius;

        [Header("Additional range to lose target")]
        public float LossRange;
        private float lossRange;

        [Header("Enemy Tags")]
        public string enemyTag;

        [Header("Actually state of tanks")]
        public float RotationSpeed;

        [HideInInspector]
        public NavMeshAgent agent;
        [HideInInspector]
        public Transform enemyBase;
        public GameObject targetedEnemy;
        public Vector3 target;
        public float attackTimer;

        public bool fighting;      

        private void Start()
        {
            agent = this.GetComponent<NavMeshAgent>();
            target = enemyBase.transform.position;
            targetedEnemy = null;
            fighting = false;
            lossRange = AttackRange + LossRange;
            attackTimer = AttackSpeed;
            agent.speed = MovementSpeed;
        }

        protected virtual void Update()
        {
            if (targetedEnemy == null)
            {
                target = enemyBase.transform.position;
                //RandomAttackBasePoint(enemyBase.transform.position, BaseRadius);
            }

            if (Health <= 0)
                Die();

            ScanForEnemies();
            float distance = Vector3.Distance(this.transform.position, target);

            if (distance < AttackRange && LineOfSight(targetedEnemy))
            {
                fighting = true;
                if (targetedEnemy)
                    Fight();
                else
                    AttackBase();
            }
            else if (!fighting || (lossRange < distance))
            {
                fighting = false;
                Move();
            }
        }

        private void ScanForEnemies()
        {
            var ray = new Ray(this.transform.position, this.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Radius))
            {
                Debug.Log($"hit: {hit.transform.gameObject.tag}");
                Debug.Log($"enemyTag : {enemyTag}");
                if (hit.transform.gameObject.tag == enemyTag)
                {
                    targetedEnemy = hit.transform.gameObject;
                    target = hit.transform.position;
                }
            }
            else
            {
                targetedEnemy = null;
            }


            //Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, Radius);
            //foreach (var hitCollider in hitColliders)
            //{
            //    if (hitCollider.tag == enemyTag)
            //    {
            //        targetedEnemy = hitCollider.gameObject;
            //        target = targetedEnemy.transform.position;
            //    }
            //}
        }

        private Vector3 RandomAttackBasePoint(Vector3 basePosition, float radius)
        {
            NavMeshHit hit;
            var vector2 = Random.insideUnitCircle.normalized * radius;
            Vector3 edgePosition = new Vector3(vector2.x, 0, vector2.y);
            NavMesh.SamplePosition(basePosition + edgePosition, out hit, 1, LayerMask.GetMask("Default"));

            return hit.position;
        }

        private bool LineOfSight(GameObject enemy)
        {
            if (targetedEnemy == null)
                return true;

            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, enemy.transform.position - this.transform.position, out hit, Mathf.Infinity, LayerMask.GetMask("Default")))
            {
                if (hit.collider.gameObject == enemy)
                    return true;
            }

            return false;
        }

        protected virtual void AttackBase()
        {

        }

        protected virtual void Die()
        {
            
        }

        protected virtual void Fight()
        {

        }

        protected virtual void Move()
        {

        }
    }
}
