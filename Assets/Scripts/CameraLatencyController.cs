using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLatencyController : MonoBehaviour
{
    [SerializeField] Transform targetCamera;
    [SerializeField] bool enableEffect;
    [SerializeField] float lagTimeSeconds;

    private bool waitingForDelay;

    private Vector3 targetCameraPosition;
    private Quaternion targetCameraRotation;

    private Camera delayedCamera;

    void Start() {
        delayedCamera = GetComponent<Camera>();
        Debug.Log(delayedCamera.enabled);
    }

    void LateUpdate ()
    {
        targetCameraPosition = new Vector3(targetCamera.position.x, targetCamera.position.y, targetCamera.position.z);
        targetCameraRotation = targetCamera.transform.rotation;

        if(waitingForDelay && enableEffect) return;

        if (enableEffect && lagTimeSeconds != 0)
        {
            StartCoroutine(LaggyFollow(targetCameraPosition, targetCameraRotation));
            return;
        }

        transform.position = targetCameraPosition;
        transform.rotation = targetCameraRotation;
    }
 
    private IEnumerator LaggyFollow(Vector3 _pos, Quaternion _rot)
    {
        waitingForDelay = true;

        yield return new WaitForSeconds(lagTimeSeconds);
        transform.position = _pos;
        transform.rotation = _rot;

        waitingForDelay = false;
    }

    private void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "LatencyZone")
        {
            Debug.Log("Entered Lag Area");
            delayedCamera.depth = 10;
            enableEffect = true;
        }
    }
    private void OnTriggerExit(Collider collider) {
        Debug.Log("Exited Lag Area");
        delayedCamera.depth = -1;

        enableEffect=false;
        waitingForDelay = false;
    }
}
