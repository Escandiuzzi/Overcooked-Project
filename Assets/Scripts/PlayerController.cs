using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float playerSpeed;
    [SerializeField]
    GameObject elementPrefab;

    GameObject heldElement;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        Movement();
        Generate();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.up * playerSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.down * playerSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.W) != true && Input.GetKey(KeyCode.S) != true && Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.D) != true && Input.GetKey(KeyCode.UpArrow) != true && Input.GetKey(KeyCode.DownArrow) != true && Input.GetKey(KeyCode.LeftArrow) != true && Input.GetKey(KeyCode.RightArrow) != true)
        {
        }

    }

    void Generate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(heldElement == null)
            {
                GameObject machine = CheckNearMachine();

                if (machine != null)
                {
                    float r = machine.GetComponent<MachineUnit>().GetMachineRed();
                    float g = machine.GetComponent<MachineUnit>().GetMachineGreen();
                    float b = machine.GetComponent<MachineUnit>().GetMachineBlue();

                    GameObject element = Instantiate(elementPrefab, new Vector3(transform.position.x, transform.position.y + 1), Quaternion.identity);

                    Color rgb = element.GetComponent<SpriteRenderer>().color;

                    rgb.r = r;
                    rgb.g = g;
                    rgb.b = b;

                    element.GetComponent<SpriteRenderer>().color = rgb;

                    element.transform.SetParent(gameObject.transform);

                    heldElement = element;
                }
            }

            else
            {
                heldElement.transform.SetParent(null);
            }
        }
    }

    GameObject CheckNearMachine()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 3f);
        List<GameObject> nearCells = new List<GameObject>();

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "Machine")
            {

                return hitColliders[i].gameObject;
            }
        }

        return null;
    }
}
