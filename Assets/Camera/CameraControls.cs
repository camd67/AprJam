//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Camera/CameraControls.inputactions
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

namespace Camera
{
    public partial class @CameraControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @CameraControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""CameraControls"",
    ""maps"": [
        {
            ""name"": ""CameraMovement"",
            ""id"": ""8c935657-f349-445d-9525-5c6d91fe0305"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""40646d53-7c19-4883-826f-d7081c8f9f9d"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""6b177964-2afc-4a05-9258-144235231b4b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""00c57654-a452-43e7-b5a6-638bd13b41c8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""2b82088f-8f3a-4f58-980c-3c20f63229a6"",
                    ""path"": ""3DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""e5eef913-0506-42a6-8a76-925b4809d945"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""159c9b49-d642-474d-b42f-06ae2c748008"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""dbda1572-7381-45d3-9bd6-0a9cdf7f7893"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""47fe2cde-66c1-483f-8a4e-57b916812463"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Forward"",
                    ""id"": ""bdcca949-8326-42ea-b8b1-c4a42d4637ad"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Backward"",
                    ""id"": ""7c3160bc-6453-418f-a78b-6a3f3718e750"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6e984634-6ceb-4cc8-89c9-d183901530a0"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""50d6a649-30b3-4cc1-8399-61ce480a901b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=5)"",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e5669128-7bfe-4d62-b33d-cc2511e0c132"",
                    ""path"": ""<Keyboard>/pageUp"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a3733e9b-cf4d-4fb0-a296-b7a51fb22adf"",
                    ""path"": ""<Keyboard>/pageDown"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""908b4df0-a744-4176-bb03-d7db3ac4b147"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""da0fab06-f3f2-4f31-b49e-ba127a132ec0"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""affa835f-9e42-470c-9b28-86a8179a3354"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // CameraMovement
            m_CameraMovement = asset.FindActionMap("CameraMovement", throwIfNotFound: true);
            m_CameraMovement_Move = m_CameraMovement.FindAction("Move", throwIfNotFound: true);
            m_CameraMovement_Zoom = m_CameraMovement.FindAction("Zoom", throwIfNotFound: true);
            m_CameraMovement_Rotate = m_CameraMovement.FindAction("Rotate", throwIfNotFound: true);
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

        // CameraMovement
        private readonly InputActionMap m_CameraMovement;
        private ICameraMovementActions m_CameraMovementActionsCallbackInterface;
        private readonly InputAction m_CameraMovement_Move;
        private readonly InputAction m_CameraMovement_Zoom;
        private readonly InputAction m_CameraMovement_Rotate;
        public struct CameraMovementActions
        {
            private @CameraControls m_Wrapper;
            public CameraMovementActions(@CameraControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_CameraMovement_Move;
            public InputAction @Zoom => m_Wrapper.m_CameraMovement_Zoom;
            public InputAction @Rotate => m_Wrapper.m_CameraMovement_Rotate;
            public InputActionMap Get() { return m_Wrapper.m_CameraMovement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraMovementActions set) { return set.Get(); }
            public void SetCallbacks(ICameraMovementActions instance)
            {
                if (m_Wrapper.m_CameraMovementActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnMove;
                    @Zoom.started -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnZoom;
                    @Zoom.performed -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnZoom;
                    @Zoom.canceled -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnZoom;
                    @Rotate.started -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnRotate;
                    @Rotate.performed -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnRotate;
                    @Rotate.canceled -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnRotate;
                }
                m_Wrapper.m_CameraMovementActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Zoom.started += instance.OnZoom;
                    @Zoom.performed += instance.OnZoom;
                    @Zoom.canceled += instance.OnZoom;
                    @Rotate.started += instance.OnRotate;
                    @Rotate.performed += instance.OnRotate;
                    @Rotate.canceled += instance.OnRotate;
                }
            }
        }
        public CameraMovementActions @CameraMovement => new CameraMovementActions(this);
        public interface ICameraMovementActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnZoom(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
        }
    }
}
