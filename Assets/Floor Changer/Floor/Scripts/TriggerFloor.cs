using UnityEngine;

public class TriggerFloor : MonoBehaviour
{
    public bool start;

    public bool anim;
    public Animator obj;

    public string animName;

    private void Update()
    {
        if (start)
        {
            if (anim)
            {
                obj.SetTrigger(animName);
            }
        }
    }
}
