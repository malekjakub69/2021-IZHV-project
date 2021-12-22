using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Units
{
    //Třída jednotky warrior, která dědí z Unit
    public class WarriorUnit : Unit
    {
        protected override void Update()
        {
            base.Update();
        }

        protected override void Move()
        {
            if (agent.isOnNavMesh)
                agent.SetDestination(target);
        }

        protected override void Fight()
        {
            if (agent.isActiveAndEnabled)
                agent.isStopped = true;

            Rotate(targetedEnemy.transform.position);

            attackTimer -= Time.deltaTime;
            if (attackTimer < 0)
            {
                DealDamage(false);
                attackTimer = AttackSpeed;
            }
        }

        protected override void AttackBase()
        {
            if (agent.isActiveAndEnabled)
                agent.isStopped = true;

            Rotate(enemyBase.transform.position);

            attackTimer -= Time.deltaTime;
            if (attackTimer < 0)
            {
                DealDamage(true);
                attackTimer = AttackSpeed;
            }
        }

        protected override void Die()
        {
            //Transfer money
            Destroy(this.gameObject);
        }

        private void Rotate(Vector3 targetPosition)
        {
            Quaternion rotation = Quaternion.LookRotation(targetPosition);
            Quaternion.Lerp(transform.rotation, rotation, RotationSpeed);
        }

        private void DealDamage(bool attackingBase)
        {
            if (attackingBase)
            {
                //enemyBase.GetComponent <??> ().Health -= AttackDamage;
            }
            else
            {
                if (targetedEnemy == null)
                {
                    target = enemyBase.transform.position;
                    fighting = false;
                    agent.isStopped = false;
                    return;
                }

                targetedEnemy.GetComponent<Unit>().Health -= AttackDamage;
                if (targetedEnemy.GetComponent<Unit>().Health <= 0)
                {
                    target = enemyBase.transform.position;
                    fighting = false;
                    agent.isStopped = false;
                }
            }
        }
    }
}
