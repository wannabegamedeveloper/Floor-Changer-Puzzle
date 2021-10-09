using UnityEngine;

public class RobotAI : MonoBehaviour
{
    public Transform temp;

    public Transform cam;

    public Transform player;
    public Transform robotHead;

    Vector3 velocity;

    public float jumpHeight = 4f;
    public float gravity = -9.81f;

    CharacterController cc;

    Vector3 newPos;

    public float movementSpeed = .3f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        newPos = transform.position;
        temp.position = new Vector3(player.position.x, temp.position.y, player.position.z);
    }

    private void Update()
    {
        Quaternion rot = Quaternion.LookRotation(temp.position - transform.position);
        rot.x = 0f;
        rot.z = 0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 2f * Time.deltaTime);

        Quaternion robotRot = Quaternion.LookRotation(cam.position - robotHead.position);
        robotHead.rotation = Quaternion.Slerp(robotHead.rotation, robotRot, 5f * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        cc.Move(velocity * Time.deltaTime);

        transform.position = Vector3.Lerp(transform.position, new Vector3(newPos.x, transform.position.y, newPos.z), movementSpeed * Time.deltaTime);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(2) && cc.velocity.y == 0f)
        {
            if (Physics.Raycast(cam.transform.position, cam.forward, out hit))
            {
                newPos.x = hit.point.x;
                newPos.z = hit.point.z;
                temp.position = new Vector3(newPos.x, temp.position.y, newPos.z);
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Changeable")
        {
            if (hit.transform.GetComponent<FloorScript>().color == 1)
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * -9.81f);
        }
    }
}
