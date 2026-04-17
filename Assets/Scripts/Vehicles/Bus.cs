using UnityEngine;

public class Bus : Vehicle
{
    private float speed = 20;
    private new float speedIncreaseMult = 1.05f;
    public new AudioClip honkSound { get; private set; }

}
