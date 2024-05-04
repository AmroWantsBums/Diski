using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject CurrentPlayer;
    private Rigidbody BallRb;
    public float distanceAhead;
    private bool PlayerActive = true;
    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayer = GameObject.Find("Player");
        BallRb = gameObject.GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerActive)
        {
            Vector3 CurrentPos = new Vector3(CurrentPlayer.transform.position.x, -0.48f, CurrentPlayer.transform.position.z);
            Vector3 targetPosition = CurrentPos + CurrentPlayer.transform.forward * distanceAhead;
            transform.position = targetPosition;
        }

        if (Input.GetKeyDown("space"))
        {
            PassBall();
        }
    }

    void PassBall()
    {
        PlayerActive = false;
        BallRb.AddForce(CurrentPlayer.transform.forward * 1000);
        CurrentPlayer = null;
    }
}
