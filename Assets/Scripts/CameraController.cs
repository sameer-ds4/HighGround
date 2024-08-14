using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Camera mainCam;
    private int yAngle;

    void Start()
    {
        mainCam = transform.GetChild(0).GetComponent<Camera>();
    }

    void Update()
    {
        if(!GameManager.gameStart) return;

        if(Input.GetKeyDown(KeyCode.LeftArrow))
            RotateAround(-90);
        if(Input.GetKeyDown(KeyCode.RightArrow))
            RotateAround(90);

        if(Input.GetKeyDown(KeyCode.T))
            Zoom(3);
        if(Input.GetKeyDown(KeyCode.G))
            Zoom(5);
    }

    private void RotateAround(int amount)
    {
        yAngle += amount;
        transform.DORotate(new Vector3(0, yAngle, 0), 0.5f);
    }

    private void Zoom(int amount)
    {
        mainCam.DOOrthoSize(amount, 1).SetEase(Ease.OutSine);
    }
}
