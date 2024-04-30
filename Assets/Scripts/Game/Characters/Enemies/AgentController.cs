using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour  {
	public enum AgentState  { Idle = 0, Patrolling, Chasing }
	public AgentState state;
	public Transform[] waypoints;
	public float distanceToStartHeadingToNextWaypoint = 1;
	private int waypointId = 0;
	public Transform target;
	public float distanceToStartChasingTarget = 15.0f;
	public float distanceToStartAttackingTarget = 3.0f;
	public float rotationSpeed = 2.0f;
	public float timePursuingTarget = 10;
	private NavMeshAgent navMeshAgent;
	private Animator animController;
	private int speedHashId;
	private int attackingHashId;

    // EXTRAS
    private int _BisWalkingHash;
    private int _BisAttackingHash;
	[SerializeField] private AudioSource _damageSound;

	void Awake() {
		speedHashId = Animator.StringToHash("walkingSpeed");
		attackingHashId = Animator.StringToHash("Attack");
		navMeshAgent = GetComponent<NavMeshAgent>();
		animController = GetComponent<Animator>();

        _BisWalkingHash = Animator.StringToHash("BisWalking");
        _BisAttackingHash = Animator.StringToHash("BisAttacking");

		if (waypoints.Length == 0)  {
			Debug.LogError("Error: list of waypoints is empty.");
			Destroy(gameObject);
			return;
		}
	}

	void Update() {
		if (state == AgentState.Idle)
			Idle();
		else if (state == AgentState.Patrolling)
			Patrol();
		else
			Chase();
	}

	private float oldRemainingDistance = float.PositiveInfinity;
	private float RemainingDistance() {
		if (navMeshAgent.pathPending) {
			return oldRemainingDistance;
		}
		else if (!navMeshAgent.hasPath) {
			oldRemainingDistance = float.PositiveInfinity;
			return oldRemainingDistance;
		}
		else {
			float distance = 0;
			Vector3[] corners = navMeshAgent.path.corners;
			for (int i = 0; i < corners.Length - 1; i++) {
				distance += Vector3.Distance(corners[i],corners[i + 1]);
			}
			oldRemainingDistance = distance;
			return distance;
		}
	}

	private bool TargetWithinAngle(float angle) {
		Vector3 planarDifference = target.position - transform.position;
		planarDifference.y = 0;
		float actualAngle = Vector3.Angle(planarDifference, transform.forward);
		return actualAngle <= angle;
	}

	private bool IsAwareOfTarget() {
		return RemainingDistance() <= distanceToStartChasingTarget
			   && TargetWithinAngle(90);
	}

	private float timeSinceLastSeenTarget = float.PositiveInfinity;

	void Chase() {
		navMeshAgent.stoppingDistance = 1.5f;
		navMeshAgent.SetDestination(target.position);
		timeSinceLastSeenTarget += Time.deltaTime;

		bool BisWalking = animController.GetBool(_BisWalkingHash);

		if (IsAwareOfTarget()) {
			timeSinceLastSeenTarget = 0;
		}

		if (timeSinceLastSeenTarget > timePursuingTarget) {
			Idle();
		} else if (RemainingDistance() <= navMeshAgent.stoppingDistance) {
			navMeshAgent.isStopped = true;
			animController.SetFloat(speedHashId, 0.0f);
			RotateTowardsTarget();
		} else  {
			navMeshAgent.isStopped = false;
			animController.SetFloat(speedHashId, 1.0f);
			animController.SetBool(_BisWalkingHash, true);

			Attack();
		}
	}

	void RotateTowardsTarget() {
		Vector3 planarDifference = target.position - transform.position;
		planarDifference.y = 0;
		Quaternion targetRotation = Quaternion.LookRotation(planarDifference.normalized);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
	}

	private bool ShouldAttack() {
		return RemainingDistance() < distanceToStartAttackingTarget
			&& timeSinceLastSeenTarget <= timePursuingTarget
			&& TargetWithinAngle(45);
	}

	void Attack() {
		if (ShouldAttack()) {
			animController.SetTrigger(attackingHashId);

			bool BisAttacking = animController.GetBool(_BisAttackingHash);

			animController.SetBool(_BisAttackingHash, true);
		} else {

			animController.SetBool(_BisAttackingHash, false);
		}
	}

	void OnCollisionEnter(Collision collision) {
    	if (collision.gameObject.CompareTag("Player")) {
			PlayerController player = collision.gameObject.GetComponent<PlayerController>();
			_damageSound.PlayOneShot(_damageSound.clip);
			player.SoulSystem.TakeDamage();
			player.TakingDamage();
    	}
	}

	void Idle() {
		navMeshAgent.isStopped = true;
		animController.SetFloat(speedHashId, 0.0f);
	}

	void Patrol() {
		navMeshAgent.isStopped = false;
		navMeshAgent.stoppingDistance = 0;

		animController.SetFloat(speedHashId, 1.0f);

		if (navMeshAgent.remainingDistance < distanceToStartHeadingToNextWaypoint) {
			waypointId = (waypointId + 1) % waypoints.Length;
			navMeshAgent.SetDestination(waypoints[waypointId].position);
		}
	}
}