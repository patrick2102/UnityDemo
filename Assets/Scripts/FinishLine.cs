using UnityEngine;

public class FinishLine : MonoBehaviour
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
        var tag = collision.gameObject.tag;

        if (tag.Equals("Player"))
        {
            Debug.Log($"{collision.gameObject.name} reached the finish line");
        }
    }
}
