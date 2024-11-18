using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeveGenerator_1 : MonoBehaviour
{
    [SerializeField] private GameObject[] levelParts;

    [SerializeField] private float minDistance;

    [SerializeField] private Transform finalPoint;

    [SerializeField] private int inicialQuantity;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < inicialQuantity; i++)
        {
            GeneratePartLevel();
        }
    }

    
    private void Update()
    {
        if (Vector2.Distance(player.position, finalPoint.position) < minDistance)
        {
            GeneratePartLevel();
        }
    }

    private void GeneratePartLevel()
    {
        int randonNumber = Random.Range(0, levelParts.Length);
        GameObject level = Instantiate(levelParts[randonNumber], finalPoint.position, Quaternion.identity);
        finalPoint = seekFinalPoint(level, "FinalPoint");    

    }

    private Transform seekFinalPoint(GameObject levelPart, string tag)
    {
        Transform point = null;

        foreach (Transform  location in levelPart.transform)
        {
            if(location.CompareTag(tag))
            {
                point = location;
                break;
            }
        }

        return point;
    }
}
