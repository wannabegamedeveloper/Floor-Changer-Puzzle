// GENERATED AUTOMATICALLY FROM 'Assets/Floor Changer/Input Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input Actions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9fb6b685-0e2b-4157-b1c2-3b81ee8ceef6"",
            ""actions"": [
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""f9ab3e8c-ad46-4950-849a-c8add51e2bcd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Color Cycle"",
                    ""type"": ""Button"",
                    ""id"": ""d514492d-a45f-45fe-a0fb-2939f57a835f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Middle Mouse"",
                    ""type"": ""Button"",
                    ""id"": ""4cc1fa8f-cdfc-4084-8d66-2bbd440ac02d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a5dc716e-aabf-4a27-baf2-e518e31c12d2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c83c996f-f89f-4644-b370-82dfeb5437c9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Color Cycle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c63c5013-603f-4dd8-81a3-446ddb713551"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Middle Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Action = m_Player.FindAction("Action", throwIfNotFound: true);
        m_Player_ColorCycle = m_Player.FindAction("Color Cycle", throwIfNotFound: true);
        m_Player_MiddleMouse = m_Player.FindAction("Middle Mouse", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Action;
    private readonly InputAction m_Player_ColorCycle;
    private readonly InputAction m_Player_MiddleMouse;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Action => m_Wrapper.m_Player_Action;
        public InputAction @ColorCycle => m_Wrapper.m_Player_ColorCycle;
        public InputAction @MiddleMouse => m_Wrapper.m_Player_MiddleMouse;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Action.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction;
                @ColorCycle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnColorCycle;
                @ColorCycle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnColorCycle;
                @ColorCycle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnColorCycle;
                @MiddleMouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMiddleMouse;
                @MiddleMouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMiddleMouse;
                @MiddleMouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMiddleMouse;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @ColorCycle.started += instance.OnColorCycle;
                @ColorCycle.performed += instance.OnColorCycle;
                @ColorCycle.canceled += instance.OnColorCycle;
                @MiddleMouse.started += instance.OnMiddleMouse;
                @MiddleMouse.performed += instance.OnMiddleMouse;
                @MiddleMouse.canceled += instance.OnMiddleMouse;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnAction(InputAction.CallbackContext context);
        void OnColorCycle(InputAction.CallbackContext context);
        void OnMiddleMouse(InputAction.CallbackContext context);
    }
}
