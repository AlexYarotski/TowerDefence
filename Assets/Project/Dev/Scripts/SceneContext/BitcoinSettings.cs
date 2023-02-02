using UnityEngine;

[CreateAssetMenu(fileName = "BitcoinSettings", menuName = "Settings/BitcoinSettings", order = 0)]
public class BitcoinSettings : ScriptableObject
{
    [SerializeField]
    private float _flightSpeed = 0;

    public float FlightSpeed => _flightSpeed;
}
