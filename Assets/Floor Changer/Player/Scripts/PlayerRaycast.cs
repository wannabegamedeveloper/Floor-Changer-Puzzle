using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

    bool raycastHit;

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

        if (Input.GetMouseButtonDown(2) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            scale = .2f;
            StartCoroutine(Delay());
        }

        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit))
        {
            if (hit.transform.CompareTag("Changeable"))
            {
                if (raycastHit)
                {
                    scale = .2f;
                    raycastHit = false;
                }
                image2.color = Color32.Lerp(image2.color, new Color32(255, 0, 0, 255), 10f * Time.deltaTime);
                image.GetComponent<Image>().color = Color32.Lerp(image.GetComponent<Image>().color, new Color32(255, 0, 0, 255), 10f * Time.deltaTime);
                hit.transform.GetChild(0).gameObject.SetActive(true);
                if (Input.GetMouseButtonDown(0))
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
            else
            {
                if (!raycastHit)
                {
                    scale = .3192735f;
                    raycastHit = true;
                }
                image2.color = Color32.Lerp(image2.color, new Color32(255, 255, 255, 255), 10f * Time.deltaTime);
                image.GetComponent<Image>().color = Color32.Lerp(image.GetComponent<Image>().color, new Color32(255, 255, 255, 255), 10f * Time.deltaTime);
                foreach (GameObject marker in markers)
                    marker.SetActive(false);
            }

        }
        else
            foreach (GameObject marker in markers)
                marker.SetActive(false);
    }
}
