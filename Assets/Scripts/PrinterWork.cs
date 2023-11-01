using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PrinterWork : MonoBehaviour
{
    [SerializeField] private Transform[] _papersPlace = new Transform[10];
    [SerializeField] private GameObject _paper;
    public float _paperDeliveryTime, _yAxis;
    public int _countPapers;
    private void Start()
    {
        for (int i = 0; i < _papersPlace.Length; i++)
        {
            _papersPlace[i] = transform.GetChild(0).GetChild(i);
        }

        StartCoroutine(PrintPaper(_paperDeliveryTime));
    }
    /// <summary>
    /// Создание бумаги
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    private IEnumerator PrintPaper(float time)
    {
        int ppIndex = 0;

        while(_countPapers < 250)
        {
            GameObject newPaper = Instantiate(_paper, new Vector3(transform.position.x, -3f, transform.position.z)
                ,Quaternion.Euler(0,90,90), transform.GetChild(1));

            newPaper.transform.DOJump(new Vector3(_papersPlace[ppIndex].position.x, _papersPlace[ppIndex].position.y + _yAxis,
                _papersPlace[ppIndex].position.z), 2f, 1, 0.5f).SetEase(Ease.OutQuad);

            if (ppIndex < 9)
            {
                ppIndex++;
            }
            else
            {
                ppIndex = 0;
                _yAxis += 0.05f;
            }
            _countPapers++;
            Debug.Log(_countPapers);
            yield return new WaitForSecondsRealtime(time);
        }
    }
}
