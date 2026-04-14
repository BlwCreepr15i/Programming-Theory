using UnityEngine;

public class Truck : Vehicle
{
    private float speed = 20;
    private new float speedIncreaseMult = 1.05f;
    public new AudioClip honkSound { get; private set; }


}
