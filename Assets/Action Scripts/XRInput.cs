using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System;

//TODO: Integration
namespace SilverTrain.ActionEditor
{
    /// <summary>
    /// XRInput serves the purpose of getting
    /// the user's input and translating that
    /// to buttons pressed on the VR controllers.
    /// </summary>
    public class XRInput
    {
//        #region Public Static
//        public Action OnInputDeviceDisconnected;
//        public static bool Haptics = true;
//        #endregion

//        #region Private Variables
//        private static InputDevice m_leftHand;
//        private static InputDevice m_rightHand;

//        List<IPollInput> m_pollInput 
//            = new List<IPollInput>();
//        #endregion

//        #region Main Methods
//        public XRInput()
//        {
//            Setup();
//        }

//        private void Setup()
//        {
//            InputDevices.deviceDisconnected -= HandleInputDisconnected;
//            InputDevices.deviceDisconnected += HandleInputDisconnected;

//            InputDevices.deviceConnected -= HandleInputConnected;
//            InputDevices.deviceConnected += HandleInputConnected;

//            FetchDevices();
//        }

//        public void TearDown()
//        {
//            InputDevices.deviceDisconnected -= HandleInputDisconnected;
//            InputDevices.deviceConnected -= HandleInputConnected;

//            for(int i = 0; i < m_pollInput.Count; i++)
//            {
//                m_pollInput[i] = null;
//            }

//            m_pollInput.Clear();
//        }

//        public void UpdateInput()
//        {
//            for(int i = 0; i < m_pollInput.Count; i++)
//            {
//                if (m_pollInput[i] == null) continue;
//                m_pollInput[i].PollInput(ref m_leftHand, ref m_rightHand);
//            }
//        }

//        public XRButton RegisterListener(InputFeatureUsage<bool> buttonIdentifier, Action OnDown = null, Action OnUp = null, XRHand filter = XRHand.Both)
//        {
//            XRButton button = new XRButton(buttonIdentifier);
//            if(OnDown != null)
//            {
//                button.OnButtonDown -= OnDown;
//                button.OnButtonDown += OnDown;
//            }

//            if(OnUp != null)
//            {
//                button.OnButtonDown -= OnUp;
//                button.OnButtonUp += OnUp;
//            }

//            button.SetFilter(filter);

//            m_pollInput.Add(button);
//            return button;
//        }

//        public void UnregisterListener(XRButton button, Action OnDown, Action OnUp)
//        {
//            if (OnDown != null)
//            {
//                button.OnButtonDown -= OnDown;
//            }

//            if (OnUp != null)
//            {
//                button.OnButtonDown -= OnUp;
//            }

//            m_pollInput.Remove(button);
//        }

//        public XRAxis RegisterListener(InputFeatureUsage<float> axisIdentifier, Action<float> OnValueChanged, XRHand filter = XRHand.Both)
//        {
//            XRAxis axis = new XRAxis(axisIdentifier);
            
//            axis.OnValueChanged -= OnValueChanged;
//            axis.OnValueChanged += OnValueChanged;

//            axis.SetFilter(filter);

//            m_pollInput.Add(axis);
//            return axis;
//        }

//        public void UnregisterListener(XRAxis axis, Action<float> OnValueChanged)
//        {
//            axis.OnValueChanged -= OnValueChanged;
//            m_pollInput.Remove(axis);
//        }

//        public void RegisterListener(InputFeatureUsage<Vector3> vector3Identifier, Action<Vector3> OnValueChanged, XRHand filter)
//        {
//            XRVector3 vec3 = new XRVector3(vector3Identifier);

//            vec3.OnValueChanged -= OnValueChanged;
//            vec3.OnValueChanged += OnValueChanged;

//            vec3.SetFilter(filter);

//            m_pollInput.Add(vec3);
//        }

//        public XRVector2 RegisterListener(InputFeatureUsage<Vector2> vector2Identifier, Action<Vector2> OnValueChanged, XRHand filter)
//        {
//            XRVector2 vec2 = new XRVector2(vector2Identifier);

//            vec2.OnValueChanged -= OnValueChanged;
//            vec2.OnValueChanged += OnValueChanged;

//            vec2.SetFilter(filter);

//            m_pollInput.Add(vec2);
//            return vec2;
//        }

//        public void UnregisterListener(XRVector2 vec2, Action<Vector2> OnValueChanged)
//        {
//            vec2.OnValueChanged -= OnValueChanged;
//            m_pollInput.Remove(vec2);
//        }

//        public static void SetHaptic(XRHand hand, float amplitude, float duration)
//        {
//            if (!Haptics) return;

//            if(hand == XRHand.Left || hand == XRHand.Both)
//            {
//                SendHaptic(ref m_leftHand, amplitude, duration);
//            }

//            if(hand == XRHand.Right || hand == XRHand.Both)
//            {
//                SendHaptic(ref m_rightHand, amplitude, duration);
//            }
//        }

//        public Vector3 CheckInput(InputFeatureUsage<Vector3> vector3Identifier, XRHand filter)
//        {
//            InputDevice device = default(InputDevice);
//            if(filter == XRHand.Left) device = m_leftHand;
//            if(filter == XRHand.Right) device = m_rightHand;
//            return PollVec3(device, vector3Identifier);
//        }

//        public bool CheckInput(InputFeatureUsage<bool> boolIdentifier, XRHand filter)
//        {
//            InputDevice device = default(InputDevice);
//            if(filter == XRHand.Left) device = m_leftHand;
//            if(filter == XRHand.Right) device = m_rightHand;
//            return PollBool(device, boolIdentifier);
//        }
//        #endregion

//        #region Utility Methods
//        private void HandleInputDisconnected(InputDevice device)
//        {
//            FetchDevices();
//            if(m_leftHand == null || m_rightHand == null)
//            {
//                OnInputDeviceDisconnected?.Invoke();
//            }
//        }

//        private void HandleInputConnected(InputDevice device)
//        {
//            FetchDevices();
//        }
        
//        private void FetchDevices()
//        {
//            InputDevice? left = FetchLeftHand();
//            InputDevice? right = FetchRightHand();

//            if(left != null)
//            {
//                m_leftHand = left.Value;
//            }

//            if(right != null)
//            {
//                m_rightHand = right.Value;
//            }
//        }

//        private InputDevice? FetchLeftHand()
//        {
//            return FetchController(InputDeviceCharacteristics.Left);
//        }

//        private InputDevice? FetchRightHand()
//        {
//            return FetchController(InputDeviceCharacteristics.Right);
//        }

//        InputDevice? FetchController(InputDeviceCharacteristics hand)
//        {
//            List<InputDevice> controllers = new List<InputDevice>();

//            InputDeviceCharacteristics desired = InputDeviceCharacteristics.HeldInHand |
//                hand | InputDeviceCharacteristics.Controller;

//            InputDevices.GetDevicesWithCharacteristics(desired, controllers);
//            if (controllers.Count <= 0)
//            {
//#if !UNITY_EDITOR
//                //Debug.LogError($"[SILVER_TRAIN] Could not find controller of type {hand.ToString()}");
//#endif
//                return null;
//            }

//            return controllers[0];
//        }

//        static void SendHaptic(ref InputDevice device, float amplitude, float duration)
//        {
//            uint channel = 0;

//            HapticCapabilities capabilities;
//            if (device.TryGetHapticCapabilities(out capabilities))
//            {
//                if (capabilities.supportsImpulse)
//                {
//                    device.SendHapticImpulse(channel, amplitude, duration);
//                }
//            }
//        }

//        private static Vector3 PollVec3(InputDevice input, InputFeatureUsage<Vector3> vector3Identifier)
//        {
//            if(input == null) return Vector3.zero;
//            Vector3 poll;
//            if(input.TryGetFeatureValue(vector3Identifier, out poll))
//            {
//                return poll;
//            }

//            return Vector3.zero;
//        }

//        private static bool PollBool(InputDevice input, InputFeatureUsage<bool> boolIdentifier)
//        {
//            if(input == null) return false;
//            bool value = false;
//            if(input.TryGetFeatureValue(boolIdentifier, out value))
//            {
//                return value;
//            }

//            return false;
//        }
//#endregion
    }
}
