using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PrintDollars : WorkDesk
{
    [SerializeField] private Transform _dollarPlace;
    [SerializeField] private GameObject _dollar;
    public IEnumerator _makeMoneyIE;
    public float _yAxis;
    private void Start()
    {
        _makeMoneyIE = MakeMoney();
    }
    /// <summary>
    /// Создание валюты
    /// </summary>
    /// <returns></returns>
    public IEnumerator MakeMoney()
    {
        var counter = 0;
        var dollarPlaceIndex = 0;

        yield return new WaitForSecondsRealtime(2);

        while (counter < transform.childCount)
        {
            GameObject newDollar = Instantiate(_dollar, new Vector3(_dollarPlace.GetChild(dollarPlaceIndex).position.x,
                _yAxis + 0.1f, _dollarPlace.GetChild(dollarPlaceIndex).position.z), Quaternion.Euler(90f, 90f, 0));

            newDollar.transform.DOScale(new Vector3(0.15f, 0.15f, 0.15f), 0.5f).SetEase(Ease.OutElastic);

            if (dollarPlaceIndex < _dollarPlace.childCount - 1)
            {
                dollarPlaceIndex++;
            }
            else
            {
                dollarPlaceIndex = 0;
                _yAxis += 0.15f;
            }
            yield return new WaitForSecondsRealtime(3f);
        }
    }
}
