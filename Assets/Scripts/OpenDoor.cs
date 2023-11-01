using UnityEngine;
using UnityEngine.AI;

public class OpenDoor : MonoBehaviour
{
    private bool _isEnable;
    private float _timer;
    private void Start()
    {
        _isEnable = true;
        _timer = 1f;
    }
    private void Update()
    {
        MoveDoor();
        CheckisEnabled();
    }
    /// <summary>
    /// Перемещение игрока в соседнюю комнату с помощью открытия двери
    /// </summary>
    private void MoveDoor()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var doorOpening, 1f))
        {
            if (doorOpening.collider.CompareTag("Door"))
            {
                _isEnable = false;
            }
        }
    }
    private void CheckisEnabled()
    {
        if (_isEnable == false)
        {
            _timer -= Time.deltaTime;
            transform.GetComponent<Collider>().isTrigger = false;
            transform.GetComponent<NavMeshAgent>().enabled = false;

            if (_timer <= 0)
            {
                _isEnable = true;
                transform.GetComponent<Collider>().isTrigger = true;
                transform.GetComponent<NavMeshAgent>().enabled = true;
                _timer = 1f;
            }
        }
    }
}
