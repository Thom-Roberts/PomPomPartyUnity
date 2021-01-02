using UnityEngine;

public class TestMover : MonoBehaviour
{
    [Range(0, 0.5f)]
    public float moveDistance = 0.02f;
    public float tickRate = 0.25f;
    public float maxTickRate = 0.01f;
    public bool active = false;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Move), 0f, GameState.fallSpeed);
    }

    private void Move()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit, 1f)) 
        {
            Vector3 nextPosition = new Vector3(transform.position.x, transform.position.y - moveDistance, transform.position.z);
            // if(hit.collider.bounds.Contains(nextPosition)) // Of course this doesn't work, it would be too easy
            if(hit.collider.bounds.center.y + hit.collider.bounds.size.y >= nextPosition.y)
            {
                print("Cannot move");
                CancelInvoke(nameof(Move));
                return;
            }
        }

        transform.Translate(0, -moveDistance, 0);
    }

    public void ChangeSpeed(bool wasPressed)
    {
        // Increase speed to maximum
        CancelInvoke(nameof(Move));
        float newFallSpeed = wasPressed ? GameState.maxFallSpeed : GameState.fallSpeed;
        InvokeRepeating(nameof(Move), 0f, newFallSpeed);
    }

    /***************************
     * Input methods
     ****************************/
    /*

    public void OnLeft()
    {
        print("Left pressed successfully");
    }

    public void OnRight()
    {
        print("Right pressed successfully");
    }

    public void OnDown()
    {
        print("Down pressed successfully");
    }
    */
    /****************************
     * End Input methods
     ****************************/
}
