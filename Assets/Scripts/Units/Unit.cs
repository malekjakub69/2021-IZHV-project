using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Units
{
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
        public string enemyBaseTag;

        [Header("Additional range to lose target")]
        public float RotationSpeed;

        [Header("List of mesh renderers to change")]
        public List<MeshRenderer> Materials;
        [Header("Desired Material")]
        public Material Material;

        [HideInInspector]
        public NavMeshAgent agent;
        public GameObject enemyBase;
        public GameObject targetedEnemy;
        public Vector3 target;
        public float attackTimer;

        public bool fighting;      

        private void Start()
        {
            agent = this.GetComponent<NavMeshAgent>();
            enemyBase = GameObject.FindGameObjectWithTag(enemyBaseTag);
            target = enemyBase.transform.position;
            targetedEnemy = null;
            fighting = false;
            lossRange = AttackRange + LossRange;
            attackTimer = AttackSpeed;
            agent.speed = MovementSpeed;
            ChangeRendererColor();
        }

        protected virtual void Update()
        {
            if (Health <= 0)
                Die();

            ScanForEnemies();
            float distance = Vector3.Distance(this.transform.position, target);
            if (distance < AttackRange || fighting)
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

        private void ChangeRendererColor()
        {
            if (Materials != null && Materials.Count != 0)
            {
                foreach (MeshRenderer meshRenderer in Materials)
                {
                    for (int i = 0; i < meshRenderer.materials.Length; i++)
                    {
                        meshRenderer.materials[i] = Material;
                    }
                }
            }
        }

        private void ScanForEnemies()
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, Radius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag == enemyTag)
                {
                    targetedEnemy = hitCollider.gameObject;
                    target = targetedEnemy.transform.position;
                }
            }
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
