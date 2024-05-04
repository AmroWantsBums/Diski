using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float RotationSpeed;
    private Rigidbody PlayerRb;
    public BallController ballController;
    // Start is called before the first frame update
    void Start()
    {
        ballController = GameObject.Find("Ball").GetComponent<BallController>();
        PlayerRb = gameObject.GetComponent<Rigidbody>();
        PlayerRb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballController.CurrentPlayer.name == gameObject.name)
        {
            float MouseX = Input.GetAxis("Mouse X");
            Vector3 Rotation = new Vector3(0f, MouseX * RotationSpeed * Time.deltaTime, 0f);
            PlayerRb.MoveRotation(PlayerRb.rotation * Quaternion.Euler(Rotation));
            Vector3 moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
            moveDirection = moveDirection.normalized;
            PlayerRb.MovePosition(PlayerRb.position + moveDirection * MovementSpeed * Time.deltaTime);
        }
    }
}
