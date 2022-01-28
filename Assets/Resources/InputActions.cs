// GENERATED AUTOMATICALLY FROM 'Assets/Resources/InputActions.inputactions'

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
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Tetris"",
            ""id"": ""9638250d-9e9d-417a-b5a5-d39a1a58cc5f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9090dfd3-d21a-437b-aaf3-c3f7d9044831"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate Clockwise"",
                    ""type"": ""Button"",
                    ""id"": ""960cf7df-1b46-4e45-8cd2-9249de0b1623"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hard Drop"",
                    ""type"": ""Button"",
                    ""id"": ""5de7e45c-a2d7-4a3a-be21-b26dd33b1992"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate Counterclockwise"",
                    ""type"": ""Button"",
                    ""id"": ""811bc62b-5e5c-421c-b724-99bd0dde4b4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hold"",
                    ""type"": ""Button"",
                    ""id"": ""1c5e63c4-d0a3-47f1-82a5-dc6e3aaceaea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""c466a5dd-0652-49af-8c35-bc655f0c5cac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Soft Drop"",
                    ""type"": ""Button"",
                    ""id"": ""56351f74-2a01-4882-8fbd-7f38a08cf31c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""fe173930-b087-4d9b-b74d-903ef599d3b0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7bcca220-ccef-47d0-af8b-1b772c9a31ce"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0dc59e74-6625-4592-84f9-473e71846db8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8f25050b-976b-4310-90ef-23b20c87766a"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate Clockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60f896e8-cba1-44b4-91b7-c6f1f3906063"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate Clockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b458213-f52c-4e43-96b3-58b8e2ff8e4a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Hard Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8afb51e8-1968-479a-845c-30be31168e8a"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate Counterclockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8ffcd38-ce41-4c04-81ec-ab842008441f"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate Counterclockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39de2309-168b-4ff2-ae9f-1f97a6ebe71c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15427733-ad7d-4716-aa62-9e7c2ffcc725"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ae15ea7-b759-4d43-96fb-73f9c6437676"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40b63432-8bf5-416c-8bb2-11455dd11c33"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4af4a2ec-de76-46e6-b854-833b3550a63e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Soft Drop"",
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
        // Tetris
        m_Tetris = asset.FindActionMap("Tetris", throwIfNotFound: true);
        m_Tetris_Move = m_Tetris.FindAction("Move", throwIfNotFound: true);
        m_Tetris_RotateClockwise = m_Tetris.FindAction("Rotate Clockwise", throwIfNotFound: true);
        m_Tetris_HardDrop = m_Tetris.FindAction("Hard Drop", throwIfNotFound: true);
        m_Tetris_RotateCounterclockwise = m_Tetris.FindAction("Rotate Counterclockwise", throwIfNotFound: true);
        m_Tetris_Hold = m_Tetris.FindAction("Hold", throwIfNotFound: true);
        m_Tetris_Pause = m_Tetris.FindAction("Pause", throwIfNotFound: true);
        m_Tetris_SoftDrop = m_Tetris.FindAction("Soft Drop", throwIfNotFound: true);
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

    // Tetris
    private readonly InputActionMap m_Tetris;
    private ITetrisActions m_TetrisActionsCallbackInterface;
    private readonly InputAction m_Tetris_Move;
    private readonly InputAction m_Tetris_RotateClockwise;
    private readonly InputAction m_Tetris_HardDrop;
    private readonly InputAction m_Tetris_RotateCounterclockwise;
    private readonly InputAction m_Tetris_Hold;
    private readonly InputAction m_Tetris_Pause;
    private readonly InputAction m_Tetris_SoftDrop;
    public struct TetrisActions
    {
        private @InputActions m_Wrapper;
        public TetrisActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Tetris_Move;
        public InputAction @RotateClockwise => m_Wrapper.m_Tetris_RotateClockwise;
        public InputAction @HardDrop => m_Wrapper.m_Tetris_HardDrop;
        public InputAction @RotateCounterclockwise => m_Wrapper.m_Tetris_RotateCounterclockwise;
        public InputAction @Hold => m_Wrapper.m_Tetris_Hold;
        public InputAction @Pause => m_Wrapper.m_Tetris_Pause;
        public InputAction @SoftDrop => m_Wrapper.m_Tetris_SoftDrop;
        public InputActionMap Get() { return m_Wrapper.m_Tetris; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TetrisActions set) { return set.Get(); }
        public void SetCallbacks(ITetrisActions instance)
        {
            if (m_Wrapper.m_TetrisActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TetrisActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TetrisActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TetrisActionsCallbackInterface.OnMove;
                @RotateClockwise.started -= m_Wrapper.m_TetrisActionsCallbackInterface.OnRotateClockwise;
                @RotateClockwise.performed -= m_Wrapper.m_TetrisActionsCallbackInterface.OnRotateClockwise;
                @RotateClockwise.canceled -= m_Wrapper.m_TetrisActionsCallbackInterface.OnRotateClockwise;
                @HardDrop.started -= m_Wrapper.m_TetrisActionsCallbackInterface.OnHardDrop;
                @HardDrop.performed -= m_Wrapper.m_TetrisActionsCallbackInterface.OnHardDrop;
                @HardDrop.canceled -= m_Wrapper.m_TetrisActionsCallbackInterface.OnHardDrop;
                @RotateCounterclockwise.started -= m_Wrapper.m_TetrisActionsCallbackInterface.OnRotateCounterclockwise;
                @RotateCounterclockwise.performed -= m_Wrapper.m_TetrisActionsCallbackInterface.OnRotateCounterclockwise;
                @RotateCounterclockwise.canceled -= m_Wrapper.m_TetrisActionsCallbackInterface.OnRotateCounterclockwise;
                @Hold.started -= m_Wrapper.m_TetrisActionsCallbackInterface.OnHold;
                @Hold.performed -= m_Wrapper.m_TetrisActionsCallbackInterface.OnHold;
                @Hold.canceled -= m_Wrapper.m_TetrisActionsCallbackInterface.OnHold;
                @Pause.started -= m_Wrapper.m_TetrisActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_TetrisActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_TetrisActionsCallbackInterface.OnPause;
                @SoftDrop.started -= m_Wrapper.m_TetrisActionsCallbackInterface.OnSoftDrop;
                @SoftDrop.performed -= m_Wrapper.m_TetrisActionsCallbackInterface.OnSoftDrop;
                @SoftDrop.canceled -= m_Wrapper.m_TetrisActionsCallbackInterface.OnSoftDrop;
            }
            m_Wrapper.m_TetrisActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @RotateClockwise.started += instance.OnRotateClockwise;
                @RotateClockwise.performed += instance.OnRotateClockwise;
                @RotateClockwise.canceled += instance.OnRotateClockwise;
                @HardDrop.started += instance.OnHardDrop;
                @HardDrop.performed += instance.OnHardDrop;
                @HardDrop.canceled += instance.OnHardDrop;
                @RotateCounterclockwise.started += instance.OnRotateCounterclockwise;
                @RotateCounterclockwise.performed += instance.OnRotateCounterclockwise;
                @RotateCounterclockwise.canceled += instance.OnRotateCounterclockwise;
                @Hold.started += instance.OnHold;
                @Hold.performed += instance.OnHold;
                @Hold.canceled += instance.OnHold;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @SoftDrop.started += instance.OnSoftDrop;
                @SoftDrop.performed += instance.OnSoftDrop;
                @SoftDrop.canceled += instance.OnSoftDrop;
            }
        }
    }
    public TetrisActions @Tetris => new TetrisActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface ITetrisActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotateClockwise(InputAction.CallbackContext context);
        void OnHardDrop(InputAction.CallbackContext context);
        void OnRotateCounterclockwise(InputAction.CallbackContext context);
        void OnHold(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnSoftDrop(InputAction.CallbackContext context);
    }
}
