using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour {

    [SerializeField]
    GameObject switchUnit;

    public GameObject insideElement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<ElementUnit>())
        {
            switchUnit.GetComponent<SwitchUnit>().SetStatus(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<ElementUnit>())
        {
            insideElement = obj;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<ElementUnit>())
        {
            insideElement = null;
            switchUnit.GetComponent<SwitchUnit>().SetStatus(false);
        }
    }

    public void SetSwitchUnitFalse()
    {
        switchUnit.GetComponent<SwitchUnit>().SetStatus(false);
    }
}
