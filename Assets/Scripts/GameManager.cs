using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject exit;

    public GameObject product;

    GameObject dropZone;

    float r = 0;
    float g = 0;
    float b = 0;

    void Start () {
        CreateAProductRequest();
        dropZone = GameObject.Find("DropZone");
	}
	
    public void CreateAProductRequest()
    {

        for (int i = 0; i < 3; i++)
        {
            int colorValue = Random.Range(0, 2);

            if (i == 0)
                r = colorValue;
            if (i == 1)
                g = colorValue;
            if (i == 2)
                b = colorValue;
        }

        Color color = product.GetComponent<Image>().color;

        color.r = r;
        color.g = g;
        color.b = b;

        product.GetComponent<Image>().color = color;

        product.SetActive(true);
    }

    public void CheckCreation()
    {
        GameObject element = dropZone.GetComponent<DropZone>().insideElement;

        if (element != null)
        {
            float elementRed = element.GetComponent<ElementUnit>().GetRValue();
            float elementGreen = element.GetComponent<ElementUnit>().GetGValue();
            float elementBlue = element.GetComponent<ElementUnit>().GetBValue();

            if (elementRed == r && elementGreen == g && elementBlue == b)
            {
                Debug.Log("Completed");

                exit.SetActive(true);
            }
            else
            {
                Debug.Log("Wrong Element");
            }

            Destroy(element);
            dropZone.GetComponent<DropZone>().SetSwitchUnitFalse();


        }
    }
}
