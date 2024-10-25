using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Car car;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            car.DriveForward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            car.DriveBackwards();
        }

        if (Input.GetKey(KeyCode.A))
        {
            car.SteerLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            car.SteerRight();
        }
    }
}
