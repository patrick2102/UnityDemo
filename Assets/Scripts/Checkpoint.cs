using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool activated;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var gameObject = collision.gameObject;

        if (gameObject.GetComponent<EnemyAI>() != null)
        {
            Debug.Log("Enemy AI triggered checkpoint!");
            activated = true;
        }
    }
}
