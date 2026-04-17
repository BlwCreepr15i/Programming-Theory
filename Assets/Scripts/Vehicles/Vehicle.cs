using UnityEngine;

public class Vehicle : MonoBehaviour
{
    // Variables
    
    [SerializeField]
    private float speed = 25;
    protected float speedIncreaseMult = 1.1f;

    public Vector3 moveDirection = Vector3.forward;
    public AudioClip honkSound { get; private set; }

    void Start()
    {
        
    }

    public void IncreaseSpeed()
    {
        speed *= speedIncreaseMult;
    }

    public void Honk()
    {
        AudioSource.PlayClipAtPoint(honkSound, transform.position);
    }

    public void Move()
    {
        transform.Translate(moveDirection * Time.deltaTime * speed);
    }
}
