using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
using Boss;
public class BossTrigger : MonoBehaviour
{
    public GameObject enemyType;
    public HealthBase health;
    public bool activeEnemy;


    public void Update()
    {
        ActiveEnemy();
    }

    public void ActiveEnemy()
    {
        if (activeEnemy)
            enemyType.SetActive(true);
        else if
            (!activeEnemy)
            enemyType.SetActive(false);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            activeEnemy = true;
            BossBase boss = enemyType.GetComponent<BossBase>();
            boss.SwitchWalk();
            enemyType.GetComponent<BossBase>().BossInitAttack();

        }

    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health.ResetLife();
        }

    }
}