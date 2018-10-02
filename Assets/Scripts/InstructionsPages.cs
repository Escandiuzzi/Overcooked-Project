using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsPages : MonoBehaviour {

    public GameObject nextPage;
    public GameObject previousPage;

    public GameObject actualPanel;

    public void NextPage()
    {
        actualPanel.SetActive(false);
        nextPage.SetActive(true);
    }

    public void PreviousPage()
    {
        actualPanel.SetActive(false);
        previousPage.SetActive(true);
    }
}
