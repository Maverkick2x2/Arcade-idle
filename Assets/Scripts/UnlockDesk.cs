using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class UnlockDesk : MonoBehaviour
{
    [SerializeField] private GameObject _unlockProgressObj;
    [SerializeField] private GameObject _newDesk;
    [SerializeField] private TextMeshProUGUI _dollarAmount;
    [SerializeField] private Image _progressBar;
    [SerializeField] private NavMeshSurface _buildNavMesh;
    [SerializeField] private int _deskPrice, _deskRemainPrice;
    [SerializeField] private float _progressValue;
    private CollectDollars _collectDollars;
    private void Start()
    {
        _dollarAmount.text = _deskPrice.ToString("$0");
        _deskRemainPrice = _deskPrice;
        _collectDollars = GetComponent<CollectDollars>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("Dollar") > 0)
        {
            _progressValue = Mathf.Abs(1f - CalculateMoney() / _deskPrice);

            if (PlayerPrefs.GetInt("Dollar") >= _deskPrice)
            {
                PlayerPrefs.SetInt("Dollar", PlayerPrefs.GetInt("Dollar") - _deskRemainPrice);

                _deskRemainPrice = 0;
            }

            else
            {
                _deskRemainPrice -= PlayerPrefs.GetInt("Dollar");
                PlayerPrefs.SetInt("Dollar", 0);
            }

            _progressBar.fillAmount = _progressValue;

            _collectDollars._moneyCounter.text = PlayerPrefs.GetInt("Dollar").ToString("$0");
            _dollarAmount.text = _deskRemainPrice.ToString("$0");

            if (_deskRemainPrice == 0)
            {
                GameObject desk = Instantiate(_newDesk, new Vector3(transform.position.x, 1.035f, transform.position.z),
                    Quaternion.identity);

                desk.transform.DOScale(1.1f, 1f).SetEase(Ease.OutElastic);

                _unlockProgressObj.SetActive(false);

                _buildNavMesh.BuildNavMesh();
            }
        }
    }
    private float CalculateMoney()
    {
        return _deskRemainPrice - PlayerPrefs.GetInt("Dollar");
    }
}
