using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum AIState 
    {
        drivingTowardsCheckpoint, reversing, stopped
    }

    private AIState currentState;
    private float aiStateTimer;

    private Checkpoint[] checkpoints;

    [SerializeField]
    private Car car;

    [SerializeField]
    private Participant participant;

    private Vector2 prevPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = AIState.drivingTowardsCheckpoint;
        checkpoints = GameManager.Instance.checkpoints;
        prevPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        aiStateTimer += Time.deltaTime;

        if (aiStateTimer > 1.0f)
        { 
            UpdateAIState();
            aiStateTimer = 0.0f;
        }

        switch (currentState)
        { 
            case AIState.drivingTowardsCheckpoint:
                DriveTowardsCheckpoint(); break;
            case AIState.reversing:
                Reversing(); break;
            case AIState.stopped:
                Stopping(); break;
        }
    }

    public void DriveTowardsCheckpoint() 
    {
        var currentCheckpoint = participant.currentCheckpoint;
        if (currentCheckpoint == null)
            return;

        var vectorFromTransformToCheckpoint = currentCheckpoint.transform.position - transform.position;
        var currentForwardVector = car.transform.up;

        var angle = Vector2.SignedAngle(currentForwardVector, vectorFromTransformToCheckpoint);

        if (angle > 15.0f)
            car.SteerLeft();
        else if (angle < -15.0f)
            car.SteerRight();
        else
        {
            car.SteerStop();
            car.DriveForward();
        }
        Debug.Log(angle);
    }

    private void Reversing()
    { 
        car.Reverse();
    }

    private void Stopping()
    {
        car.Brake();
        car.SteerStop();
    }


    void UpdateAIState() 
    {
        if (currentState == AIState.drivingTowardsCheckpoint)
        {
            var stuck = CheckIfStuck();
            if (stuck)
            {
                currentState = AIState.reversing;
            }
        }

        else if(currentState == AIState.reversing)
        {
            currentState = AIState.drivingTowardsCheckpoint;
        }

        if(participant.GetIsFinished())
        {
            currentState = AIState.stopped;
        }
    }

    bool CheckIfStuck() 
    {
        var dist = ((Vector2)transform.position - prevPosition).magnitude;
        prevPosition = transform.position;
        if (dist < 0.1f)
        {
            return true;
        }
        else
            return false;
    }
}
