//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/NewInputSystem/InputSystem.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputSystem : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""Action"",
            ""id"": ""0ebb4dbb-b37d-4e81-aebd-0790f57c5476"",
            ""actions"": [
                {
                    ""name"": ""MoveCubes"",
                    ""type"": ""Button"",
                    ""id"": ""0b080f83-607b-4ead-bbaa-3ea12f68ec1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""529694d5-d616-4b49-8110-c7a4ac0fdfad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d173e755-d304-484b-a6e9-2fb56f2bfb57"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCubes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64fed348-d645-405c-8773-51b5103452cf"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Action
        m_Action = asset.FindActionMap("Action", throwIfNotFound: true);
        m_Action_MoveCubes = m_Action.FindAction("MoveCubes", throwIfNotFound: true);
        m_Action_Quit = m_Action.FindAction("Quit", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Action
    private readonly InputActionMap m_Action;
    private IActionActions m_ActionActionsCallbackInterface;
    private readonly InputAction m_Action_MoveCubes;
    private readonly InputAction m_Action_Quit;
    public struct ActionActions
    {
        private @InputSystem m_Wrapper;
        public ActionActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveCubes => m_Wrapper.m_Action_MoveCubes;
        public InputAction @Quit => m_Wrapper.m_Action_Quit;
        public InputActionMap Get() { return m_Wrapper.m_Action; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionActions set) { return set.Get(); }
        public void SetCallbacks(IActionActions instance)
        {
            if (m_Wrapper.m_ActionActionsCallbackInterface != null)
            {
                @MoveCubes.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnMoveCubes;
                @MoveCubes.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnMoveCubes;
                @MoveCubes.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnMoveCubes;
                @Quit.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_ActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveCubes.started += instance.OnMoveCubes;
                @MoveCubes.performed += instance.OnMoveCubes;
                @MoveCubes.canceled += instance.OnMoveCubes;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public ActionActions @Action => new ActionActions(this);
    public interface IActionActions
    {
        void OnMoveCubes(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}
