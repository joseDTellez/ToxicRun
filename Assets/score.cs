using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    private float points;

    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        points += Time.deltaTime;
        textMesh.text = points.ToString("0");
    }

    public void addPoints(float pointsEntry)
    {
        points += pointsEntry;
    }

}
