using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PapersCarry : MonoBehaviour
{
    public List<Transform> _papersToMove = new List<Transform>();
    [SerializeField] private Transform _papersPlace;
    [SerializeField] private Transform _table;
    private Transform _workDesk;
    private Transform _secondPaper;
    private float _yAxis, _delay;
    private void Start()
    {
        _papersToMove.Add(_papersPlace);
    }
    private void Update()
    {
        if (_papersToMove.Count > 1)
        {
            for (int i = 1; i < _papersToMove.Count; i++)
            {
                var firstPaper = _papersToMove.ElementAt(i - 1);
                _secondPaper = _papersToMove.ElementAt(i);

                _secondPaper.position = new Vector3(firstPaper.position.x, Mathf.Lerp(_secondPaper.position.y, firstPaper.position.y + 0.05f,
                    Time.deltaTime * 15f), firstPaper.position.z);
            }
        }
        GrabPapers();
    }
    /// <summary>
    /// Количество ресурса, которое может унести игрок
    /// </summary>
    private void GrabPapers()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 1f))
        {
            Debug.DrawRay(transform.position, transform.forward * 1f, Color.green);
            if (hit.collider.CompareTag("Table") && _papersToMove.Count < 11)
            {
                if (hit.collider.transform.childCount > 2)
                {
                    _secondPaper = hit.collider.transform.GetChild(_table.childCount - 1); // в переменную paper будет записан Transform стола
                    _secondPaper.rotation = Quaternion.Euler(_secondPaper.rotation.x, Random.Range(0f, 180f), 90f);
                    _papersToMove.Add(_secondPaper);
                    _secondPaper.parent = null;

                    if (hit.collider.transform.parent.GetComponent<PrinterWork>()._countPapers > 1)
                    {
                        hit.collider.transform.parent.GetComponent<PrinterWork>()._countPapers--;
                    }
                    if (hit.collider.transform.parent.GetComponent<PrinterWork>()._yAxis > 0f)
                    {
                        hit.collider.transform.parent.GetComponent<PrinterWork>()._yAxis = 0f;
                    }
                }
            }
            if (hit.collider.CompareTag("PapersPlace") && _papersToMove.Count > 1)
            {
                _workDesk = hit.collider.transform;

                if (_workDesk.childCount > 0)
                {
                    _yAxis = _workDesk.GetChild(_workDesk.childCount - 1).position.y;
                }
                else
                {
                    _yAxis = _workDesk.position.y;
                }
                DropPapersDown();
                _workDesk.parent.GetChild(_workDesk.parent.childCount - 1).GetComponent<Renderer>().enabled = false;
                hit.collider.GetComponent<WorkDesk>().Work();
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 1f, Color.red);
        }
    }
    /// <summary>
    /// Использование ресурсов для создания валюты
    /// </summary>
    private void DropPapersDown()
    {
        for (var index = _papersToMove.Count - 1; index >= 1; index--)
        {
            _papersToMove[index].DOJump(new Vector3(_workDesk.position.x, _yAxis, _workDesk.position.z), 2f, 1, 0.5f)
                .SetDelay(_delay).SetEase(Ease.Flash);

            _papersToMove.ElementAt(index).parent = _workDesk;
            _papersToMove.RemoveAt(index);

            _yAxis += 0.05f;

            if (_delay < 0.2f)
            {
                _delay += 0.07f;
            }
            else
            {
                _delay = 0f;
            }
        }
    }
}
