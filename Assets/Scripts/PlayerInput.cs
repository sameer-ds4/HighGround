using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Camera mainCam;
    
    public delegate void OnPressed();
    public static event OnPressed DropThunder;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            CheckPlate();
    }

    private void CheckPlate()
	{
		Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 100))
		{
			if(hit.collider.tag == "Enemy")
			{
                DropThunder?.Invoke();
                GameObject toDestroy = hit.collider.gameObject.transform.parent.gameObject;
                Destroy(toDestroy);
			}
		}
	}
}