using UnityEngine;

public class mouseCamera : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float Rotation = 0f;
    public float Sensivity = 100f;
    public Transform Player;
    public float minangle = -90f;
    public float maxangle = 90f;
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Sensivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * Sensivity * Time.deltaTime;

        Rotation -= mouseY;
        Rotation = Mathf.Clamp(Rotation,minangle,maxangle);
        transform.localRotation = Quaternion.Euler(Rotation,0,0);
        Player.Rotate(Vector3.up * mouseX);   
    }
}
