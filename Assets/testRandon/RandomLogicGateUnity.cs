
using UnityEngine;

public class RandomLogicGateUnity : MonoBehaviour
{
    // 定義邏輯閘的類型
    enum GateType
    {
        AND,
        OR,
        NOT,
        NAND,
        NOR,
        XNOR
    }

    int numInputs, numGates;
    int[] inputs;
    GateType[] gates;

    void Start()
    {
        numInputs = 2;
        numGates = 2;

        inputs = new int[numInputs];
        gates = new GateType[numGates];

        // 產生隨機輸入
        for (int i = 0; i < numInputs; i++)
        {
            inputs[i] = Random.Range(0, 2);
            Debug.Log("Input " + (i + 1) + ": " + inputs[i]);
        }

        // 產生隨機邏輯閘
        for (int i = 0; i < numGates; i++)
        {
            int randomIndex = Random.Range(0, 6);
            gates[i] = (GateType)randomIndex;
            Debug.Log("Gate " + (i + 1) + ": " + gates[i]);
        }

        int output = 0;

        // 計算輸出
        for (int i = 0; i < numGates; i++)
        {
            int input1 = inputs[Random.Range(0, numInputs)];
            int input2 = inputs[Random.Range(0, numInputs)];

            switch (gates[i])
            {
                case GateType.AND:
                    output = input1 & input2;
                    break;
                case GateType.OR:
                    output = input1 | input2;
                    break;
                case GateType.NOT:
                    output = ~input1;
                    break;
                case GateType.NAND:
                    output = ~(input1 & input2);
                    break;
                case GateType.NOR:
                    output = ~(input1 | input2);
                    break;
                case GateType.XNOR:
                    output = (input1 == input2) ? 1 : 0;
                    break;
                default:
                    break;
            }
        }

        Debug.Log("Output: " + output);
    }
}
