using UnityEngine;

public class Car : Vehicle
{
    private float speed = 45;
    private new float speedIncreaseMult = 1.2f;
    public new AudioClip honkSound { get; private set; }

}
