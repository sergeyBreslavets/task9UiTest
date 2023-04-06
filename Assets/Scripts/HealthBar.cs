using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider _bar;
    [SerializeField] private Cat _cat;
    [SerializeField] private float _stepChange = 1f;
    [SerializeField] private float _sleepSecond = 1f;

    private Coroutine _changeHealt;
    private WaitForSeconds _sleepTime;

    private void Start()
    {
        _sleepTime = new WaitForSeconds(_sleepSecond);
    }

    public void Init()
    {
        _bar.value = _cat.Health;
        _text.text = _cat.Health.ToString();
    }

    public void ChangeView()
    {
        if (_changeHealt != null)
            StopCoroutine(_changeHealt);

        _changeHealt = StartCoroutine(ChangeHealt(_cat.Health));
    }

    private IEnumerator ChangeHealt(float target)
    {
        while (_bar.value != target)
        {
            float result = Mathf.MoveTowards(_bar.value, target, _stepChange);
            _bar.value = result;
            _text.text = result.ToString();
            yield return _sleepTime;
        }
    }
}
