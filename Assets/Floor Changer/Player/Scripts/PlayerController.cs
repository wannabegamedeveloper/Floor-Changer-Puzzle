using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;

    public float speed;
    public float gravity = -9.81f;

    public float xSens;
    public float ySens;

    public Vector3 velocity;

    public Transform groundCheck;
    public float groundRadius = .4f;
    public LayerMask ground;

    public Transform rotator;

    public float jumpHeight = 3f;

    bool grounded;

    public float rotSpeed = 1f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundRadius, ground);

        if (grounded && velocity.y < 0)
            velocity.y = -2f;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X") * xSens;
        float mouseY = Input.GetAxis("Mouse Y") * ySens;

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        cc.Move(move * Time.deltaTime * speed);

        transform.Rotate(new Vector3(0f, mouseX, 0f));
        transform.GetChild(0).Rotate(new Vector3(mouseY, 0f, 0f));

        velocity.y += gravity * Time.deltaTime;

        cc.Move(velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Changeable"))
        {
            if (hit.transform.GetComponent<FloorScript>().color == 1)
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * -9.81f);
            else if (hit.transform.GetComponent<FloorScript>().color == 2) { }
            else if (hit.transform.GetComponent<FloorScript>().color == 3 && hit.transform.GetComponent<TriggerFloor>())
                hit.transform.GetComponent<TriggerFloor>().start = true;

        }
    }
}
