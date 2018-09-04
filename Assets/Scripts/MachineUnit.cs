using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineUnit : MonoBehaviour {

    [SerializeField]
    float r;
    [SerializeField]
    float g;
    [SerializeField]
    float b;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetMachineRed()
    {
        return r;
    }

    public float GetMachineGreen()
    {
        return g;
    }

    public float GetMachineBlue()
    {
        return b;
    }
}
