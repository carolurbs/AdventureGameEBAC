using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timeToDestroy = 2f;
    public int damageAmount = 1;
    public float speed = 50f;
    public List<string> tagsToHit;
    public List <string> tagsToMiss = new List<string>();
    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {

        transform.Translate(Vector3.forward*Time.deltaTime*speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < tagsToMiss.Count; i++)
        {
            if (collision.gameObject.CompareTag(tagsToMiss[i]))
                return; 
        }
        foreach (var t in tagsToHit)
        if (collision.transform.tag==t)
        {
        var damageable = collision.transform.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Vector3 dir = collision.transform.position - transform.position;
            dir = -dir.normalized;
            dir.y = 0;
            damageable.Damage(damageAmount);
        }
        break;
        }   
        Destroy(gameObject);
    }
}