using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public enum HandType
{
  Left,
  Right
}

public enum HandState {
    Idle,
    GrabDistance,
    GrabDirect
  }

public class XRHandController : MonoBehaviour
{
  public HandType handType;
  public float thumbMoveSpeed = 0.1f;

  public HandState handState { get; set; } = HandState.Idle;
  private HandState oldHandState;

  private Animator animator;
  private InputDevice inputDevice;

  private float indexValue;
  private float thumbValue;
  private float threeFingersValue;

  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();
    inputDevice = GetInputDevice();
  }

  // Update is called once per frame
  void Update()
  {
    if(handState == HandState.Idle) {
      if(oldHandState == HandState.GrabDistance){
        animator.SetFloat("AirGrab", 0);
      }
      animator.Play("Blend Tree");
      AnimateHand();
    }
    if(handState == HandState.GrabDistance) {
      AnimateGrabDistance();
    }

    oldHandState = handState;
  }

  InputDevice GetInputDevice()
  {
    InputDeviceCharacteristics controllerCharacteristic = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller;

    if (handType == HandType.Left)
    {
      controllerCharacteristic = controllerCharacteristic | InputDeviceCharacteristics.Left;
    }
    else
    {
      controllerCharacteristic = controllerCharacteristic | InputDeviceCharacteristics.Right;
    }

    List<InputDevice> inputDevices = new List<InputDevice>();
    InputDevices.GetDevicesWithCharacteristics(controllerCharacteristic, inputDevices);

    return inputDevices[0];
  }

  void AnimateHand()
  {
    inputDevice.TryGetFeatureValue(CommonUsages.trigger, out indexValue);
    inputDevice.TryGetFeatureValue(CommonUsages.grip, out threeFingersValue);

    inputDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouched);
    inputDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouched);

    if (primaryTouched || secondaryTouched)
    {
      thumbValue += thumbMoveSpeed;
    }
    else
    {
      thumbValue -= thumbMoveSpeed;
    }

    thumbValue = Mathf.Clamp(thumbValue, 0, 1);

    animator.SetFloat("Index", indexValue);
    animator.SetFloat("ThreeFingers", threeFingersValue);
    animator.SetFloat("Thumb", thumbValue);
  }

  void AnimateGrabDistance()
  {
    // animator.Play("AirGrab");
    animator.Play("AirGrab");
    animator.SetFloat("AirGrab", 1);
  }

  public void setHandState(int handState)
  {
    this.handState = (HandState)handState;
  }
}