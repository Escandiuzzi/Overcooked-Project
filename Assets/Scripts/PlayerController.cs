using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float playerSpeed;
    [SerializeField]
    GameObject elementPrefab;
    [SerializeField]
    GameObject gameManager;


    GameObject switchObj;
    GameObject switchObj2;
    GameObject heldElement;

	// Use this for initialization
	void Start () {
        switchObj = GameObject.Find("Switch");
        switchObj2 = GameObject.Find("Switch 2");
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        Generate();
        Switch();
        Grab();
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

                    element.GetComponent<ElementUnit>().InitializeElement(r, g, b);

                    element.GetComponent<SpriteRenderer>().color = rgb;

                    element.transform.SetParent(gameObject.transform);

                    heldElement = element;
                }
            }

            else
            {
                heldElement.transform.SetParent(null);
                heldElement.GetComponent<CircleCollider2D>().enabled = true;
                heldElement.GetComponent<ElementUnit>().CheckNearElements();
                heldElement = null;
            }
        }
    }

    void Switch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            float dist = Vector2.Distance(transform.position, switchObj.transform.position);

            if (dist < 2f)
            {
                switchObj.GetComponent<SwitchUnit>().ShuffleColorSet();
            }


            float dist2 = Vector2.Distance(transform.position, switchObj2.transform.position);

            if (dist2 < 2f && switchObj2.GetComponent<SwitchUnit>().GetStatus())
            {
                gameManager.GetComponent<GameManager>().CheckCreation();
            }


        }

    }

    void Grab()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {

            GameObject nearElement = null;
            nearElement = CheckNearElements();

            if (nearElement != null && heldElement == null)
            {
                heldElement = nearElement;           
                heldElement.transform.position = new Vector3(transform.position.x, transform.position.y + 1);
                heldElement.transform.SetParent(gameObject.transform);
            }

        }

    }

    GameObject CheckNearMachine()
    {
        Vector2 size = new Vector2(1, 1);
        RaycastHit2D[] hitColliders = Physics2D.BoxCastAll(transform.position, size, 0, Vector2.up, 1f);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].collider.gameObject.tag == "Machine")
            {

                return hitColliders[i].collider.gameObject;
            }
        }

        return null;
    }

    GameObject CheckNearElements()
    {
        Vector2 size = new Vector2(1, 1);
        RaycastHit2D[] hitColliders = Physics2D.BoxCastAll(transform.position, size, 0, Vector2.up, 1f);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].collider.gameObject.tag == "Element")
            {

                return hitColliders[i].collider.gameObject;
            }

        }

        return null;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        transform.Translate(Vector3.zero, Space.World);
    }
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Color color = Gizmos.color;

    //    color.a = 0.4f;

    //    Gizmos.color = color;

    //    Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1);
    //    Vector3 size = new Vector3(1, 1);
    //    Gizmos.DrawCube(pos, size);
    //}
}
