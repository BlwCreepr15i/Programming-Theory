using System.Collections;
using UnityEngine;

public class Car : Vehicle
{
    protected bool isBoosting;
    
    protected override void RunBehavior()
    {
        if (isOccupied)
        {
            if (isBoosting) return;

            Honk();
            TempSpeedChange();
            return;
        }

        Move();
    }
    
    protected void TempSpeedChange()
    {
        StartCoroutine(TempBoost());
    }

    IEnumerator TempBoost()
    {
        isBoosting = true;
        speed *= speedIncreaseMult;
        yield return new WaitForSeconds(speedIncreaseDuration);
        speed /= speedIncreaseMult;
        isBoosting = false;
    }
}
