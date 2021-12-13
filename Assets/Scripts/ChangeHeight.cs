using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHeight : MonoBehaviour
{
    public GameObject cameraGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
