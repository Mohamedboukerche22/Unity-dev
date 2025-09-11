using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float speed = 6f;
   public float grafity = 20f;
   public float jump = 5f;
   CharacterController controller;
   Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(controller.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), .0f,Input.GetAxis("Vertical"));
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);
            if(Input.GetButton("Jump")){
                moveDirection.y = jump;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            speed = 12f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = 6f;
        }
        moveDirection.y -= grafity * Time.deltaTime;
        controller.Move(moveDirection*Time.deltaTime);
    }
}
