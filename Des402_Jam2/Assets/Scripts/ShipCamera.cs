using UnityEngine;

public class ShipCamera : MonoBehaviour
{
    [SerializeField] private GameObject shipGameObject;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 camOffset;

    private void Start()
    {
        if (shipGameObject == null) { shipGameObject = GameObject.FindWithTag("Ship"); }
        gameObject.transform.position = shipGameObject.transform.position + 
            (shipGameObject.transform.forward * camOffset.z) + 
            (shipGameObject.transform.up * camOffset.y);
        gameObject.transform.LookAt(shipGameObject.transform.position);
    }

    private void UpdateCamPosition()
    {
        Vector3 newCamPosition = shipGameObject.transform.position +
            (shipGameObject.transform.forward * camOffset.z) +
            (shipGameObject.transform.up * camOffset.y);
        newCamPosition = Vector3.Slerp(gameObject.transform.position, newCamPosition, Time.smoothDeltaTime * speed);
        gameObject.transform.position = newCamPosition;

        Quaternion newCamRotation = Quaternion.LookRotation(shipGameObject.transform.position - gameObject.transform.position);
        newCamRotation = Quaternion.Slerp(gameObject.transform.rotation, newCamRotation, speed * Time.smoothDeltaTime);
        gameObject.transform.rotation = newCamRotation;
    }

    private void FixedUpdate()
    {
        UpdateCamPosition();
    }
}
