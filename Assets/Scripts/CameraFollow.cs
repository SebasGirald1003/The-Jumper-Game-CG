using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      
    private Vector3 offset;       

    public float smoothSpeed = 5f;

    private void Start()
    {
        // Calculamos el offset inicial según donde está la cámara y el jugador
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // Nueva posición = X del jugador + offset fijo
        Vector3 desiredPosition = new Vector3(target.position.x, 2, -5) + offset;

        // Movimiento suave
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}
