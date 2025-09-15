using UnityEngine;

public class Playermovement : MonoBehaviour
{
   public float speed = 6f;
   public float gravity = 20f;
   public float jump = 2f;
   public float rotspeed = 80f;
   float rot = 0f;
   CharacterController controller;
   Vector3 moveDirection = Vector3.zero;
   float horizontal;
   float vertical;
   Animator anim;
    void Start()
    {
       
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(controller.isGrounded){
            moveDirection = new Vector3(0,0.0f,vertical);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);
            if(Input.GetButton("Jump")){
                anim.SetBool("isjumping" , true);
                moveDirection.y = jump;
            }
            else{
                anim.SetBool("isjumping" , false);
            }
            if(Input.GetKey(KeyCode.W)){
                anim.SetBool("iswalking" , true);
            }else{
                anim.SetBool("iswalking" , false);
            }

        }
        rot +=Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0,rot,0);

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection*Time.deltaTime);
        
    }
}
