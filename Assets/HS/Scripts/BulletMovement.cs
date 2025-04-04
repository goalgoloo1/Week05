﻿using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody rb;
    public GameObject enemyShooter; //쏜놈

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (TEMPGameManager.Instance != null)
        {
            TEMPGameManager.Instance.RegisterBullet(gameObject);
        }
    }

    void Update()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (TEMPGameManager.Instance != null)
        {
            TEMPGameManager.Instance.OnBulletCollision(gameObject, collision.gameObject);
        }

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (TEMPGameManager.Instance != null)
        {
            TEMPGameManager.Instance.UnregisterBullet(gameObject);
        }
    }
}
