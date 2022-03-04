using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white, blockedColor = Color.grey;
    Vector2Int coordinates = new Vector2Int();

    Waypoint waypoint;
    TextMeshPro label;
    void Awake()
    {
        waypoint = GetComponentInParent<Waypoint>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        SetLabelColor();

        ToggleLabels();
    }

    void SetLabelColor()
    {
        if (waypoint.IsPlacable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }

    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = $"{coordinates.x},{coordinates.y}";
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
