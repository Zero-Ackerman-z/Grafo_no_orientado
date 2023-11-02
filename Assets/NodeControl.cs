using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public List<NodeControl> listAllAdjacentes;
    public List<float> edgeWeights; // Lista de pesos para los arcos

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public NodeControl GetNextNode()
    {
        int index = Random.Range(0, listAllAdjacentes.Count);
        return listAllAdjacentes[index];
    }

    public float GetWeightedEdge(NodeControl targetNode)
    {
        int index = listAllAdjacentes.IndexOf(targetNode);
        if (index != -1 && index < edgeWeights.Count)
        {
            return edgeWeights[index];
        }
        return 0; // Valor predeterminado si no hay peso definido
    }
}
