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
                Debug.Log("Hit");
                ballController.CurrentPlayer = Hit.collider.gameObject;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SphereRadius);
    }

    /*void ActivatePlayer()
    {
        GameObject Parent;
        for (int i = 0; i < Parent.childCount; i++)
        {
            GameObject childObject = parentTransform.GetChild(i).gameObject;
            if (i.gameObject.CompareTag("Camera"))
            {
                i.gameObject
            }
        }
    }*/
}
