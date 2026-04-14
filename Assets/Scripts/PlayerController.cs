using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 12f;

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

        float directionCoefficient = horizontalInput / math.abs(horizontalInput);
        if (horizontalInput == 0)
        {
            directionCoefficient = 0;
        }

        transform.rotation = Quaternion.Euler(0, directionCoefficient * 90, 0);
    }
}
