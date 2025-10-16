using UnityEngine;

public class RuntimeFreeCam : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lookSpeed = 2f;
    public float fastMultiplier = 3f;

    private float yaw;
    private float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        yaw += lookSpeed * Input.GetAxis("Mouse X");
        pitch -= lookSpeed * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

       
        float currentSpeed = moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? fastMultiplier : 1f);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(move * currentSpeed * Time.deltaTime, Space.Self);

        if (Input.GetKey(KeyCode.E))
            transform.Translate(Vector3.up * currentSpeed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector3.down * currentSpeed * Time.deltaTime, Space.Self);

      
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }
}
