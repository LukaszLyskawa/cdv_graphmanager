﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphStructures
{
    abstract class GraphRepresentation<T> : Matrix<T>
    {
        public bool isDirected;
        #region Constructors
        public GraphRepresentation() : base()
        {
            this.isDirected = false;
        }
        public GraphRepresentation(bool isDirected) : base()
        {
            this.isDirected = isDirected;
        }
        public GraphRepresentation(Matrix<T> matrix) : base(matrix)
        {
            this.isDirected = false;
        }
        public GraphRepresentation(bool isDirected, Matrix<T> matrix) : base(matrix)
        {
            this.isDirected = isDirected;
        }
        #endregion Constructors
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
    }
}