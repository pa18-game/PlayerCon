using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public Text scoretxt;
    float speed = 10f;
    float Gravity = -10f;
    public Vector3 move;
    float jump = 10f;
    public int Score = 0;
    public bool isGrounded;
    public Vector3 velicity;
    public Transform GroundCheck;
    public float groundchecked = 0.4f;
    public LayerMask Groundmask;

    private void Start()
    {
        scoretxt.text = "Score ";
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundchecked, Groundmask);
        if(isGrounded&&velicity.y<0)
        {
            velicity.y = -2f;
        }
        float Movex = Input.GetAxis("Horizontal");
        float Movey = Input.GetAxis("Vertical");

        move = transform.right * Movex + transform.forward*Movey;
        characterController.Move(move * speed * Time.deltaTime);

        velicity.y += Gravity * Time.deltaTime;
        characterController.Move(velicity* Time.deltaTime);





    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Coin")
        {
            Score++;
            scoretxt.text = "Score " + Score.ToString();
            Destroy(hit.gameObject);
        }
    }
}
