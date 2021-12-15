using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHeight : MonoBehaviour
{
    public GameObject cameraGameObject;
    public Slider heightSlider;
    private Vector3 initialCameraValue;
    private Vector3 initialCanvasValue;
    private float initialSliderValue;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        initialCameraValue = cameraGameObject.transform.position;
        initialCanvasValue = canvas.transform.position;
        initialSliderValue = (float)heightSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderChange(float newValue)
    {
        Vector3 canvasPosition = canvas.transform.position;
        Vector3 cameraPosition = cameraGameObject.transform.position;
        
        canvasPosition.y = newValue + (canvasPosition.y - cameraPosition.y);
        cameraPosition.y = newValue;
        
        canvas.transform.position = canvasPosition;
        cameraGameObject.transform.position = cameraPosition;
    }

    public void ResetValue()
    {
        heightSlider.value = initialSliderValue;
        canvas.transform.position = new Vector3(initialCanvasValue.x, initialCanvasValue.y + (initialCanvasValue.y - initialCameraValue.y), initialCameraValue.z);
        cameraGameObject.transform.position = initialCameraValue;
    }
}
