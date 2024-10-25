using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField] private float rotationSpeed;

    [SerializeField]
    private Rigidbody2D rb;

    private void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    public void DriveForward() 
    {
        var direction = transform.up;
        var forceToApply = direction * Time.deltaTime * speed;
        rb.AddForce(forceToApply, ForceMode2D.Impulse);
    }
    public void DriveBackwards()
    {
        var direction = -transform.up;
        var forceToApply = direction * Time.deltaTime * speed;
        rb.AddForce(forceToApply, ForceMode2D.Impulse);
    }
    public void SteerLeft()
    {
        var torqueToApply = Time.deltaTime * rotationSpeed;
        rb.AddTorque(torqueToApply, ForceMode2D.Impulse);
    }
    public void SteerRight()
    {
        var torqueToApply = Time.deltaTime * -rotationSpeed;
        rb.AddTorque(torqueToApply, ForceMode2D.Impulse);
    }
}
