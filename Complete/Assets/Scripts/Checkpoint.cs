using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var gameObject = collision.gameObject;

        //if (gameObject.GetComponent<EnemyAI>() != null)
        //{
        //    Debug.Log("Enemy AI triggered checkpoint!");
        //    activated = true;
        //}

        var participant = gameObject.GetComponent<Participant>();
        if (participant != null)
        {
            participant.EnterCheckpoint(this);
        }
    }
}
