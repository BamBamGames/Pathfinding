﻿using UnityEngine;
using System.Collections.Generic;

public class AbstractNode : MonoBehaviour, INode
{
    [SerializeField] private int m_id;
    [SerializeField] private int m_level;
    [SerializeField] private int m_clusterId;
    [SerializeField] private Vector2Int m_pos;

    public int Id { get { return m_id; } }
    public int Level 
    {
        get { return m_level; }
        set { m_level = value; }
    }
    public int ClusterId { get { return m_clusterId; } }
    public Vector2Int Pos { get { return m_pos; } }

    public Dictionary<int, AbstractEdge> Edges { get; } = new Dictionary<int, AbstractEdge>();

    public void Init(int id, int level, int clusterId, Vector2Int concretePos)
    {
        m_id = id;
        m_level = level;
        m_clusterId = clusterId;
        m_pos = concretePos;
    }

    public void AddEdge(AbstractEdge edge)
    {
        AbstractEdge originEdge;
        if (!Edges.TryGetValue(edge.TargetNodeId, out originEdge) || originEdge.Level < edge.Level)
            Edges[edge.TargetNodeId] = edge;
    }

    public void RemoveEdge(int targetNodeId)
    {
        Edges.Remove(targetNodeId);
    }

    public void ClearEdges()
    {
        Edges.Clear();
    }
}