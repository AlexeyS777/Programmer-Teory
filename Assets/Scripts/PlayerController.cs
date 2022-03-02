using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float minimumVert = -30f;
    [SerializeField] private float maximumVert = -40f;
    
    private Rigidbody body;
    private CharacterController player;
    private float rotationX = 0;
    private float rotationY = 0;
    private float horInput = 0;
    private float vertInput = 0;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        player = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }   

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        rotationY += Input.GetAxis("Mouse X") * rotationSpeed;
        rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
        // ABSTRACTION player move 
        if (horInput != 0 || vertInput != 0) PlayerMove();
        if (rotationY != 0 || rotationX != 0) PlayerRotation();
    }

    private void PlayerMove()
    {        
        Vector3 move = new Vector3(horInput, 0, vertInput);
        move = Vector3.ClampMagnitude(move,playerSpeed);
        move *= playerSpeed;

        if(Mathf.FloorToInt(body.velocity.magnitude /3.6f) <= 1)
        {
            body.AddRelativeForce(move, ForceMode.Impulse);
        }
    }

    private void PlayerRotation()
    {
        rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);
        transform.localEulerAngles = Vector3.up * rotationY;
        cam.transform.localEulerAngles = Vector3.right * rotationX;
    }


}
