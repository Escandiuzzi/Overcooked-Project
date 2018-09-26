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

    public void SetMachineRGB(float red, float green, float blue)
    {
        r = red;
        g = green;
        b = blue;

        ChangeMachineColor();
    }

    public void ChangeMachineColor()
    {

        Transform child = transform.GetChild(0);
        Color color = child.GetComponentInChildren<SpriteRenderer>().color;

        color.r = r;
        color.g = g;
        color.b = b;

        child.GetComponentInChildren<SpriteRenderer>().color = color;
    }

}
