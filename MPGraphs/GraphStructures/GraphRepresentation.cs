﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphStructures
{
    public abstract class GraphRepresentation<T> : Matrix<T>, IGraphRepresentation
    {
        public bool IsDirected;
        #region Constructors
        protected GraphRepresentation() : base()
        {
            IsDirected = false;
        }
        protected GraphRepresentation(bool isDirected) : base()
        {
            IsDirected = isDirected;
        }
        protected GraphRepresentation(Matrix<T> matrix) : base(matrix)
        {
            IsDirected = false;
        }
        protected GraphRepresentation(bool isDirected, Matrix<T> matrix) : base(matrix)
        {
            IsDirected = isDirected;
        }
        #endregion Constructors
        #region Properties
        /// <summary>
        /// Returns the number of vertices in calling graph representation.
        /// </summary>
        public abstract int VertexCount
        {
            get;
        }
        /// <summary>
        /// Returns the number of edges in calling graph representation.
        /// </summary>
        public abstract int EdgeCount
        {
            get;
        }
        #endregion Properties
        #region Vertex Manipulation
        /// <summary>
        /// Adds new vertex to graph representation.
        /// </summary>
        public abstract void AddVertex();
        /// <summary>
        /// Removes a specified vertex at index == <paramref name="vertexIndex"/> from graph representation if it exists.
        /// </summary>
        /// <param name="vertexIndex">Index of the vertex to remove from graph representation.</param>
        /// <returns>
        /// If the vertex at index == <paramref name="vertexIndex"/> doesn't exist, return <c>false</c> (otherwise return <c>true</c>).
        /// </returns>
        public abstract bool RemoveVertex(int vertexIndex);
        #endregion Vertex Manipulation
        #region Edge Manipulation
        /// <summary>
        /// Adds an edge to the graph representation, between two vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/> if both those vertices exist.
        /// </summary>
        /// <param name="vertexIndexA">First vertex of the edge.</param>
        /// <param name="vertexIndexB">Second vertex of the edge.</param>
        /// <returns>
        /// If any of two specified vertices doesn't exist, returns <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        public abstract bool AddEdge(int vertexIndexA, int vertexIndexB);
        /// <summary>
        /// Removes an edge from the graph representation, between two vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/> if it exists.
        /// </summary>
        /// <param name="vertexIndexA">First vertex of the edge.</param>
        /// <param name="vertexIndexB">Second vertex of the edge.</param>
        /// <returns>
        /// If the edge between two specified vertices doesn't exist, return <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        public abstract bool RemoveEdge(int vertexIndexA, int vertexIndexB);
        /// <summary>
        /// Checks if the edge between two specified vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/> exists.
        /// </summary>
        /// <param name="vertexIndexA">First vertex of the edge.</param>
        /// <param name="vertexIndexB">Second vertex of the edge to find.</param>
        /// <returns>
        /// If the edge between specified vertices doesn't exist, returns <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        public abstract bool FindEdge(int vertexIndexA, int vertexIndexB);
        #endregion Edge Manipulation
        /// <summary>
        /// Generates a complete graph with <paramref name="vertexCount"/> vertices.
        /// </summary>
        /// <param name="vertexCount">Number of vertices in generated complete graph.</param>
        public static R CompleteGraph<R>(int vertexCount) where R : class, IGraphRepresentation, new()
        {
            R completeGraph = new R();
            for (int i = 0; i < vertexCount; i++)
            {
                completeGraph.AddVertex();
            }
            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    if (i != j)
                    {
                        completeGraph.AddEdge(i, j);
                    }
                }
            }
            return completeGraph;
        }
        /// <summary>
        /// Finds all adjacent edges to the edge with index == <paramref name="vertexIndex"/>.
        /// </summary>
        /// <param name="vertexIndex">Index of the vertex that the adjacent edges are to be found.</param>
        /// <returns>
        /// <c>List&lt;int&gt;</c> containing data needed to identify adjacent edges in given graph representation.
        /// If no adjacent edges are found, returns <c>null</c>.
        /// </returns>
        public List<int> FindAdjacentVertices(int vertexIndex)
        {
            List<int> adjacentEdges = null;
            int columnCount = ColumnCount.Item2;
            bool firstEdge = true;
            for (int i = 0; i < columnCount; i++)
            {
                if (FindEdge(vertexIndex, i) == true)
                {
                    if (firstEdge == true)
                    {
                        adjacentEdges = new List<int>();
                        firstEdge = false;
                    }
                    adjacentEdges.Add(i);
                }
            }
            return adjacentEdges;
        }
    }
}
