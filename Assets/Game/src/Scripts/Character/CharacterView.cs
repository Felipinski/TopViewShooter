using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private Rigidbody rigidBodyRef;
    [SerializeField]
    private float speed = 1;
    public Camera camera;
    void Awake()
    {
        rigidBodyRef = transform.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horizontalMovement = transform.right*Input.GetAxis("Horizontal");
        Vector3 verticalMovement = transform.forward*Input.GetAxis("Vertical");
        Vector3 movement = horizontalMovement + verticalMovement;

        rigidBodyRef.velocity = movement * speed;

        if(Input.GetAxis("Mouse X") != 0)
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit)){
                Vector3 diff = hit.point-rigidBodyRef.position;
                diff.y = 0;
                transform.rotation = Quaternion.LookRotation(diff, Vector3.up);
            }
        }
    }
}
