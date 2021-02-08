// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/SpaceGnome_02_InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @SpaceGnome_02_InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @SpaceGnome_02_InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SpaceGnome_02_InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""5be4d330-d648-41de-885a-bbf52c507c05"",
            ""actions"": [
                {
                    ""name"": ""MoveX"",
                    ""type"": ""Value"",
                    ""id"": ""0e4e6c02-0a72-4cb3-a40d-c07bc3d023be"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveNegativeX"",
                    ""type"": ""Value"",
                    ""id"": ""2d4c2d86-ceb0-4272-92d4-15e4a9d2424c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveY"",
                    ""type"": ""Value"",
                    ""id"": ""02fc52f7-06b1-4583-9e00-2da524005eb4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveNegativeY"",
                    ""type"": ""Value"",
                    ""id"": ""f76f0f9b-7f24-455d-a17e-b075f2df09e0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""33305ec5-62ad-4d32-8a95-3170a14f24c4"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5f1a33e1-5e9f-4ea8-a934-3fed17459fcc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveNegativeX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c6d8d2a-61b0-4d6c-b26b-6f08fb16d9da"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveNegativeX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0718670-ee00-469a-b0d0-34fcbd075ca8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""daee87ef-9789-4c83-9827-1572bc52d235"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6f178f76-8c53-421d-88d3-d52a57a79fb6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e956f8da-948a-46b5-883d-5cae83ad0ea5"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""98e08083-b0c3-4ef0-81e6-252a958ac431"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7f1278cc-8005-4408-9c42-c1177a30e3d7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveNegativeY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a560fcfe-6d6f-4f3b-aa8a-37568547bb77"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveNegativeY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4f922f0b-6d76-46b5-b516-07702ea012e4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveNegativeY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4d4d2f93-d0ec-4583-be7d-0b0b29b66d8f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""0816fec7-7378-4904-bd0a-15afef84f681"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""fc148e40-54d1-4ca7-842d-2d7db259e6a6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateCamera"",
                    ""type"": ""Value"",
                    ""id"": ""ae4a9b33-cb48-4eb3-9a0e-433eac188de8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeCamera"",
                    ""type"": ""Button"",
                    ""id"": ""26170f85-aee5-4ca6-990f-625337c9f85b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""70fd22fb-9037-4ceb-b9fa-2b8d2b9f40f4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4c402f4b-3d44-4dc1-b342-3f6da303caa7"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8ad72f50-0c81-43fb-8e89-e95fff4ec170"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7f8a1321-6786-4eba-9f12-d73f89ad47c6"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-360,max=360)"",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""489f1a9a-1b86-4221-87db-3e6b78e2cb3e"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-360,max=360)"",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""94d8ab26-1c2f-4d62-8046-d7c4b62a21bd"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""76dced52-f80b-45c0-9abe-debf06623fc8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dda0d384-ba5d-4e57-ad85-1f76f3cf0dff"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9cfa683c-d281-4e38-8371-9d49a07e63cb"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1151ab0b-17ae-4926-b35a-86270922e25f"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-360,max=360)"",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ea02827c-bff2-4230-8de2-ce0fa234bcf3"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-360,max=360)"",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MoveX = m_Player.FindAction("MoveX", throwIfNotFound: true);
        m_Player_MoveNegativeX = m_Player.FindAction("MoveNegativeX", throwIfNotFound: true);
        m_Player_MoveY = m_Player.FindAction("MoveY", throwIfNotFound: true);
        m_Player_MoveNegativeY = m_Player.FindAction("MoveNegativeY", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Rotate = m_Camera.FindAction("Rotate", throwIfNotFound: true);
        m_Camera_RotateCamera = m_Camera.FindAction("RotateCamera", throwIfNotFound: true);
        m_Camera_ChangeCamera = m_Camera.FindAction("ChangeCamera", throwIfNotFound: true);
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
    private readonly InputAction m_Player_MoveX;
    private readonly InputAction m_Player_MoveNegativeX;
    private readonly InputAction m_Player_MoveY;
    private readonly InputAction m_Player_MoveNegativeY;
    private readonly InputAction m_Player_Jump;
    public struct PlayerActions
    {
        private @SpaceGnome_02_InputActions m_Wrapper;
        public PlayerActions(@SpaceGnome_02_InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveX => m_Wrapper.m_Player_MoveX;
        public InputAction @MoveNegativeX => m_Wrapper.m_Player_MoveNegativeX;
        public InputAction @MoveY => m_Wrapper.m_Player_MoveY;
        public InputAction @MoveNegativeY => m_Wrapper.m_Player_MoveNegativeY;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MoveX.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveX;
                @MoveX.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveX;
                @MoveX.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveX;
                @MoveNegativeX.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveNegativeX;
                @MoveNegativeX.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveNegativeX;
                @MoveNegativeX.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveNegativeX;
                @MoveY.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveY;
                @MoveY.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveY;
                @MoveY.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveY;
                @MoveNegativeY.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveNegativeY;
                @MoveNegativeY.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveNegativeY;
                @MoveNegativeY.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveNegativeY;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveX.started += instance.OnMoveX;
                @MoveX.performed += instance.OnMoveX;
                @MoveX.canceled += instance.OnMoveX;
                @MoveNegativeX.started += instance.OnMoveNegativeX;
                @MoveNegativeX.performed += instance.OnMoveNegativeX;
                @MoveNegativeX.canceled += instance.OnMoveNegativeX;
                @MoveY.started += instance.OnMoveY;
                @MoveY.performed += instance.OnMoveY;
                @MoveY.canceled += instance.OnMoveY;
                @MoveNegativeY.started += instance.OnMoveNegativeY;
                @MoveNegativeY.performed += instance.OnMoveNegativeY;
                @MoveNegativeY.canceled += instance.OnMoveNegativeY;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Rotate;
    private readonly InputAction m_Camera_RotateCamera;
    private readonly InputAction m_Camera_ChangeCamera;
    public struct CameraActions
    {
        private @SpaceGnome_02_InputActions m_Wrapper;
        public CameraActions(@SpaceGnome_02_InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Camera_Rotate;
        public InputAction @RotateCamera => m_Wrapper.m_Camera_RotateCamera;
        public InputAction @ChangeCamera => m_Wrapper.m_Camera_ChangeCamera;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotate;
                @RotateCamera.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateCamera;
                @ChangeCamera.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeCamera;
                @ChangeCamera.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeCamera;
                @ChangeCamera.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnChangeCamera;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @RotateCamera.started += instance.OnRotateCamera;
                @RotateCamera.performed += instance.OnRotateCamera;
                @RotateCamera.canceled += instance.OnRotateCamera;
                @ChangeCamera.started += instance.OnChangeCamera;
                @ChangeCamera.performed += instance.OnChangeCamera;
                @ChangeCamera.canceled += instance.OnChangeCamera;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMoveX(InputAction.CallbackContext context);
        void OnMoveNegativeX(InputAction.CallbackContext context);
        void OnMoveY(InputAction.CallbackContext context);
        void OnMoveNegativeY(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface ICameraActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnRotateCamera(InputAction.CallbackContext context);
        void OnChangeCamera(InputAction.CallbackContext context);
    }
}
