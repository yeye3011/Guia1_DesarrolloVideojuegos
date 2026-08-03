using UnityEngine;

public class Transformbehavious : MonoBehaviour
{

    public GameObject deer;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    public float moveSpeed = 2f;

    public float rotationSpeed = 25f;

    public float scaleAmount = 0.1f;

    // Dirección del movimiento
    private Vector3 moveDirection = Vector3.zero;

    // Dirección de la rotación
    private float rotationDirection = 0f;

    // Dirección del escalado
    private float scaleDirection = 0f;

    // Límites del tamaño
    public float minScale = 0.5f;
    public float maxScale = 2f;


    void Start()
    {
        initialPosition = deer.transform.position;
        initialRotation = deer.transform.rotation;
        initialScale = deer.transform.localScale;
    }

    void Update()
    {
        // Movimiento continuo
        deer.transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Rotación continua
        deer.transform.Rotate(0f, rotationDirection * rotationSpeed * Time.deltaTime, 0f, Space.Self);

        // Escalado continuo
        if (scaleDirection != 0)
        {
            Vector3 nuevaEscala = deer.transform.localScale +
                                  Vector3.one * scaleDirection * scaleAmount * Time.deltaTime * 10;

            if (nuevaEscala.x >= minScale &&
                nuevaEscala.x <= maxScale)
            {
                deer.transform.localScale = nuevaEscala;
            }
        }
    }

    // Rotacion

    public void RotateLeft()
    {
        rotationDirection = 1;
    }

    public void RotateRight()
    {
        rotationDirection = -1;
    }

    // Movimiento

    public void TranslateUp()
    {
        moveDirection = Vector3.up;
    }

    public void TranslateDown()
    {
        moveDirection = Vector3.down;
    }

    public void TranslateLeft()
    {
        moveDirection = Vector3.left;
    }

    public void TranslateRight()
    {
        moveDirection = Vector3.right;
    }

    // Escala
    public void ScaleUp()
    {
        scaleDirection = 1;
    }

    public void ScaleDown()
    {
        scaleDirection = -1;
    }

    public void Scale(float magnitud)
    {
        Vector3 changerscale = new Vector3(magnitud, magnitud, magnitud);

        deer.transform.localScale += changerscale;
    }

    public void StopAction()
    {
        moveDirection = Vector3.zero;
        rotationDirection = 0;
        scaleDirection = 0;
    }

    public void Center()
    {
        StopAction();

        deer.transform.position = initialPosition;
        deer.transform.rotation = initialRotation;
        deer.transform.localScale = initialScale;
    }

}



