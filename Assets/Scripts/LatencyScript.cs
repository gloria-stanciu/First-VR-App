using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatencyScript : MonoBehaviour
{
    [SerializeField] Transform m_targetToFollow;
    [SerializeField] bool m_lag;
    [SerializeField] float m_lagTime;

    Vector3 m_targetPosition;
    Quaternion m_targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            m_lag = !m_lag;
        }
    }

    void LateUpdate ()
    {
        m_targetPosition = new Vector3(m_targetToFollow.position.x, m_targetToFollow.position.y, m_targetToFollow.position.z);
        m_targetRotation = m_targetToFollow.transform.rotation;

        if (m_lag && m_lagTime != 0)
        {
            StartCoroutine(LaggyFollow(m_targetPosition, m_targetRotation));
        }
        else if (!m_lag || m_lagTime == 0)
        {
            transform.position = m_targetPosition;
            transform.rotation = m_targetRotation;
        }
    }
 
    private IEnumerator LaggyFollow(Vector3 _pos, Quaternion _rot)
    {
        yield return new WaitForSeconds(m_lagTime/1000f);
        transform.position = _pos;
        transform.rotation = _rot;
    }
}
