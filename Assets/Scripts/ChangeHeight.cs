using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHeight : MonoBehaviour
{
    public GameObject cameraGameObject;
    public Slider heightSlider;
    private Vector3 initialValue;
    private float initialSliderValue;
    // Start is called before the first frame update
    void Start()
    {
        initialValue = cameraGameObject.transform.position;
        initialSliderValue = (float)heightSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderChange(float newValue)
    {
        Vector3 position = cameraGameObject.transform.position;
        position.y = newValue;
        cameraGameObject.transform.position = position;
    }

    public void ResetValue(){

        cameraGameObject.transform.position = initialValue;
        heightSlider.value = initialSliderValue;
    }
}
