using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsRotatio : MonoBehaviour
{
    // Start is called before the first frame update
    

    [SerializeField]
    int options;

    float currentAngle, rotationTime, nextAngle;

    bool isRotated;

    enum activeMode
    {
        Craft,
        Discover,
        Buy
    }
    
    void Start()
    {
        rotationTime = 0;
        currentAngle = transform.rotation.z;
        isRotated = false;
        nextAngle = 360 /  options;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nextAngle);
        if (isRotated)
        {
            rotationTime += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, currentAngle), rotationTime * .1f);

        }

        if(rotationTime > 0.99f)
        {
            isRotated = false;
            rotationTime = 0;
        }
        Debug.Log(isRotated);
        //Debug.Log(rotationTime);
        
    }

    public void startSpin(int direction)
    {
        Debug.Log("startRotation");
        Debug.Log(nextAngle * direction);
        currentAngle += nextAngle * direction;

        isRotated = true;
    }
}
