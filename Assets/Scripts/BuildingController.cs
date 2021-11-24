using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField]
    private GameObject placeableObject;

    [SerializeField]
    private KeyCode hotkey = KeyCode.F;

    [SerializeField]
    private GameObject crosshair;

    private GameObject currentPlaceableObject;
    private float mouseWheelRotation;

    private void Update()
    {
        HandleHotkey();

        if (currentPlaceableObject != null)
        {
            MoveCurrentPlaceableObjectToCrosshair();
            RotateFromMouseWheel();
            ReleaseIfClicked();
        }
    }

    private void RotateFromMouseWheel()
    {
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 2f);
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
        }
    }

    private void MoveCurrentPlaceableObjectToCrosshair()
    {
        Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void HandleHotkey()
    {
        if (Input.GetKeyDown(hotkey))
        {
            if (currentPlaceableObject == null)
            {
                currentPlaceableObject = Instantiate(placeableObject);
            }
            else
            {
                Destroy(currentPlaceableObject);
            }

        }
    }
}
