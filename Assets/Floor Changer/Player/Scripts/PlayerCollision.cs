using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    CharacterController cc;

    Vector3 velocity;

    public float jumpHeight = 10f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }
}
