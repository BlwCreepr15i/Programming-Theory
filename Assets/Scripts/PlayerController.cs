using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;
    private float xBound = 5.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardMovement();
    }

    private void KeyboardMovement()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");        
        transform.Translate(horizontalInput * Vector3.right * speed * Time.deltaTime, Space.World);

        // rotation based on movement
        float directionCoefficient = horizontalInput / math.abs(horizontalInput);
        if (horizontalInput == 0)
        {
            directionCoefficient = 0;
        }

        transform.rotation = Quaternion.Euler(0, directionCoefficient * 90, 0);

        // Limits player movement along x-axis
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        } else if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Vehicle")) return;
        // gameOver = true;
        Debug.Log("Collided with vehicle!");
    }
}
