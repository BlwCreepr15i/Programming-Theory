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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vehicle"))
        {
            Destroy(gameObject);
        }
    }

}
