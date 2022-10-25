using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlacement : MonoBehaviour
{
    GameObject[] myButtons;

    [SerializeField]
    [Range(0,10)]
    float radius;

    int numOfSpawns;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        myButtons = new GameObject[transform.childCount];
        for (int i = 0; i < myButtons.Length; ++i)
        {
            myButtons[i] = transform.GetChild(i).gameObject;
        }
        numOfSpawns = myButtons.Length;

        StartPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartPositions() 
    {
        float nextAngle = 2 * Mathf.PI / numOfSpawns;
        float angle = 0;

        foreach(GameObject _button in myButtons)
        {
            float x = Mathf.Sin(angle) * radius;
            float y = Mathf.Cos(angle) * radius;
               
            _button.transform.position = transform.position + new Vector3(x, y,0);

            angle += nextAngle;

            Vector3 relativeDirection = transform.position - _button.transform.position;
            relativeDirection.Normalize();

            float rotz = Mathf.Atan2(relativeDirection.y, relativeDirection.x) * Mathf.Rad2Deg;
            _button.transform.rotation = Quaternion.Euler(0, 0, (rotz - 90)+180);
            
        }
       

    
    }

    public void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

}
