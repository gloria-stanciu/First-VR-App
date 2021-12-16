using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionZone : MonoBehaviour
{
    // enum RenderModeStates { camera, overlay, world };
    // RenderModeStates m_RenderModeStates;
    public Canvas canvasOcclusion;
    private Vector3 initialCanvasValue;
    // Start is called before the first frame update
    void Start()
    {
        initialCanvasValue = canvasOcclusion.transform.position;
    }


    public void onClickOcclude()
    {
        if(canvasOcclusion.renderMode == RenderMode.WorldSpace)
        {
            canvasOcclusion.renderMode = RenderMode.ScreenSpaceOverlay;
        }
        else if(canvasOcclusion.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            canvasOcclusion.renderMode = RenderMode.WorldSpace;
            canvasOcclusion.transform.position = initialCanvasValue;
        }
    }

}
