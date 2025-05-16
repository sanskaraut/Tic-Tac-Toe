using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastHandler : MonoBehaviour
{
    public LayerMask interactableLayer; // Layer for boxes (for VR and mouse)
    public float rayDistance = 100f;  // Maximum raycast distance (for VR)
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Mouse Input
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
#else
        if (Input.GetButtonDown("Fire1")) // Replace with appropriate VR controller input
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
#endif
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
            {
                Debug.Log("Ray hit: " + hit.collider.gameObject.name); // Debugging
                BoxClick box = hit.collider.GetComponent<BoxClick>();
                if (box != null)
                {
                    box.HandleInteraction();
                }
            }
            else
            {
                Debug.Log("Ray did not hit anything.");
            }
        }
    }
    private void HandleVRRaycast()
    {
        if (Input.GetButtonDown("Fire1")) // Replace with appropriate VR controller input
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
            {
                BoxClick box = hit.collider.GetComponent<BoxClick>();
                if (box != null)
                {
                    box.HandleInteraction();
                }
            }
        }
    }
}
