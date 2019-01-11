using UnityEngine;

public class HexOutline : MonoBehaviour
{

    public GameObject selectedObject;
    public GameObject selector;
    public Light indicator;
    // Use this for initialization
    void Start()
    {
        selector = GameObject.Find("Selector");
        indicator = selector.GetComponentInChildren<Light>();
        indicator.type = LightType.Spot;
        indicator.color = Color.yellow;
        indicator.intensity = 4;
        indicator.spotAngle = 35.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouse_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouse_hit_info;
            if (Physics.Raycast(mouse_ray, out mouse_hit_info))
            {
                GameObject hitObject = mouse_hit_info.transform.parent.gameObject;
                Debug.Log("Mouse is over: " + mouse_hit_info.collider.name);
                selectGameObject(hitObject);
            }
            else
            {
                clearSelection();
            }

            Debug.Log(mouse_ray);
        }
    }
    void selectGameObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            if (obj == selectedObject)
            {
                return;
            }
            clearSelection();
        }
        selectedObject = obj;
        indicator.transform.position = new Vector3(selectedObject.transform.position.x, selectedObject.transform.position.y + 3.7f,selectedObject.transform.position.z); 
    }
    void clearSelection()
    {
        selectedObject = null;
    }
}
