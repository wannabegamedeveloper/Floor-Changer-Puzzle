using UnityEngine;

public class TriggerFloor : MonoBehaviour
{
    public bool start;

    public bool anim;
    public Animator obj;

    public bool move;
    public Transform obj2;
    Vector3 startPos;

    public string animName;

    private void Start()
    {
        if (move)
            startPos = obj2.position;
    }

    private void Update()
    {
        if (start)
        {
            if (anim)
            {
                obj.SetTrigger(animName);
            }
            if (move)
            {
                obj2.position = Vector3.Lerp(obj2.position, startPos + Vector3.up * 2f, 2f * Time.deltaTime);
            }
        }
        else
        {
            if (move)
                obj2.position = Vector3.Lerp(obj2.position, startPos, 2f * Time.deltaTime);
        }

    }
}
