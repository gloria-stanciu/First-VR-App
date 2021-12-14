using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjects : MonoBehaviour
{
    struct PositionAndRotation
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    Dictionary<Transform, PositionAndRotation> initialPositions = new Dictionary<Transform, PositionAndRotation>();
    public string tag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnObjects()
    {
        foreach(GameObject stack in GameObject.FindGameObjectsWithTag(tag))
        {
            //set all the objects to be stationary
            // var rb = stack.GetComponent<Rigidbody>();
            // rb.velocity = Vector3.zero;
            // rb.angularVelocity = Vector3.zero;

            //store the initial transform of every object
            PositionAndRotation posAndRot;
            posAndRot.position = stack.transform.position;
            posAndRot.rotation = stack.transform.rotation;
            initialPositions[stack.transform] = posAndRot;

            //reset objects
            foreach(var pair in initialPositions)
            {
                Transform t = pair.Key;
                t.position = pair.Value.position;
                t.rotation = pair.Value.rotation;

                // var rb = t.GetComponent<Rigidbody>();
                // rb.velocity = Vector3.zero;
                // rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
