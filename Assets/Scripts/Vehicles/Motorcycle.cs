using UnityEngine;

public class Motorcycle : Vehicle
{
    public override void Honk()
    {
        // Motorcycles don't honk
    }

    protected override bool IsFrontOccupied()
    {
        return false;
    }
    
}
