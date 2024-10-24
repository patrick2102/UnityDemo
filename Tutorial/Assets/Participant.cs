using UnityEngine;

public class Participant : MonoBehaviour
{
    private Checkpoint[] checkpoints;
    private bool[] activatedCheckpoints;
    public Checkpoint currentCheckpoint;

    private int currentIndex;
    private bool finished;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkpoints = GameManager.Instance.checkpoints;
        if (checkpoints.Length > 0)
        {
            currentIndex = 0;
            currentCheckpoint = checkpoints[currentIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCheckpoint.activated)
        {
            var lastIndex = checkpoints.Length - 1;
            if (currentCheckpoint == checkpoints[lastIndex])
            {
                finished = true;
            }
            else
            {
                currentIndex += 1;
                currentCheckpoint = checkpoints[currentIndex];
            }
        }
    }



    public void SetNewCheckpoint()
    {
        var lastIndex = checkpoints.Length - 1;
        if (currentCheckpoint == checkpoints[lastIndex])
        {
            finished = true;
            currentCheckpoint = null;
        }
        else
        {
            currentIndex += 1;
            currentCheckpoint = checkpoints[currentIndex];
        }
    }

    public void EnterCheckpoint(Checkpoint checkpoint)
    {
        if (checkpoint == currentCheckpoint)
        {
            SetNewCheckpoint();
        }
    }

    public bool GetIsFinished()
    {
        return finished;
    }
}
