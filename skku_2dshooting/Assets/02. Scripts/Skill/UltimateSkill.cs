using UnityEngine;
using System.Collections;

public class UltimateSkill : MonoBehaviour
{
    [Header("필살기 설정")]
    [SerializeField] private GameObject _ultimateSkillPrefab;
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private float _duration = 3f;
    [SerializeField] private float _yDistanceFromPlayer = 3f;

    private bool _isUsing = false;

    public void UseUltimateSkill()
    {
        if (_isUsing == true) return;

        StartCoroutine(ActivateUltimateSkill());
    }

    private IEnumerator ActivateUltimateSkill()
    {
        _isUsing = true;

        Vector3 position = transform.position + new Vector3(0, _yDistanceFromPlayer, 0);

        if (_ultimateSkillPrefab == null ) yield break;
        if (_effectPrefab == null ) yield break;

        GameObject ultimateSkillObject = Instantiate(_ultimateSkillPrefab, position, Quaternion.identity);
        GameObject particleObject = Instantiate(_effectPrefab, position, Quaternion.identity);

        yield return new WaitForSeconds(_duration);

        Destroy(ultimateSkillObject);
        Destroy(particleObject);

        _isUsing = false;
    }
}
