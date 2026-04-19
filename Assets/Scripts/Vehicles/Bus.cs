using System.Collections;
using UnityEngine;

public class Bus : Vehicle
{
    private bool isStopping;
    private float stopCooldown = 2.0f;

    public override void Move()
    {
        if (isStopping) return;

        int randInt = Random.Range(0, 500);
        if (randInt == 2)  // 0.2% / frame
        {
            StartCoroutine(DelayedMovement());
            return;
        }

        base.Move();
    }

    IEnumerator DelayedMovement()
    {
        isStopping = true;
        yield return new WaitForSeconds(stopCooldown);
        isStopping = false;
    }
}
