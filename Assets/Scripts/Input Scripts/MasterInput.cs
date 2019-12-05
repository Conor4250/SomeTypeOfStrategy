// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input Scripts/MasterInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class MasterInput : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public MasterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MasterInput"",
    ""maps"": [
        {
            ""name"": ""In Game"",
            ""id"": ""3f430632-9e34-48bb-af59-4367c7a1d4c4"",
            ""actions"": [
                {
                    ""name"": ""Delete Word"",
                    ""type"": ""Button"",
                    ""id"": ""7d1c0521-9ee8-4a32-b8f2-3e4698a2a8d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Camera Up"",
                    ""type"": ""Button"",
                    ""id"": ""15105bef-7eb4-4921-b455-6ca860d924a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Camera Down"",
                    ""type"": ""Button"",
                    ""id"": ""b98641a9-31ef-49d4-a304-6697ff03c4bd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Camera Left"",
                    ""type"": ""Button"",
                    ""id"": ""6f255213-2ccc-4dfe-89c5-acea371c8ce6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Camera Right"",
                    ""type"": ""Button"",
                    ""id"": ""fd3a1dee-27be-45ae-a1fd-db271938bd01"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Zoom In"",
                    ""type"": ""Value"",
                    ""id"": ""cea9e76d-2110-4617-aceb-827d9ddfe6b9"",
                    ""expectedControlType"": ""Integer"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Zoom Out"",
                    ""type"": ""Value"",
                    ""id"": ""d60b4d60-0f4c-401c-83e2-dba5ee4f09c0"",
                    ""expectedControlType"": ""Integer"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""51a19600-0f76-419f-bf34-aa604263285c"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Delete Word"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0bf0c2b-8c99-4a81-ad75-055eb4e24c20"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b825779-52f9-4952-896e-f7cebfe7cbe0"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23966c8e-5113-4bac-a96e-b0082b4739b7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96f41f3f-1986-4374-8d7a-3bd0dddf6355"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4110d9d1-8d11-4c4b-b0ae-f562163006ee"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Zoom In"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc6f9c9b-4dc4-4765-814b-dee50618b8e0"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Zoom Out"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // In Game
        m_InGame = asset.FindActionMap("In Game", throwIfNotFound: true);
        m_InGame_DeleteWord = m_InGame.FindAction("Delete Word", throwIfNotFound: true);
        m_InGame_CameraUp = m_InGame.FindAction("Camera Up", throwIfNotFound: true);
        m_InGame_CameraDown = m_InGame.FindAction("Camera Down", throwIfNotFound: true);
        m_InGame_CameraLeft = m_InGame.FindAction("Camera Left", throwIfNotFound: true);
        m_InGame_CameraRight = m_InGame.FindAction("Camera Right", throwIfNotFound: true);
        m_InGame_ZoomIn = m_InGame.FindAction("Zoom In", throwIfNotFound: true);
        m_InGame_ZoomOut = m_InGame.FindAction("Zoom Out", throwIfNotFound: true);
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

    // In Game
    private readonly InputActionMap m_InGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_InGame_DeleteWord;
    private readonly InputAction m_InGame_CameraUp;
    private readonly InputAction m_InGame_CameraDown;
    private readonly InputAction m_InGame_CameraLeft;
    private readonly InputAction m_InGame_CameraRight;
    private readonly InputAction m_InGame_ZoomIn;
    private readonly InputAction m_InGame_ZoomOut;
    public struct InGameActions
    {
        private MasterInput m_Wrapper;
        public InGameActions(MasterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @DeleteWord => m_Wrapper.m_InGame_DeleteWord;
        public InputAction @CameraUp => m_Wrapper.m_InGame_CameraUp;
        public InputAction @CameraDown => m_Wrapper.m_InGame_CameraDown;
        public InputAction @CameraLeft => m_Wrapper.m_InGame_CameraLeft;
        public InputAction @CameraRight => m_Wrapper.m_InGame_CameraRight;
        public InputAction @ZoomIn => m_Wrapper.m_InGame_ZoomIn;
        public InputAction @ZoomOut => m_Wrapper.m_InGame_ZoomOut;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                DeleteWord.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnDeleteWord;
                DeleteWord.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnDeleteWord;
                DeleteWord.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnDeleteWord;
                CameraUp.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraUp;
                CameraUp.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraUp;
                CameraUp.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraUp;
                CameraDown.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraDown;
                CameraDown.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraDown;
                CameraDown.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraDown;
                CameraLeft.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraLeft;
                CameraLeft.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraLeft;
                CameraLeft.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraLeft;
                CameraRight.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraRight;
                CameraRight.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraRight;
                CameraRight.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraRight;
                ZoomIn.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnZoomIn;
                ZoomIn.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnZoomIn;
                ZoomIn.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnZoomIn;
                ZoomOut.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnZoomOut;
                ZoomOut.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnZoomOut;
                ZoomOut.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnZoomOut;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                DeleteWord.started += instance.OnDeleteWord;
                DeleteWord.performed += instance.OnDeleteWord;
                DeleteWord.canceled += instance.OnDeleteWord;
                CameraUp.started += instance.OnCameraUp;
                CameraUp.performed += instance.OnCameraUp;
                CameraUp.canceled += instance.OnCameraUp;
                CameraDown.started += instance.OnCameraDown;
                CameraDown.performed += instance.OnCameraDown;
                CameraDown.canceled += instance.OnCameraDown;
                CameraLeft.started += instance.OnCameraLeft;
                CameraLeft.performed += instance.OnCameraLeft;
                CameraLeft.canceled += instance.OnCameraLeft;
                CameraRight.started += instance.OnCameraRight;
                CameraRight.performed += instance.OnCameraRight;
                CameraRight.canceled += instance.OnCameraRight;
                ZoomIn.started += instance.OnZoomIn;
                ZoomIn.performed += instance.OnZoomIn;
                ZoomIn.canceled += instance.OnZoomIn;
                ZoomOut.started += instance.OnZoomOut;
                ZoomOut.performed += instance.OnZoomOut;
                ZoomOut.canceled += instance.OnZoomOut;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IInGameActions
    {
        void OnDeleteWord(InputAction.CallbackContext context);
        void OnCameraUp(InputAction.CallbackContext context);
        void OnCameraDown(InputAction.CallbackContext context);
        void OnCameraLeft(InputAction.CallbackContext context);
        void OnCameraRight(InputAction.CallbackContext context);
        void OnZoomIn(InputAction.CallbackContext context);
        void OnZoomOut(InputAction.CallbackContext context);
    }
}
