using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] spinLevels;

    int currentSpin;

    [SerializeField]
    GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {
        currentSpin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpin != 0)
        {
            backButton.SetActive(true);
        }
        else
            backButton.SetActive(false);
    }
    
    public void moveSpin(int direction)
    {
        
        spinLevels[currentSpin].GetComponent<ObjectsRotatio>().startSpin(direction);
        
    }
    public void LevelSelection(int level)
    {
        spinLevels[currentSpin].GetComponent<Animator>().SetTrigger("Ending");
        currentSpin = level;
        spinLevels[currentSpin].SetActive(true);

    }
}
