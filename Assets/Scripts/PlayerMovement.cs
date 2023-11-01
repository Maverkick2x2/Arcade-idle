using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    private AnimatorController _animatorController;
    private PapersCarry _papersCarry;
    private Vector3 _direction;
    private Camera _cam;
    private void Start()
    {
        _cam = Camera.main;
        _animatorController = GetComponent<AnimatorController>();
        _papersCarry = GetComponent<PapersCarry>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, transform.position);
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out float distance))
            {
                _direction = ray.GetPoint(distance);
            }

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_direction.x, 0f, _direction.z),
                _playerSpeed * Time.deltaTime);

            Vector3 offset = _direction - transform.position;
            if (offset.magnitude > 0.16f)
                transform.LookAt(_direction);
        }
        if (Input.GetMouseButton(0) && _papersCarry._papersToMove.Count == 1)
        {
            _animatorController.Run();
        }
        if (Input.GetMouseButtonUp(0) && _papersCarry._papersToMove.Count == 1)
        {
            _animatorController.Idle();
        }
        if (Input.GetMouseButton(0) && _papersCarry._papersToMove.Count > 1)
        {
            _animatorController.RunWithPaper();
        }
        if (Input.GetMouseButtonUp(0) && _papersCarry._papersToMove.Count > 1)
        {
            _animatorController.CarryPaper();
        }
    }
}
