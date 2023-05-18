using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.XR.ARFoundation;


public class Test : MonoBehaviour
{
    [SerializeField]
    GameObject prefabToSpawn;

    [SerializeField]
    InputActionMap actionMap;
    // Start is called before the first frame update
    void Start()
    {
        var action = actionMap.FindAction("Action1");
        actionMap.Enable();
        action.performed += Action1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    bool planeActive = true;
    public void Toggle()
    {
        planeActive = !planeActive;
        ARPlaneManager planeManager = FindObjectOfType<ARPlaneManager>();
        planeManager.planePrefab.SetActive(planeActive);
    }

    void Action1(InputAction.CallbackContext context)
    {
        print("Action1");

        GameObject go = Instantiate(prefabToSpawn, Vector3.zero, Quaternion.identity);
        
        XRInteractionManager manager = FindObjectOfType<XRInteractionManager>();
        Arrow arrow = FindObjectOfType<Arrow>();

        arrow.follow = go.transform;

        manager.RegisterInteractable(go.GetComponent<IXRInteractable>());

    }
}
