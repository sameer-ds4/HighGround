using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Camera mainCam;
    public ParticleSystem lightningStrike;
    
    public delegate void OnPressed();
    public static event OnPressed DropThunder;
    
    void Update()
    {
        if(!GameManager.gameStart) return;

        if(Input.GetMouseButtonDown(0))
            CheckPlate();
    }

    private void CheckPlate()
	{
		Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(ray, 100);

        // Debug.LogError(hits.Length);

		// RaycastHit hit;
		// if(Physics.Raycast(ray, out hit, 100))
        if(hits.Length > 0)
            DropThunder?.Invoke();
        
        foreach(RaycastHit hit in hits)
		{
			if(hit.collider.tag == "Enemy")
			{
                GameObject toDestroy = hit.collider.gameObject;
                ParticleSystem particle = Instantiate(lightningStrike);
                particle.transform.position = toDestroy.transform.position;
                Destroy(toDestroy);
			}
		}
	}
}