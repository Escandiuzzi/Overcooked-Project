using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementUnit : MonoBehaviour {

    float r;
    float g;
    float b;


    public void InitializeElement(float red, float green, float blue)
    {
        r = red;
        g = green;
        b = blue;
    }

    public void SetRedColor(float red)
    {
        r += red;
    }

    public void SetGreenColor(float green)
    {
        g += green;
    }

    public void SetBlueColor(float blue)
    {
        b += blue;
    }
    public float GetRValue()
    {
        return r;
    }
    public float GetGValue()
    {
        return g;
    }
    public float GetBValue()
    {
        return b;
    }

    public void UpdateColor()
    {
        Color color = GetComponent<SpriteRenderer>().color;

        color.r = r;
        color.g = g;
        color.b = b;

        GetComponent<SpriteRenderer>().color = color;
    }


    public void CheckNearElements()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 3f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "Element")
            {
                if (hitColliders[i].gameObject != gameObject)
                {
                    GameObject nearElement = hitColliders[i].gameObject;
                    ElementUnit neUnit = nearElement.GetComponent<ElementUnit>();


                    r += neUnit.GetRValue();
                    g += neUnit.GetGValue();
                    b += neUnit.GetBValue();

                    UpdateColor();

                    Destroy(nearElement);

                    break;
                }
            }
        }

    }
}
