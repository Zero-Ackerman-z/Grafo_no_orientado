using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] NodeControl currentNode;
    private Vector2 refVelocity;
    public float timeToMove;

    public float maxEnergy = 100f;
    [SerializeField] float energy;
    public float energyDecayRate = 10f;

    private NodeControl previousNode;
    private float restTime = 3f;
    private bool isResting = false;

    void Start()
    {
        previousNode = currentNode;
        energy = maxEnergy; // Inicializa la energía al valor máximo
    }

    private void MoveToNextNode()
    {
        if (energy <= 0)
        {
            isResting = true;
            restTime = 3f;
        }

        if (!isResting)
        {
            NodeControl nextNode = currentNode.GetNextNode();
            if (nextNode != null)
            {
                float weight = currentNode.GetWeightedEdge(nextNode);
                energy -= weight; // Resta el peso del arco de la energía
                if (energy < 0)
                {
                    energy = 0;
                }

                currentNode = nextNode;
            }
        }
    }

    void Update()
    {
        if (!isResting)
        {
            transform.position = Vector2.SmoothDamp(transform.position, currentNode.transform.position, ref refVelocity, timeToMove);
        }
        else
        {
            restTime -= Time.deltaTime;
            if (restTime <= 0)
            {
                energy = maxEnergy;
                isResting = false;
                MoveToNextNode();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            MoveToNextNode();
        }
    }
}