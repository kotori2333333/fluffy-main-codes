using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    //values that will be set in the Inspector
    public Transform Target;
    public float RotationSpeed;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;

    public GameObject[] targets;
    private GameObject target;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targets = GameObject.FindGameObjectsWithTag("MonsterT");
        if (targets.Length > 0)
        {
            target = targets[0];
            Target = target.transform;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (targets.Length > 0)
        {

            //find the vector pointing from our position to the target
            _direction = (Target.position - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            _lookRotation = Quaternion.LookRotation(_direction);

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
        }
        }
}