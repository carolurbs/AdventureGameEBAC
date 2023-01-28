using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
using Boss;
public class BossTrigger : MonoBehaviour
{
    public GameObject enemyType;

    public void Awake()
    {
        enemyType.SetActive(false);
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyType.SetActive(true);
            BossBase boss = enemyType.GetComponent<BossBase>();
            boss.SwitchWalk();
        }

    }
   
}