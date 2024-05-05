using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamPlayers : MonoBehaviour
{
    public float SphereRadius;
    public float SphereDistance;
    public BallController ballController;
    private RaycastHit Hit;
    // Start is called before the first frame update
    void Start()
    {
        ballController = GameObject.Find("Ball").GetComponent<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.SphereCast(transform.position, SphereRadius, transform.forward, out Hit))
        {
            if (Hit.collider.gameObject.name == "Ball")
            {
                //Debug.Log("Hit");
                ballController.CurrentPlayer = Hit.collider.gameObject;
                ActivatePlayer();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SphereRadius);
    }

    void ActivatePlayer()
    {
        Debug.Log("The method is running");
        GameObject Parent = gameObject;
        for (int i = 0; i < Parent.transform.childCount; i++)
        {
            GameObject childObject = Parent.transform.GetChild(i).gameObject;
            if (childObject.CompareTag("PlayerCamera"))
            {
                ballController.CurrentPlayer = gameObject;
                ballController.PlayerActive = true;
                ballController.BallPassed = false;
                childObject.gameObject.SetActive(true);
            }
        }
    }
}
