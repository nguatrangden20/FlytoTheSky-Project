// GENERATED AUTOMATICALLY FROM 'Assets/PlayerAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerAction"",
    ""maps"": [
        {
            ""name"": ""PlayerController"",
            ""id"": ""b4fb67ae-f8f3-4318-ac2c-929d4b39f185"",
            ""actions"": [
                {
                    ""name"": ""ToggleDebug"",
                    ""type"": ""Button"",
                    ""id"": ""35ecce64-a43a-4dd6-af49-23a083f296af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EnterCommand"",
                    ""type"": ""Button"",
                    ""id"": ""21d12e63-934b-407a-acc7-4009abbb930a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartShip"",
                    ""type"": ""Button"",
                    ""id"": ""153dab43-bf86-46ad-8603-a1af656f4a62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartShipFinish"",
                    ""type"": ""Button"",
                    ""id"": ""4b67023f-d42a-410f-a9eb-49f81f852455"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1ed4f1ba-8dde-4c25-b020-f3dad65a4e60"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07d06ea4-8e0e-48c2-96c4-e5f51cb74779"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterCommand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""090e9157-9631-4231-8660-b1add80a2278"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartShip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23f181cb-24be-40f6-b192-7e79d7ffa90d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartShipFinish"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerController
        m_PlayerController = asset.FindActionMap("PlayerController", throwIfNotFound: true);
        m_PlayerController_ToggleDebug = m_PlayerController.FindAction("ToggleDebug", throwIfNotFound: true);
        m_PlayerController_EnterCommand = m_PlayerController.FindAction("EnterCommand", throwIfNotFound: true);
        m_PlayerController_StartShip = m_PlayerController.FindAction("StartShip", throwIfNotFound: true);
        m_PlayerController_StartShipFinish = m_PlayerController.FindAction("StartShipFinish", throwIfNotFound: true);
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

    // PlayerController
    private readonly InputActionMap m_PlayerController;
    private IPlayerControllerActions m_PlayerControllerActionsCallbackInterface;
    private readonly InputAction m_PlayerController_ToggleDebug;
    private readonly InputAction m_PlayerController_EnterCommand;
    private readonly InputAction m_PlayerController_StartShip;
    private readonly InputAction m_PlayerController_StartShipFinish;
    public struct PlayerControllerActions
    {
        private @PlayerAction m_Wrapper;
        public PlayerControllerActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleDebug => m_Wrapper.m_PlayerController_ToggleDebug;
        public InputAction @EnterCommand => m_Wrapper.m_PlayerController_EnterCommand;
        public InputAction @StartShip => m_Wrapper.m_PlayerController_StartShip;
        public InputAction @StartShipFinish => m_Wrapper.m_PlayerController_StartShipFinish;
        public InputActionMap Get() { return m_Wrapper.m_PlayerController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControllerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControllerActions instance)
        {
            if (m_Wrapper.m_PlayerControllerActionsCallbackInterface != null)
            {
                @ToggleDebug.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnToggleDebug;
                @ToggleDebug.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnToggleDebug;
                @ToggleDebug.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnToggleDebug;
                @EnterCommand.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnEnterCommand;
                @EnterCommand.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnEnterCommand;
                @EnterCommand.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnEnterCommand;
                @StartShip.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnStartShip;
                @StartShip.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnStartShip;
                @StartShip.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnStartShip;
                @StartShipFinish.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnStartShipFinish;
                @StartShipFinish.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnStartShipFinish;
                @StartShipFinish.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnStartShipFinish;
            }
            m_Wrapper.m_PlayerControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleDebug.started += instance.OnToggleDebug;
                @ToggleDebug.performed += instance.OnToggleDebug;
                @ToggleDebug.canceled += instance.OnToggleDebug;
                @EnterCommand.started += instance.OnEnterCommand;
                @EnterCommand.performed += instance.OnEnterCommand;
                @EnterCommand.canceled += instance.OnEnterCommand;
                @StartShip.started += instance.OnStartShip;
                @StartShip.performed += instance.OnStartShip;
                @StartShip.canceled += instance.OnStartShip;
                @StartShipFinish.started += instance.OnStartShipFinish;
                @StartShipFinish.performed += instance.OnStartShipFinish;
                @StartShipFinish.canceled += instance.OnStartShipFinish;
            }
        }
    }
    public PlayerControllerActions @PlayerController => new PlayerControllerActions(this);
    public interface IPlayerControllerActions
    {
        void OnToggleDebug(InputAction.CallbackContext context);
        void OnEnterCommand(InputAction.CallbackContext context);
        void OnStartShip(InputAction.CallbackContext context);
        void OnStartShipFinish(InputAction.CallbackContext context);
    }
}
