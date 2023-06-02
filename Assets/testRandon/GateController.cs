using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateController : MonoBehaviour
{
    public Text numInputsText;
    public Text numGatesText;
    public Text usedGatesText;
    public Text outputText;
    public Text InputsText;
    public Button generateButton;

    private int numInputs;
    private int numGates;
    private List<int> inputs;
    private List<int> gates;
    private List<string> usedGates;

    private void Start()
    {
        // Initialize variables
        numInputs = 0;
        numGates = 0;
        inputs = new List<int>();
        gates = new List<int>();
        usedGates = new List<string>();

        // Set button click listener
        generateButton.onClick.AddListener(GenerateRandomInputsAndGates);
    }

    private void GenerateRandomInputsAndGates()
    {
        // Generate random number of inputs and gates
        numInputs = Random.Range(1, 8);
        numGates = Random.Range(1, 8);

        // Generate random inputs
        inputs.Clear();
        for (int i = 0; i < numInputs; i++)
        {
            inputs.Add(Random.Range(0, 2));
        }

        // Generate random gates
        gates.Clear();
        for (int i = 0; i < numGates; i++)
        {
            gates.Add(Random.Range(0, 6));
        }

        // Calculate output and used gates
        int output = 0;
        usedGates.Clear();
        StringBuilder inputAndGateBuilder = new StringBuilder();
        for (int i = 0; i < numGates; i++)
        {
            int input1 = inputs[Random.Range(0, numInputs)];
            int input2 = inputs[Random.Range(0, numInputs)];

            string usedGate = "";
            switch (gates[i])
            {
                case 0: output = input1 & input2; usedGate = "AND"; break;
                case 1: output = input1 | input2; usedGate = "OR"; break;
                case 2: output = input1 ^ 1; usedGate = "NOT"; break;
                case 3: output = (input1 & input2) ^ 1; usedGate = "NAND"; break;
                case 4: output = (input1 | input2) ^ 1; usedGate = "NOR"; break;
                case 5: output = (input1 == input2) ? 1 : 0; usedGate = "XNOR"; break;
            }

            usedGates.Add(usedGate);
            inputAndGateBuilder.AppendFormat("Input{0}: {1}, Input{2}: {3} \n",
                                              i * 2 + 1, input1, i * 2 + 2, input2, i + 1);
        }

        // Update UI components
        numInputsText.text = "Number of inputs: " + numInputs;
        numGatesText.text = "Number of gates: " + numGates;
        usedGatesText.text = "Used Gates: " + string.Join(", ", usedGates);
        outputText.text = "Output: " + output;
         
    }
}