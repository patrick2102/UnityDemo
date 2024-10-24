using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public GameObject playerGameObject;

    [SerializeField]
    public Rigidbody2D playerRigidBody;

    [SerializeField]
    public int speed;

    [SerializeField]
    public float rotationSpeed;

    [SerializeField]
    public GameObject[] wheels;

    private Vector2 movementVector;
    private float movementRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = transform.right.x;
        var y = transform.right.y;

        var forwardVector = new Vector2(x, y);

        movementVector = Vector2.zero;
        movementRotation = 0;

        if (Input.GetKey(KeyCode.W))
        {
            movementVector = forwardVector.normalized;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementVector = -forwardVector.normalized;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementRotation = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movementRotation = -1;
        }
    }

    private void FixedUpdate()
    {
        //MoveCar();
        MoveCarPhysics();
    }

    public void MoveCar() 
    {
        var x = transform.right.x;
        var y = transform.right.y;

        var forwardVector = new Vector2(x, y);

        if (Input.GetKey(KeyCode.W))
        {
            //playerRigidBody.position += playerRigidBody. * speed;
            playerRigidBody.position += forwardVector * speed * Time.deltaTime;
            //playerRigidBody.AddForce()
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerRigidBody.position -= forwardVector * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {

        }
        else if (Input.GetKey(KeyCode.D))
        {

        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            playerRigidBody.MovePosition(playerRigidBody.position + Vector2.up);
            playerRigidBody.rotation = 0.0f;
        }
    }

    public void MoveCarPhysics()
    {
        var x = transform.right.x;
        var y = transform.right.y;

        var forwardVector = new Vector2(x, y);

        var forceToApply = movementVector * speed * Time.fixedDeltaTime;
        var rotationToApply = movementRotation * rotationSpeed * Time.fixedDeltaTime;

        playerRigidBody.AddForce(forceToApply, ForceMode2D.Impulse);
        playerRigidBody.AddTorque(rotationToApply, ForceMode2D.Impulse);

        if (Input.GetKeyUp(KeyCode.R))
        {
            playerRigidBody.MovePosition(playerRigidBody.position + Vector2.up);
            playerRigidBody.rotation = 0.0f;
        }
    }
}
