using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timer = 0.0f;
    private float randomWaitTime = 5.0f;

    public EnemyManager enemyManager;

    private void Update()
    {
        timer  = timer + Time.deltaTime;
        if (timer > randomWaitTime)
        {
            randomWaitTime = Random.Range(9f, 15f);
            // enemyManager.relocate.Invoke();
            enemyManager.speak.Invoke();
            timer = timer - randomWaitTime;
        }
    }
}
