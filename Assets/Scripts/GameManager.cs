using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject exit;

    public GameObject product;

    GameObject dropZone;

    [SerializeField]
    PetriNetManager pnManager;

    float time = 0;

    bool transition = false;
    bool completed = false;
    bool wrongElement = false;
    bool returnToStart = false;


    float r = 0;
    float g = 0;
    float b = 0;

    void Start () {
        CreateAProductRequest();
        dropZone = GameObject.Find("DropZone");
	}

    private void Update()
    {
        if (transition)
        {
            time += Time.deltaTime;

            if (completed)
            {
                if (time > 0.5f)
                {
                    pnManager.MoveToTheNextState1();
                    time = 0;
                    transition = false;
                    completed = false;
                }
            }

            if (wrongElement)
            {             
                if (time > 0.5f)
                {
                    pnManager.MoveToTheNextState2();
                    wrongElement = false;
                    returnToStart = true;
                    time = 0;
                }
            }

            if (returnToStart)
            {
                if (time > 0.5f)
                {
                    pnManager.MoveToTheNextState1();
                    returnToStart = false;
                    transition = false;
                    time = 0;
                }
            }

        }
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


        if (r == 0 && g == 0 && b == 0)
        {
            int selectColor = Random.Range(0, 3);

            if (selectColor == 0)
            {
                r = 1;
                g = 1;
                b = 1;
            }
            else if (selectColor == 1)
            {
                r = 1;
                g = 0;
                b = 1;
            }
            else if (selectColor == 2)
            {
                r = 0;
                g = 1;
                b = 1;
            }

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
            pnManager.MoveToTheNextState2();

            float elementRed = element.GetComponent<ElementUnit>().GetRValue();
            float elementGreen = element.GetComponent<ElementUnit>().GetGValue();
            float elementBlue = element.GetComponent<ElementUnit>().GetBValue();

            if (elementRed == r && elementGreen == g && elementBlue == b)
            {
                Debug.Log("Completed");
                transition = true;
                completed = true;
                exit.SetActive(true);
            }
            else
            {
                Debug.Log("Wrong Element");
                transition = true;
                wrongElement = true;
            }

            Destroy(element);
            dropZone.GetComponent<DropZone>().SetSwitchUnitFalse();

        }
    }
}
