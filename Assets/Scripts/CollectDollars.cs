using TMPro;
using UnityEngine;

public class CollectDollars : MonoBehaviour
{
    public TextMeshProUGUI _moneyCounter;
    private void Start()
    {
        _moneyCounter.text = "$" + PlayerPrefs.GetInt("Dollar");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dollar"))
        {
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("Dollar", PlayerPrefs.GetInt("Dollar") + 5);
            _moneyCounter.text = "$" + PlayerPrefs.GetInt("Dollar");
        }
    }
}
