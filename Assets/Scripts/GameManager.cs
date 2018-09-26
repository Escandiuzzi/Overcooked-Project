using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject product;

	void Start () {
        CreateAProductRequest();
	}
	
    public void CreateAProductRequest()
    {
        float r = 0;
        float g = 0;
        float b = 0;

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

    public void CheckCreation() { }
}
