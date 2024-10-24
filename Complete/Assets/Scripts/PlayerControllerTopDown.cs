using UnityEngine;

public class PlayerControllerTopDown : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D playerRigidBody;

    [SerializeField]
    private Participant participant;

    [SerializeField]
    public float rotationSpeed;

    [SerializeField]
    public GameObject[] wheels;

    [SerializeField]
    public Car car;

    private Vector2 movementVector;
    private float movementRotation;

    private bool finished;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementVector = Vector2.zero;
        movementRotation = 0;

        if (Input.GetKey(KeyCode.W))
        {
            car.DriveForward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            car.Reverse();
        }
        else 
        {
            car.Brake();
        }

        if (Input.GetKey(KeyCode.A))
        {
            car.SteerLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            car.SteerRight();
        }
        else
        {
            car.SteerStop();
        }
    }

    private void FixedUpdate()
    {
        //MoveCar();
        //MoveCarPhysics();
    }

    //public void MoveCar()
    //{
    //    Vector2 forwardVector = transform.up;
    //    playerRigidBody.position += movementVector * speed * Time.deltaTime;

    //    if (Input.GetKeyUp(KeyCode.R))
    //    {
    //        playerRigidBody.MovePosition(playerRigidBody.position + Vector2.up);
    //        playerRigidBody.rotation = 0.0f;
    //    }
    //}

    //public void MoveCarPhysics()
    //{
    //    var x = transform.right.x;
    //    var y = transform.right.y;

    //    var forwardVector = new Vector2(x, y);

    //    var forceToApply = movementVector * speed * Time.fixedDeltaTime;
    //    var rotationToApply = movementRotation * rotationSpeed * Time.fixedDeltaTime;

    //    playerRigidBody.AddForce(forceToApply, ForceMode2D.Impulse);
    //    playerRigidBody.AddTorque(rotationToApply, ForceMode2D.Impulse);

    //    if (Input.GetKeyUp(KeyCode.R))
    //    {
    //        playerRigidBody.MovePosition(playerRigidBody.position + Vector2.up);
    //        playerRigidBody.rotation = 0.0f;
    //    }
    //}
}
