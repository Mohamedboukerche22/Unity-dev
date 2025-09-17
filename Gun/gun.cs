using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Header("Shooting Settings")]
    public float damage = 25f;
    public float range = 100f;
    public Camera fpsCam;

    [Header("Zoom Settings")]
    public float zoomFOV = 30f;
    private float normalFOV;
    public float zoomSpeed = 10f;

    void Start()
    {
        if (fpsCam == null)
            fpsCam = Camera.main;

        normalFOV = fpsCam.fieldOfView;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetMouseButton(1))
        {
            fpsCam.fieldOfView = Mathf.Lerp(fpsCam.fieldOfView, zoomFOV, Time.deltaTime * zoomSpeed);
        }
        else
        {
            fpsCam.fieldOfView = Mathf.Lerp(fpsCam.fieldOfView, normalFOV, Time.deltaTime * zoomSpeed);
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            Health target = hit.transform.GetComponent<Health>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
