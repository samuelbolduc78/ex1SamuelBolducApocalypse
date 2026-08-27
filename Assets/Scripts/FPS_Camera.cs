using UnityEngine;
using UnityEngine.InputSystem;

public class FPS_Camera : MonoBehaviour
{
    public InputAction sourisX;
    public InputAction sourisY;

    public float sensibiliteSouris = 100f;


    public Transform camera;
    public Transform corps;

    float rotationX = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        sourisX.Enable();
        sourisY.Enable();
    }

    private void OnDisable()
    {
        sourisX.Disable();
        sourisY.Disable();
    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float deplacementSourisX = sourisX.ReadValue<float>() * sensibiliteSouris * Time.deltaTime;
        float deplacementSourisY = sourisY.ReadValue<float>() * sensibiliteSouris * Time.deltaTime;


        rotationX -= deplacementSourisY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);


        camera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        corps.Rotate(deplacementSourisX * Vector3.up);

    }
}
