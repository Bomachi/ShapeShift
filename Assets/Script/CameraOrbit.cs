using UnityEngine;

public class CameraOrbit : MonoBehaviour{
    public Transform target;
    public float distance = 10.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = 5.0f;
    public float distanceMax = 20.0f;
    public float zoomSpeed = 5.0f;

    private float x = 0.0f;
    private float y = 0.0f;

    void Start(){
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        transform.position = target.position - transform.forward * distance;
    }

    void LateUpdate(){
        if (target){
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            distance = Mathf.Clamp(distance - scroll * zoomSpeed, distanceMin, distanceMax);

            if (Input.GetMouseButton(0)){
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
            }

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}