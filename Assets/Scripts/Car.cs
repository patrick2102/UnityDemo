using UnityEngine;

public class Car : MonoBehaviour
{
    private enum DriveState
    {
        stopping, driving, reversing
    }

    private enum SteerState
    {
        notSteering, steeringLeft, steeringRight
    }

    private DriveState currentDriveState;
    private SteerState currentSteeringState;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private Vector2 movementVector;

    private float movementRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        currentDriveState = DriveState.stopping;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentDriveState)
        {
            case DriveState.stopping:
                movementVector = Vector2.zero;
                break;
            case DriveState.driving:
                movementVector = transform.up.normalized;
                break;
            case DriveState.reversing:
                movementVector = -transform.up.normalized;
                break;
        }

        switch (currentSteeringState)
        {
            case SteerState.steeringLeft:
                movementRotation = 1;
                break;
            case SteerState.steeringRight:
                movementRotation = -1;
                break;
            case SteerState.notSteering:
                movementRotation = 0;
                break;
        }
    }

    private void FixedUpdate()
    {
        var forceToApply = movementVector * speed * Time.fixedDeltaTime;
        rb.AddForce(forceToApply, ForceMode2D.Impulse);

        var rotationToApply = movementRotation * rotationSpeed * Time.fixedDeltaTime;
        rb.AddTorque(rotationToApply, ForceMode2D.Impulse);
    }

    public void DriveForward()
    {
        currentDriveState = DriveState.driving;
    }

    public void Reverse()
    {
        currentDriveState = DriveState.reversing;
    }

    public void Brake()
    {
        currentDriveState = DriveState.stopping;
    }

    public void SteerLeft()
    {
        currentSteeringState = SteerState.steeringLeft;
    }

    public void SteerRight()
    {
        currentSteeringState = SteerState.steeringRight;

    }

    public void SteerStop()
    {
        currentSteeringState = SteerState.notSteering;
    }
}
