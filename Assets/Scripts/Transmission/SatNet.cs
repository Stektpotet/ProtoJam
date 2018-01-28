﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace SpaceCon
{
    //SatNet - Holder of Satellite nodes, used for managing data revolving around points per transmissions etc.
    //[RequireComponent(typeof(LineRenderer))]
    public class SatNet : MonoBehaviour
    {

        public List<SatNode> nodes = new List<SatNode>();
        public void EnterOrbit(SatNode node)
        {
            nodes.Add(node);
            node.Connect(this);
            StartCoroutine(UpdateConnections());
        }
        
        IEnumerator UpdateConnections()
        {
            foreach (SatNode node in nodes)
            {
                node.Disconnect();
                node.Connect(this);
                yield return new WaitForSeconds(1.0f);
            }
        }
        public void ExitOrbit(SatNode node)
        {
            nodes.Remove(node);
        }
    }
}