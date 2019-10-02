// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputManager/PlayerInput.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerInput : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""PlayerInputActionMap"",
            ""id"": ""5e3820fc-a301-42e3-94bc-44bfa040794b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d5fe36c8-8264-4d88-a162-fcad56d78fd1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""0fed9961-f792-4478-8028-69b3aeaea8a4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f600c7f0-f94b-4037-bb0d-08b000f336c2"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2bc022a-b851-43fa-8fa3-9a3537ca4eb5"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerInputActionMap
        m_PlayerInputActionMap = asset.FindActionMap("PlayerInputActionMap", throwIfNotFound: true);
        m_PlayerInputActionMap_Movement = m_PlayerInputActionMap.FindAction("Movement", throwIfNotFound: true);
        m_PlayerInputActionMap_Interact = m_PlayerInputActionMap.FindAction("Interact", throwIfNotFound: true);
    }

    ~PlayerInput()
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

    // PlayerInputActionMap
    private readonly InputActionMap m_PlayerInputActionMap;
    private IPlayerInputActionMapActions m_PlayerInputActionMapActionsCallbackInterface;
    private readonly InputAction m_PlayerInputActionMap_Movement;
    private readonly InputAction m_PlayerInputActionMap_Interact;
    public struct PlayerInputActionMapActions
    {
        private PlayerInput m_Wrapper;
        public PlayerInputActionMapActions(PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerInputActionMap_Movement;
        public InputAction @Interact => m_Wrapper.m_PlayerInputActionMap_Interact;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInputActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnMovement;
                Movement.canceled -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnMovement;
                Interact.started -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnInteract;
                Interact.performed -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnInteract;
                Interact.canceled -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.canceled += instance.OnMovement;
                Interact.started += instance.OnInteract;
                Interact.performed += instance.OnInteract;
                Interact.canceled += instance.OnInteract;
            }
        }
    }
    public PlayerInputActionMapActions @PlayerInputActionMap => new PlayerInputActionMapActions(this);
    public interface IPlayerInputActionMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
