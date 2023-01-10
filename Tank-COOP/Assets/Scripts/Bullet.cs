using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;

    public bool IsWall;

    Health health;



    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("wall"))
        {
            IsWall = true;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject;
        health = hit.GetComponent<Health>();
        Debug.Log(health);
        Debug.Log(other.tag);
        
        if (health != null)
        {
            health.TakeDamage(damage);
        }
        Destroy(gameObject);
    }


}
