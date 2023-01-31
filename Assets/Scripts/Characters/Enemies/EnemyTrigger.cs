using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
using Enemy;
public class EnemyTrigger : MonoBehaviour
{
    public GameObject enemyType;
    public HealthBase health;
    public bool activeEnemy =false;

 
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
            activeEnemy=true;
            enemyType.GetComponent<EnemyBase>().InitEnemy();
         
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