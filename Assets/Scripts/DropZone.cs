using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour {

    [SerializeField]
    GameObject switchUnit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<ElementUnit>())
        {
            switchUnit.GetComponent<SwitchUnit>().SetStatus(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<ElementUnit>())
        {
            switchUnit.GetComponent<SwitchUnit>().SetStatus(false);
        }
    }
}
