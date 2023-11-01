using UnityEngine;

public class WorkDesk : MonoBehaviour
{
    public AnimatorController _animatorController;
    private PrintDollars _printDollars;
    private void Start()
    {
        _printDollars = GetComponent<PrintDollars>();
    }
    public void Work()
    {
        _animatorController.SecretaryWork();

        InvokeRepeating("DOSubmitPapers", 2f, 1f);

        StartCoroutine(_printDollars._makeMoneyIE);
    }
    private void DOSubmitPapers()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(transform.childCount - 1).gameObject, 1f);
        }
        else
        {
            _animatorController.SecretaryAsk();

            var desk = transform.parent;

            desk.GetChild(desk.childCount - 1).GetComponent<Renderer>().enabled = true;

            StopCoroutine(_printDollars._makeMoneyIE);

            _printDollars._yAxis = 0;
        }
    }
}
