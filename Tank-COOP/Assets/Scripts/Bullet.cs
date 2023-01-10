using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;

    public float DestroyAfterTime = 5f;

    public bool IsWall;

    Health health;

    private void Awake()
    {
        StartCoroutine(DestroyAfter());
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("wall"))
        {
            IsWall = true;
            
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            IsWall = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        IsWall = false;
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

    IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(DestroyAfterTime);

        Destroy(this.gameObject);
    }


}
