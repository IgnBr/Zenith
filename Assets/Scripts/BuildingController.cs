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

    private void Update()
    {
        HandleHotkey();

        if (currentPlaceableObject != null)
        {
            MoveCurrentPlaceableObjectToCrosshair();
            ReleaseIfClicked();
        }
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
