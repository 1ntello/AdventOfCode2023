using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AOC2023.Challenges
{
    public class NodeInstruction
    {
        public string value { get; set; }
        public string left { get; set; }
        public string right { get; set; }
    }
    public class Challenge8
    {
        public int TraverseTheHauntedWasteLand(List<string> lines)
        {
            string _repeatableInstructions = lines[0];

            lines.RemoveRange(0, 2);
            List <NodeInstruction> nodes = GetNodeInstructions(lines);

            string currentValue = "AAA";
            int instructionCounter = 0;
            int total = 0;
            char currentInstruction = default(char);
            while(currentValue != "ZZZ")
            {
                currentInstruction = _repeatableInstructions[instructionCounter];

                var currentNode = nodes.Where(x => x.value == currentValue).Single();

                if (currentInstruction == 'R')
                    currentValue = currentNode.right;
                else if(currentInstruction == 'L')
                    currentValue = currentNode.left;

                instructionCounter++;
                if (instructionCounter == _repeatableInstructions.Length)
                    instructionCounter = 0;

                total++;
            }
            return total;
        }

        private List<NodeInstruction> GetNodeInstructions(List<string> lines)
        {
            // just parse them all and make the value the key
            // and then we just search by that and make it a traversable list.
            Dictionary<string, string> linesWithKeys = new Dictionary<string, string>();
            foreach(var l in lines)
            {
                var split = l.Split('=');
                linesWithKeys.Add(split[0].Trim(), split[1].Replace("(", "").Replace(")", "").Trim());    
            }

            // we now just make this in rules for left and right 
            List<NodeInstruction> nodes = new List<NodeInstruction>();
            foreach(var lkey in linesWithKeys)
            {
                NodeInstruction node = new NodeInstruction();
                node.value = lkey.Key;
                var left_right_values = lkey.Value.Split(",");
                node.left = left_right_values[0].Trim();
                node.right = left_right_values[1].Trim();
                nodes.Add(node);
            }
            return nodes;
        }
    }
}
