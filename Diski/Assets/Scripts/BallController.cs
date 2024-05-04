using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject CurrentPlayer;
    private Rigidbody BallRb;
    public float distanceAhead;
    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayer = GameObject.Find("Player");
        BallRb = gameObject.GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CurrentPos = new Vector3(CurrentPlayer.transform.position.x, -0.48f, CurrentPlayer.transform.position.z);
        Vector3 targetPosition = CurrentPos + CurrentPlayer.transform.forward * distanceAhead;
        transform.position = targetPosition;
    }
}
