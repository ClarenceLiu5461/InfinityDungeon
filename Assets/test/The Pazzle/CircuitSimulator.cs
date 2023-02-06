using UnityEngine;
using System.Collections;

public class CircuitSimulator : MonoBehaviour {
    public int numInputs;
    public int numGates;
    private int[] inputs;
    private int[] gates;
    private string[] usedGates;
    void Start () {
        inputs = new int[numInputs];
        gates = new int[numGates];
        usedGates = new string[numGates];

        // Generate random inputs
        for (int i = 0; i < numInputs; i++) {
            inputs[i] = Random.Range(0, 2);
            Debug.Log("Input " + (i + 1) + ": " + inputs[i]);
        }
        // Generate random gates
        for (int i = 0; i < numGates; i++) {
            gates[i] = Random.Range(0, 6);
            Debug.Log("Gate " + (i + 1) + ": " + gates[i]);
        }
        int output = gates[0];
        int usedGateCount = 0;
        for (int i = 1; i < numGates; i++) {
            int input1 = inputs[Random.Range(0, numInputs)];
            int input2 = inputs[Random.Range(0, numInputs)];
            if (gates[i] == 0) {
                output = input1 & input2;
                usedGates[usedGateCount++] = "AND";
            } else if (gates[i] == 1) {
                output = input1 | input2;
                usedGates[usedGateCount++] = "OR";
            } else if (gates[i] == 2) {
                output = ~input1;
                usedGates[usedGateCount++] = "NOT";
            } else if (gates[i] == 3) {
                output = ~(input1 & input2);
                usedGates[usedGateCount++] = "NAND";
            } else if (gates[i] == 4) {
                output = ~(input1 | input2);
                usedGates[usedGateCount++] = "NOR";
            } else if (gates[i] == 5) {
                output = (input1 == input2) ? 1 : 0;
                usedGates[usedGateCount++] = "XNOR";
            }
        }

        Debug.Log("Output: " + output);
        Debug.Log("Used Gates: ");
        for (int i = 0; i < usedGateCount; i++) {
            Debug.Log(usedGates[i] + " ");
        }
    }
}