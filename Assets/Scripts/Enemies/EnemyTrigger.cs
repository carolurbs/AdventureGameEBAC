using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
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
        }

    }
   
}