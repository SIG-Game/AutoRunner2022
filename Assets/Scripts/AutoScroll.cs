using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform position;

    private void Start()
    {
        position = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        foreach (Transform child in position)
        {
            child.position += new Vector3(0, speed, 0);
        }
    }
}
