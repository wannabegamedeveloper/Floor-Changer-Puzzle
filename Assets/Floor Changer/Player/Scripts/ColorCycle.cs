using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorCycle : MonoBehaviour
{
    public int color = 1;

    public Vector3[] colorSelectPOS;
    public Vector3[] colorSelectSCALE;
    public RectTransform[] colorSelectUI;

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
        inputAction = input.Player.ColorCycle;
        inputAction.Enable();

        input.Player.ColorCycle.performed += Cycle;
        input.Player.ColorCycle.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
        input.Player.ColorCycle.Disable();
    }

    private void Cycle(InputAction.CallbackContext obj)
    {
        if (color < 4)
            color++;
        else
            color = 1;
    }

    private void Update()
    {

        for (int i = 0; i < colorSelectUI.Length; i++)
        {
            if (i != 0)
            {
                if (color == i)
                    colorSelectUI[i].anchoredPosition = Vector2.Lerp(colorSelectUI[i].anchoredPosition, new Vector2(colorSelectUI[i].anchoredPosition.x, -203f), 10f * Time.deltaTime);
                else
                    colorSelectUI[i].anchoredPosition = Vector2.Lerp(colorSelectUI[i].anchoredPosition, new Vector2(colorSelectUI[i].anchoredPosition.x, -248.8f), 10f * Time.deltaTime);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            
        }
    }
}
