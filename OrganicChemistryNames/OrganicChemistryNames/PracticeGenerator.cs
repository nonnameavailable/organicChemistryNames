using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganicChemistryNames
{
    class PracticeGenerator
    {
        private ChemistryGrid chemistryGrid;
        public PracticeGenerator(ChemistryGrid chemistryGrid)
        {
            this.chemistryGrid = chemistryGrid;
        }

        public void generatePractice()
        {
            chemistryGrid.clearGrid();
            Random rnd = new Random();

            List<int> limits = chemistryGrid.ParentForm.PracticeLimits;
            List<bool> cbparams = chemistryGrid.ParentForm.PracticeCBParams;

            int minMainChainLength = limits[0];
            int maxMainChainLength = limits[1];
            int minSubLength = limits[2];
            int maxSubLength = limits[3];
            int startX = limits[4];
            int startY = limits[5];
            int subChance = limits[6];
            int bondChance = limits[7];
            bool includeCarbons = cbparams[0];
            bool includeHalogens = cbparams[1];
            bool includeBonds = cbparams[2];

            int mainChainLength = rnd.Next(minMainChainLength, maxMainChainLength);
            chemistryGrid.addElement(startX, startY, Element.C);
            List<Element> longestCC = new List<Element>();
            longestCC.Add(new Element(startX, startY, Element.C));
            for(int i = 0; i < mainChainLength; i++)
            {
                chemistryGrid.addElement(startX + i * 2 + 1, startY, Element.C);
                longestCC.Add(new Element(startX + i * 2 + 1 + 1, startY, Element.C));
            }
            List<int> generationList = new List<int>();
            if (includeCarbons) generationList.Add(4);
            if (includeHalogens) generationList = generationList.Concat(new List<int>() { 8, 6, 7, 9 }).ToList();
            for (int i = 0; i < longestCC.Count; i++)
            {
                int cmaxSubLength = Math.Abs(Math.Abs(longestCC.Count / 2 - i) - longestCC.Count / 2 - 1);
                Element cc = longestCC[i];
                if (rnd.Next(0, 101) < bondChance && i < longestCC.Count - 2)
                {
                    if(rnd.Next(0, 101) < 51)
                    {
                        chemistryGrid.addElement(cc.X + 1, cc.Y, Element.DOUBLE_BOND);
                    } else
                    {
                        chemistryGrid.addElement(cc.X + 1, cc.Y, Element.TRIPLE_BOND);
                    }
                    
                }
                if (rnd.Next(0, 101) < subChance)
                {
                    int generatedSub = generationList[rnd.Next(0, generationList.Count)];
                    int generatedSubCount = rnd.Next(IP.clamp(minSubLength, 0, cmaxSubLength), IP.clamp(cmaxSubLength, 0, maxSubLength));
                    if (generatedSub != 0)
                    {
                        for (int j = 0; j < generatedSubCount; j++)
                        {
                            chemistryGrid.addElement(cc.X, cc.Y + 1 + j * 2, generatedSub);
                        }
                    }
                }
                if(rnd.Next(0, 101) < subChance)
                {
                    int generatedSub = generationList[rnd.Next(0, generationList.Count)];
                    int generatedSubCount = rnd.Next(IP.clamp(minSubLength, 0, cmaxSubLength), IP.clamp(cmaxSubLength, 0, maxSubLength));
                    if (generatedSub != 0)
                    {
                        for (int j = 0; j < generatedSubCount; j++)
                        {
                            chemistryGrid.addElement(cc.X, cc.Y - 1 - j * 2, generatedSub);
                        }
                    }
                }
            }
        }
    }
}
