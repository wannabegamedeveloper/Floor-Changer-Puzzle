using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;
using System;

public class PlayerRaycast : MonoBehaviour
{
    public Transform cam;
    public RectTransform image;
    public Image image2;

    public GameObject[] markers;

    public Material green;
    public Material red;
    public Material purple;
    public Material pink;
    public Material off;

    ColorCycle cycle;

    public float scale = .2f;
    public byte color1 = 255;
    public byte color2 = 255;
    public byte color3 = 255;

    bool raycastHit;

    private InputActions input;
    private InputAction inputAction;

    RaycastHit hit;
    bool rayHit;

    private void Awake()
    {
        input = new InputActions();
    }

    private void OnEnable()
    {
        inputAction = input.Player.Action;
        inputAction.Enable();

        input.Player.Action.performed += Shoot;
        input.Player.Action.Enable();

        input.Player.ColorCycle.performed += Cycle;
        input.Player.ColorCycle.Enable();

        input.Player.MiddleMouse.performed += Cycle;
        input.Player.MiddleMouse.Enable();
    }

    private void Cycle(InputAction.CallbackContext obj)
    {
        scale = .2f;
        StartCoroutine(Delay());
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        scale = .2f;
        StartCoroutine(Delay());
        if (rayHit)
        {
            if (hit.transform.GetComponent<FloorScript>().color == 0)
            {
                if (cycle.color == 1)
                    hit.transform.GetComponent<MeshRenderer>().material = green;
                else if (cycle.color == 2)
                    hit.transform.GetComponent<MeshRenderer>().material = red;
                else if (cycle.color == 3)
                    hit.transform.GetComponent<MeshRenderer>().material = purple;
                else if (cycle.color == 4)
                    hit.transform.GetComponent<MeshRenderer>().material = pink;
                hit.transform.GetComponent<FloorScript>().color = cycle.color;
            }
            else
            {
                hit.transform.GetComponent<MeshRenderer>().material = off;
                hit.transform.GetComponent<FloorScript>().color = 0;
            }
        }
    }

    private void OnDisable()
    {
        inputAction.Disable();
        input.Player.Action.Disable();
        input.Player.ColorCycle.Disable();
    }

    private void Start()
    {
        cycle = GetComponent<ColorCycle>();
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(.1f);
        scale = .3192735f;
    }

    private void Update()
    {
        image.localScale = Vector3.Lerp(image.localScale, new Vector3(scale, scale, scale), 10 * Time.deltaTime);
        image2.color = Color32.Lerp(image2.color, new Color32(color1, color2, color3, 255), 10f * Time.deltaTime);
        image.GetComponent<Image>().color = Color32.Lerp(image.GetComponent<Image>().color, new Color32(color1, color2, color3, 255), 10f * Time.deltaTime);

        if (Input.GetMouseButtonDown(2) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
        }
        
        if (Physics.Raycast(cam.position, cam.forward, out hit))
        {
            if (hit.transform.CompareTag("Changeable"))
            {
                rayHit = true;
                if (raycastHit)
                {
                    scale = .2f;
                    raycastHit = false;
                }
                color1 = 255;
                color2 = 0;
                color3 = 0;
                hit.transform.GetChild(0).gameObject.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    //if (hit.transform.GetComponent<FloorScript>().color == 0)
                    //{
                    //    if (cycle.color == 1)
                    //        hit.transform.GetComponent<MeshRenderer>().material = green;
                    //    else if (cycle.color == 2)
                    //        hit.transform.GetComponent<MeshRenderer>().material = red;
                    //    else if (cycle.color == 3)
                    //        hit.transform.GetComponent<MeshRenderer>().material = purple;
                    //    else if (cycle.color == 4)
                    //        hit.transform.GetComponent<MeshRenderer>().material = pink;
                    //    hit.transform.GetComponent<FloorScript>().color = cycle.color;
                    //}
                    //else
                    //{
                    //    hit.transform.GetComponent<MeshRenderer>().material = off;
                    //    hit.transform.GetComponent<FloorScript>().color = 0;
                    //}
                }
            }
            else
            {
                rayHit = false;
                if (!raycastHit)
                {
                    scale = .3192735f;
                    raycastHit = true;
                }
                color1 = 255;
                color2 = 255;
                color3 = 255;
                foreach (GameObject marker in markers)
                    marker.SetActive(false);
            }

        }
        else
            foreach (GameObject marker in markers)
                marker.SetActive(false);
    }
}
