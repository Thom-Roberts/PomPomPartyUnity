using UnityEngine;
using UnityEngine.Events;

public class PieceController : MonoBehaviour
{
    public Colors color = Colors.Red; // Should be set externally by the spawner
    public bool active = true;
    public float fallSpeed = 0.1f;

    public UnityEvent landedEvent;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
            ManageLeftRightInput();
    }

    private void FixedUpdate()
    {
        if (active)
            MoveDown();
    }

    private void ManageLeftRightInput()
    {
        var currentPosition = transform.position;
        Vector3? desiredPosition = null;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            desiredPosition = new Vector3(currentPosition.x - 1, currentPosition.y, currentPosition.z);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            desiredPosition = new Vector3(currentPosition.x + 1, currentPosition.y, currentPosition.z);

        if (desiredPosition == null)
            return;

        // Attempt to move
        RaycastHit hit;
        if (rb.SweepTest((Vector3)(desiredPosition - currentPosition), out hit, 1.0f))
        {
            if (hit.collider.CompareTag("Boundary") || hit.collider.CompareTag("Piece"))
            {
                print("Would collide with something. Preventing movement");
                return;
            }
        }

        transform.position = (Vector3)desiredPosition;
    }

    private void MoveDown()
    {
        // Check speed
        var prevPosition = transform.position;
        var newPosition = new Vector3(prevPosition.x, prevPosition.y - fallSpeed, prevPosition.z);
        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        active = false;
        rb.isKinematic = true;
        landedEvent?.Invoke();
    }
}