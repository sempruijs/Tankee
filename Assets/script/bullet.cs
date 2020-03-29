﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject particelExplotionEnemy;
    public GameObject particelExplotionObstacle;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            ExplodeEnemy();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
            ExplodeObstacle();
        }
        if (collision.gameObject.CompareTag("speedPowerUp")) {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("shieldPowerUp")) {
            Destroy(gameObject);
        }
    }

    void ExplodeEnemy() {
        GameObject ParticleSystem = Instantiate(particelExplotionEnemy, transform.position, Quaternion.identity);
        ParticleSystem.GetComponent<ParticleSystem>().Play();
        Destroy(ParticleSystem, 0.15f);
    }

    void ExplodeObstacle() {
        GameObject ParticleSystem = Instantiate(particelExplotionObstacle, transform.position, Quaternion.identity);
        ParticleSystem.GetComponent<ParticleSystem>().Play();
        Destroy(ParticleSystem, 0.15f);
    }
}
