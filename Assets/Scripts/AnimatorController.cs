using UnityEngine;
public class AnimatorController : MonoBehaviour
{
    private Animator _anim;
    public Animator Animator;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    /// <summary>
    /// Анимация игрока со стопкой бумаг
    /// </summary>
    public void CarryPaper()
    {
        _anim.SetBool("Carry", true);
        _anim.SetBool("Run", false);
        _anim.SetBool("RunWithPapers", false);
        _anim.SetBool("Idle", false);
    }
    /// <summary>
    /// Анимация игрока в движении со стопкой бумаг
    /// </summary>
    public void RunWithPaper()
    {
        _anim.SetBool("Carry", false);
        _anim.SetBool("RunWithPapers", true);
        _anim.SetBool("Run", false);
        _anim.SetBool("Idle", false);
    }
    /// <summary>
    /// Анимация бега игрока без бумаг
    /// </summary>
    public void Run()
    {
        _anim.SetBool("Run", true);
        _anim.SetBool("Carry", false);
        _anim.SetBool("RunWithPapers", false);
        _anim.SetBool("Idle", false);
    }
    /// <summary>
    /// Анимация игрока в состоянии покоя
    /// </summary>
    public void Idle()
    {
        _anim.SetBool("Run", false);
        _anim.SetBool("Run", false);
        _anim.SetBool("Carry", false);
        _anim.SetBool("Idle", true);
    }
    /// <summary>
    /// Анимация неигрового персонажа в режиме создания валюты
    /// </summary>
    public void SecretaryWork()
    {
        Animator.SetBool("Work", true);
    }
    /// <summary>
    /// Анимация неигрового персонажа в спокойном режиме
    /// </summary>
    public void SecretaryAsk()
    {
        Animator.SetBool("Work", false);
    }
}
