// GENERATED AUTOMATICALLY FROM 'Assets/Input/TheInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TheInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TheInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TheInput"",
    ""maps"": [
        {
            ""name"": ""navigation"",
            ""id"": ""e549d4c7-cb19-41c5-9505-d1f2a68e509c"",
            ""actions"": [
                {
                    ""name"": ""motion"",
                    ""type"": ""PassThrough"",
                    ""id"": ""42ef572a-dd94-478d-8bfc-4c01dffc1d62"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""63d86786-1ed2-4731-850b-5870641bedd5"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46d5f137-9fb7-4957-8a63-1ebb440a2783"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""actions"",
            ""id"": ""9dcb1de0-1102-4ee6-b4b0-8fefc356e329"",
            ""actions"": [
                {
                    ""name"": ""selectBed"",
                    ""type"": ""Button"",
                    ""id"": ""c9fb1c39-7fc9-4fcf-9ef9-bd9a28c5efad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1f1046b5-2610-4db2-a224-2dfb43f0f313"",
                    ""path"": ""<HID::4-Axis,12-Button with POV>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""selectBed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // navigation
        m_navigation = asset.FindActionMap("navigation", throwIfNotFound: true);
        m_navigation_motion = m_navigation.FindAction("motion", throwIfNotFound: true);
        // actions
        m_actions = asset.FindActionMap("actions", throwIfNotFound: true);
        m_actions_selectBed = m_actions.FindAction("selectBed", throwIfNotFound: true);
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

    // navigation
    private readonly InputActionMap m_navigation;
    private INavigationActions m_NavigationActionsCallbackInterface;
    private readonly InputAction m_navigation_motion;
    public struct NavigationActions
    {
        private @TheInput m_Wrapper;
        public NavigationActions(@TheInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @motion => m_Wrapper.m_navigation_motion;
        public InputActionMap Get() { return m_Wrapper.m_navigation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NavigationActions set) { return set.Get(); }
        public void SetCallbacks(INavigationActions instance)
        {
            if (m_Wrapper.m_NavigationActionsCallbackInterface != null)
            {
                @motion.started -= m_Wrapper.m_NavigationActionsCallbackInterface.OnMotion;
                @motion.performed -= m_Wrapper.m_NavigationActionsCallbackInterface.OnMotion;
                @motion.canceled -= m_Wrapper.m_NavigationActionsCallbackInterface.OnMotion;
            }
            m_Wrapper.m_NavigationActionsCallbackInterface = instance;
            if (instance != null)
            {
                @motion.started += instance.OnMotion;
                @motion.performed += instance.OnMotion;
                @motion.canceled += instance.OnMotion;
            }
        }
    }
    public NavigationActions @navigation => new NavigationActions(this);

    // actions
    private readonly InputActionMap m_actions;
    private IActionsActions m_ActionsActionsCallbackInterface;
    private readonly InputAction m_actions_selectBed;
    public struct ActionsActions
    {
        private @TheInput m_Wrapper;
        public ActionsActions(@TheInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @selectBed => m_Wrapper.m_actions_selectBed;
        public InputActionMap Get() { return m_Wrapper.m_actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
        public void SetCallbacks(IActionsActions instance)
        {
            if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
            {
                @selectBed.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSelectBed;
                @selectBed.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSelectBed;
                @selectBed.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSelectBed;
            }
            m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @selectBed.started += instance.OnSelectBed;
                @selectBed.performed += instance.OnSelectBed;
                @selectBed.canceled += instance.OnSelectBed;
            }
        }
    }
    public ActionsActions @actions => new ActionsActions(this);
    public interface INavigationActions
    {
        void OnMotion(InputAction.CallbackContext context);
    }
    public interface IActionsActions
    {
        void OnSelectBed(InputAction.CallbackContext context);
    }
}
