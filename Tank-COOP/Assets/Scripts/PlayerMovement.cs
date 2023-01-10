using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This script will make the object rotate towards the direction of the movement,
 * the rotation speed is determined by the rotationSpeed variable, which can be adjusted to suit your needs.
 */

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;

    public GameObject Bullet;

    public Transform ShootingPoint;

    public float rotationSpeed;

    public float BulletSpeed;

    public bool IsDead;

    private Health health;
    private Rigidbody rb;

    float horizontal;
    float vertical;

    private void Start()
    {
        IsDead = false;
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
        CheckHealth();
    }

    private void FixedUpdate()
    {
        
        rb.velocity = transform.forward * vertical * MovementSpeed * Time.fixedDeltaTime;


        if (horizontal == 0)
            rb.angularVelocity = Vector3.zero;
        else
            rb.angularVelocity = Vector3.up * horizontal * rotationSpeed * Time.fixedDeltaTime;
            

    }

    private void Move()
    {

        horizontal = 0.0f;
        vertical = 0.0f;

        if (Input.GetKey(KeyCode.W))
            vertical += 1.0f;
        if (Input.GetKey(KeyCode.S))
            vertical -= 1.0f;
        if (Input.GetKey(KeyCode.D))
            horizontal += 1.0f;
        if (Input.GetKey(KeyCode.A))
            horizontal -= 1.0f;

        
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject instBullet = Instantiate(Bullet, ShootingPoint.position, ShootingPoint.rotation);

            Rigidbody bulletRB = instBullet.GetComponent<Rigidbody>();
            bulletRB.AddForce(ShootingPoint.forward * BulletSpeed);
        }
    }

    private void CheckHealth()
    {
        if(health.health <= 0)
        {
            IsDead = true;
        }
    }
}
