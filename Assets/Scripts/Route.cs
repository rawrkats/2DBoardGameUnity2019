using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{

    ///<summary> 
    ///The bulk of this script was derived from https://www.youtube.com/watch?v=d1oSQdydJsM
    ///</summary>

    Transform[] waypoints;
    public List<Transform> childNodeList = new List<Transform>();


    // this is for Scene view editing only
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        FillNodes();

        for (int i = 0; i < childNodeList.Count; i++)
        {
            Vector3 currentNode = childNodeList[i].position;
            if (i > 0)
            {
                Vector3 prevNode = childNodeList[(i - 1)].position;
                Gizmos.DrawLine(prevNode, currentNode);
            }
        }
    }

    // populates the childNodeList that is used for player navigation
    void FillNodes()
    {
        childNodeList.Clear();
        waypoints = GetComponentsInChildren<Transform>();

        foreach (Transform child in waypoints)
        {
            if (child != this.transform)
            {
                childNodeList.Add(child);
            }
        }
    }

}
