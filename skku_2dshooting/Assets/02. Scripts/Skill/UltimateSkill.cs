using UnityEngine;
using System.Collections;

public class UltimateSkill : MonoBehaviour
{
    [Header("필살기 설정")]
    [SerializeField] private GameObject _ultimatePrefab;
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private float _duration = 3f;
    [SerializeField] private float _yDistanceFromPlayer = 3f;

    private bool _isUsing = false;

    public void UseUltimate()
    {
        if (_isUsing == true) return;

        StartCoroutine(ActivateUltimate());
    }

    private IEnumerator ActivateUltimate()
    {
        _isUsing = true;

        Vector3 position = transform.position + new Vector3(0, _yDistanceFromPlayer, 0);

        GameObject ultimateObject = Instantiate(_ultimatePrefab, position, Quaternion.identity);
        GameObject particleObject = Instantiate(_effectPrefab, position, Quaternion.identity);

        yield return new WaitForSeconds(_duration);

        Destroy(ultimateObject);
        Destroy(particleObject);

        _isUsing = false;
    }
}
