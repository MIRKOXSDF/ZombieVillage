using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public GameObject follow;
    public Vector2 minCampos, maxCampos;
   
    // Update is called once per frame
    void Update()
    {
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCampos.x, maxCampos.x),
            Mathf.Clamp(posY, minCampos.y, maxCampos.y),
            transform.position.z);
    }
}
