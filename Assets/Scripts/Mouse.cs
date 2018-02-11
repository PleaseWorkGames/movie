using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private List<float> yPositions = new List<float>();
    
    private Vector3 lastMouseCoordinate = Vector3.zero;

    private float startingYPosition;
    
    private string currentDirection;

    private float accuracy = 0;
    
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
//            resetYPositions();
            storeStartingYPosition();
        } else if (mouseDelta.x > 0 && currentDirection != "right") {
            Debug.Log("Going to right");
            currentDirection = "right";
//            resetYPositions();
            storeStartingYPosition();
        } else {
//            Debug.Log(mouseDelta);
            logAccuracy(mouseDelta);
        }
        
        
        // Then we store our mousePosition so that we can check it again next frame.
        lastMouseCoordinate = Input.mousePosition;
        
//        yPositions.Add(lastMouseCoordinate.y);
    }

    private void logAccuracy(Vector3 mouseDelta)
    {
        var mouseDeltaX = Math.Abs(mouseDelta.x);
        var mouseDeltaY = Math.Abs(mouseDelta.y);
        
        if (mouseDeltaY >= 1) {
            return;
        }
        
        accuracy += mouseDeltaX * (1 - mouseDeltaY);
        Debug.Log(accuracy);
    }
    
    private void storeStartingYPosition()
    {
        startingYPosition = Input.mousePosition.y;
    }
    
    private void resetYPositions()
    {
        yPositions.Clear();
    }
}