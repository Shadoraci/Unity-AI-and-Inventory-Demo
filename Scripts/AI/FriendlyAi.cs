using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public Transform enemy; 

    public LayerMask WhatIsGround, WhatIsPlayer, WhatIsEnemy;

    public GameObject Projectile;

    public float Health;

    public Transform ShotSpawn;

    //Patrolling
    public Vector3 WalkPoint;
    bool WalkPointSet;
    public float WalkPointRange;

    //Attacking
    public float TimeBetweenAttacks;
    public bool AlreadyAttacked;

    //States 
    public float SightRange, AttackRange;
    public bool PlayerInSightRange, PlayerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Main Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        PlayerInSightRange = Physics.CheckSphere(transform.position, SightRange, WhatIsPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsEnemy);

        if (!PlayerInSightRange && !PlayerInAttackRange) Patroling();
        if (PlayerInSightRange && !PlayerInAttackRange) ChasePlayer();
        if (PlayerInSightRange && PlayerInAttackRange) AttackPlayer();
    }
    private void Patroling()
    {
        if (!WalkPointSet) SearchWalkPoint();

        if (WalkPointSet) agent.SetDestination(WalkPoint);

        Vector3 DistanceToWalkPoint = transform.position - WalkPoint;

        //Walkpoint Reached
        if (DistanceToWalkPoint.magnitude < 1f) WalkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float RandomZ = Random.Range(-WalkPointRange, WalkPointRange);
        float RandomX = Random.Range(-WalkPointRange, WalkPointRange);

        WalkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);

        if (Physics.Raycast(WalkPoint, -transform.up, 2f, WhatIsGround)) WalkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(enemy);

        if (!AlreadyAttacked)
        {
            //Attack Code Here
            Rigidbody RB = Instantiate(Projectile, ShotSpawn.position, Quaternion.identity).GetComponent<Rigidbody>();

            RB.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //RB.AddForce(transform.up * 8f, ForceMode.Impulse);

            Destroy(RB.gameObject, 2);

            AlreadyAttacked = true;
            Invoke(nameof(ResetAttack), TimeBetweenAttacks);
        }
    }
    public void ResetAttack()
    {
        AlreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Invoke(nameof(DestroyEnemy), .5f);
        }
    }
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(4); 
        }
    }
}
