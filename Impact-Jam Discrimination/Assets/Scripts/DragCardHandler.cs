using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCardHandler : MonoBehaviour
{
    public Camera concernedCamera;

    private Vector3 screenPoint;
    private Vector3 currentScreenPoint;
    private Vector3 currentPos;

    private Vector3 positionSave;
    private Quaternion rotationSave;
    private Transform RightText;
    private Transform LeftText;
    private GameObject Parent;

    void Start()
    {
        concernedCamera = Camera.main;
        RightText = transform.parent.Find("RightText");
        LeftText = transform.parent.Find("LeftText");
        SaveData();
    }

    void OnMouseDown()
    {
        screenPoint = concernedCamera.WorldToScreenPoint(gameObject.transform.position);
    }

    void OnMouseDrag()
    {
        currentScreenPoint.Set(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        currentPos = concernedCamera.ScreenToWorldPoint(currentScreenPoint);
        transform.position = currentPos;
        if (positionSave.x - transform.position.x < 0) {
            LeftText.gameObject.SetActive(true);
            RightText.gameObject.SetActive(false);
        }
        else
        {
            LeftText.gameObject.SetActive(false);
            RightText.gameObject.SetActive(true);
        }
    }

    void OnMouseUp()
    {
        if (transform.position.x < 180)
        {
            // send signal
            //Destroy(gameObject);
        } else if (transform.position.x > 180) {
            //send signal
            //Destroy(gameObject);
        }
            ResetPosition();
    }

    void SaveData()
    {
        positionSave.x = transform.position.x;
        positionSave.y = transform.position.y;
        positionSave.z = transform.position.z;
        rotationSave.x = transform.rotation.x;
        rotationSave.y = transform.rotation.y;
        rotationSave.z = transform.rotation.z;
        rotationSave.w = transform.rotation.w;
    }

    public void ResetPosition()
    {
        transform.position = positionSave;
        transform.rotation = rotationSave;
    }

    void Update()
    {
        float z = - ((transform.position.x) / 6);
        Vector3 angle = new Vector3(0, 0, z);

        transform.eulerAngles = angle;
    }
}