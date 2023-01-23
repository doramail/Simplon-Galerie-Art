using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseZoom : MonoBehaviour
{
    public Vector2 _mouseScrollZoomFromContext;
    public float _mouseZoomScrollY;

    public float _mouseContext;
    public float zoomCameraInput { get; private set; } = 0.0f;
    public int zoom = 20;
    public int normal = 60;
    public float smooth = 5;

    private bool isZoomed = false;
    private bool notZoomed = true;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
        //controls.Player.MouseZoomScrollY.performed += x => _mouseZoomScrollY = x.ReadValue<float>();

    }
    void Update()
    {
        // Vector2 mouseCursorPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // transform.position = mouseCursorPosition;
        _mainCamera = GetComponent<Camera>();
        TestScrollMouse(_mouseZoomScrollY);
        //if(Mouse.current.rightButton.isPressed)
        //{
        //    ZoomCamera();
        //}
    }
    public void TestScrollMouse(float _mouseZoomScrollY)
    {
        
        if (_mouseZoomScrollY > 0)
        {
            Debug.Log("scrolled up");
        }
        if (_mouseZoomScrollY < 0)
        {
            Debug.Log("scrolled down");
        }

    }


    //public void ZoomCamera(Vector2 _mouseScrollZoomFromContext)
    //{
    //    if (_mainCamera.orthographic)
    //    {
    //        GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
    //    }

    //    if (_mainCamera.orthographic)
    //    {
    //        GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
    //    }

        //_mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, zoom, Time.deltaTime * smooth);
        //GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        //if (!isZoomed)
        //{
        //    _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, normal, Time.deltaTime * smooth);
        //    //GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        //}


        //if (isZoomed == true)
        //{
        //    GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        //}
        //if (isZoomed == false)
        //{
        //    GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        //}

    //}
}