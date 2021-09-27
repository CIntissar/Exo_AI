using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))] //Besoin d'un NavMeshAgent!!!

public class AIManager : MonoBehaviour // Parent qui aura des descendants
{
    public NavMeshAgent agent;
    public List<TargetPoint> targetPoints = new List<TargetPoint>(); // Lien avec le script du TargetPoint, listant les points sur Scene
    
    //[HideInInspector]
    public int indexNextDestination = 0; // index de la destination des AI qui va changer à chaque fois qu'ils arrivent à un point.
    
    [HideInInspector]
    public Vector3 actualDestination; // point où ils se trouvent

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        NextDestination();
    }


    void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            NextDestination();
        }
    }

    protected virtual void NextDestination()
    {
        actualDestination = targetPoints[indexNextDestination].GivePoint();  // on peut obtenir un point en Vector3 qui sera sa destination actuelle
        agent.SetDestination(actualDestination); // il va dire à l'agent, sa destination à chaque frame.

        indexNextDestination++; 
        
        if(indexNextDestination >= targetPoints.Count )
        {
            indexNextDestination = 0;
        }
    }
}
