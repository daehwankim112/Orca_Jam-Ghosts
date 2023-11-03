using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadManager : MonoBehaviour
{
    public Transform Camera;

    public Transform leftHand;
    public Transform rightHand;

    public Material oculusHand;

    [HideInInspector]
    public bool aim = false;


    private void Update()
    {
        this.transform.position = (leftHand.position + rightHand.position) / 2;
        this.transform.rotation = Quaternion.LookRotation(this.transform.position - Camera.position);
        
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Camera.position, this.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "enemy")
            {
                Debug.Log("Enemy Hit");
                if (! aim)
                {
                    oculusHand.SetColor("_ColorTop", new Vector4(255, 255, 0, 255));
                }
                aim = true;
            }
            else
            {
                aim = false;
            }
        }
    }
}
