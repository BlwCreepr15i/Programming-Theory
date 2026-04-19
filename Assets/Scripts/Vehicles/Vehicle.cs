using System.Collections;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    // Variables
    [SerializeField]
    protected LayerMask vehicleLayer;
    private float checkDist;
    [SerializeField]
    protected bool isOccupied;
    [SerializeField]
    protected float speed = 15;
    [SerializeField]
    protected float speedIncreaseMult = 1.1f;
    protected float speedIncreaseDuration = 1.0f;
    [SerializeField]
    protected AudioClip honkSound;

    private float zBound = -19;

    void Start()
    {
        checkDist = GetComponent<BoxCollider>().size.z / 2 * 1.2f;
    }
    void FixedUpdate()
    {
        isOccupied = IsFrontOccupied();
    }
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.back*checkDist, Color.blue);
        CheckForOutofBound();
        RunBehavior();
    }

    protected virtual void RunBehavior()
    {
        if (isOccupied)
        {
            Honk();
        } else
        {
            Move();
        }
    }

    protected void CheckForOutofBound()
    {
        if (transform.position.z <= zBound)
        {
            Destroy(gameObject);
        }
    }

    protected virtual bool IsFrontOccupied()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, Vector3.back, out hit, checkDist, vehicleLayer); 
    }

    public virtual void Honk()
    {
        // TBI
        // AudioSource.PlayClipAtPoint(honkSound, transform.position);
    }

    public virtual void Move() // virtual means can be overridden
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
