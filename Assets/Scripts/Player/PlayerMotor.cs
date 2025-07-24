using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;

    private bool isGrounded;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public GameObject bullet;
    public Transform firePoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;



        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit hit;
            //if(Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 200f))
            //{
            //    if(Vector3.Distance(cameraTransform.position, hit.point) > 1f)
            //    {
            //        firePoint.LookAt(hit.point);
            //    }
            //    else
            //    {
            //        firePoint.LookAt(cameraTransform.position + cameraTransform.forward * 40f);
            //    }
            //}
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; // Reset vertical velocity when grounded
        }
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity); // Calculate jump velocity
        }
    }
}
