using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float Mousesenc = 50f;
    public Transform PlayerBoady;
    public float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X")*Mousesenc*Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * Mousesenc * Time.deltaTime;

        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        PlayerBoady.Rotate(Vector3.up*mousex);
        
    }
}
