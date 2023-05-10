using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoint;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoint = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (currentHitPoint <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        currentHitPoint--;
    }

    private void KillEnemy()
    {
        gameObject.SetActive(false);
    }
}
