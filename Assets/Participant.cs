using UnityEngine;

public class Participant : MonoBehaviour
{
    private Checkpoint[] checkpoints;
    private Checkpoint currentCheckpoint;

    private int currentIndex;
    private bool finished;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

    public Checkpoint GetCurrentCheckpoint()
    {
        if (currentCheckpoint.activated)
        {
            var lastIndex = checkpoints.Length - 1;
            if (currentCheckpoint == checkpoints[lastIndex])
            {
                finished = true;
                return null;
            }
            else
            {
                currentIndex += 1;
                currentCheckpoint = checkpoints[currentIndex];
                return currentCheckpoint;
            }
        }
        else 
        {
            return currentCheckpoint;
        }
    }
}
