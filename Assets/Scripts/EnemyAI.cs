using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Checkpoint[] checkpoints;

    private int currentIndex;

    private Checkpoint currentCheckpoint;

    [SerializeField]
    private Car car;

    [SerializeField]
    private Participant participant;

    private bool finished;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finished = false;
        checkpoints = GameManager.Instance.checkpoints;
        currentIndex = 0;
        if(checkpoints.Length > 0)
            currentCheckpoint = checkpoints[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        DriveTowardsCheckpoint();
        //if (currentCheckpoint.activated)
        //{ 
        //    var lastIndex = checkpoints.Length - 1;
        //    if (currentCheckpoint == checkpoints[lastIndex])
        //    {
        //        //Reached end, do nothing.
        //        car.Brake();
        //        finished = true;
        //    }
        //    else
        //    {
        //        currentIndex += 1;
        //        currentCheckpoint = checkpoints[currentIndex];
        //    }
        //}
    }

    public void DriveTowardsCheckpoint() 
    {
        var currentCheckpoint = participant.GetCurrentCheckpoint();
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
}
