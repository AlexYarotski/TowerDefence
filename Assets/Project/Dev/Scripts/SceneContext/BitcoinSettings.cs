using UnityEngine;

[CreateAssetMenu(fileName = "BitcoinSettings", menuName = "Settings/BitcoinSettings", order = 0)]
public class BitcoinSettings : ScriptableObject
{
    [SerializeField]
    private float _flightSpeed = 0;
    
    [SerializeField]
    private Animator _animator = null;

    public float FlightSpeed => _flightSpeed;
    public Animator Animator => _animator;
}
