using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private List<float> yPositions = new List<float>();
    
    private Vector3 lastMouseCoordinate = Vector3.zero;

    private string currentDirection;
    
    // Use this for initialization
    void Start()
    {
        
    }

    void Update()
    {
//        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // First we find out how much it has moved, by comparing it with the stored coordinate.
        Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;
        
        // Then we check if it has moved to the left.
        if (mouseDelta.x < 0 && currentDirection != "left") { // Assuming a negative value is to the left.
            Debug.Log("Going to left");
            currentDirection = "left";
            resetYPositions();
        } else if (mouseDelta.x > 0 && currentDirection != "right") {
            Debug.Log("Going to right");
            currentDirection = "right";
            resetYPositions();
        } else {
            Debug.Log(mouseDelta);
        }
        
        
        
        // Then we store our mousePosition so that we can check it again next frame.
        lastMouseCoordinate = Input.mousePosition;
        
        yPositions.Add(lastMouseCoordinate.y);
    }

    private void resetYPositions()
    {
        yPositions.Clear();
    }
}