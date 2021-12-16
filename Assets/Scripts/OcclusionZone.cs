using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionZone : MonoBehaviour
{
    // enum RenderModeStates { camera, overlay, world };
    // RenderModeStates m_RenderModeStates;
    public Canvas canvasOcclusion;
    public GameObject cameraParent;
    public GameObject canvasParent;
    
    private Vector3 initialCanvasPosition;
    private Quaternion initialCanvasRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialCanvasPosition = canvasOcclusion.transform.position;
        initialCanvasRotation = canvasOcclusion.transform.rotation;
    }


    public void onClickOcclude()
    {
        if(canvasOcclusion.transform.parent == cameraParent.transform)
        {
            canvasOcclusion.transform.SetParent(canvasParent.transform);
        }
        else
        {
            canvasOcclusion.transform.SetParent(cameraParent.transform);
        }
    }

}
