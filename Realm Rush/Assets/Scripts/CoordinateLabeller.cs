using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoordinateLabeller : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;

    private TextMeshPro label;
    private Vector2Int coordinates = new();
    private bool isCoordinatesOn;

    Waypoint waypoint;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        ColorCoordinate();
        ToggleLabels();
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
    private void ColorCoordinate()
    {
        label.color = waypoint.IsPlaceable ? defaultColor : blockedColor;
    }

    private void DisplayCoordinates()

    {
        if (isCoordinatesOn)
        {
            coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
            coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
            label.text = coordinates.x + "," + coordinates.y;
        }
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
