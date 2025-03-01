using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    int x;
    int z;

    private void Update()
    {
        MoveForMouse();
    }

    private void MoveForMouse()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        transform.position = new Vector3(localPoint.x * 0.001f, 5, localPoint.y * 0.001f);
    }
}
