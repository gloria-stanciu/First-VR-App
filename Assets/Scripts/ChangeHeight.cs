using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHeight : MonoBehaviour
{
    public GameObject cameraGameObject;
    public Slider heightSlider;
    public Canvas canvas;

    private Vector3 initialCameraValue;
    private Vector3 initialCanvasValue;
    private float initialSliderValue;
    private bool isChanged;

    void Start()
    {
        initialCanvasValue = canvas.transform.position;
        initialSliderValue = (float)heightSlider.value;
    }

    public void SliderChange(float newValue)
    {
        if(!isChanged) {
            initialCameraValue = cameraGameObject.transform.position;
            isChanged = true;
        }

        Vector3 canvasPosition = canvas.transform.position;
        Vector3 cameraPosition = cameraGameObject.transform.position;
        
        canvasPosition.y = newValue + (canvasPosition.y - cameraPosition.y);
        cameraPosition.y = newValue;
        
        canvas.transform.position = canvasPosition;
        cameraGameObject.transform.position = cameraPosition;
    }

    public void ResetValue()
    {
        if(!isChanged) return;

        heightSlider.value = initialSliderValue;
        canvas.transform.position = initialCanvasValue;
        cameraGameObject.transform.position = initialCameraValue;
    }
}
