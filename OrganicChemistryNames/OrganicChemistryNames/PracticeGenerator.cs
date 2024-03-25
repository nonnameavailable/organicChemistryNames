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

            int maxMainChainLength = 10;
            int startX = 4;
            int startY = 8;

            int mainChainLength = rnd.Next(1, maxMainChainLength);
            chemistryGrid.addElement(startX, startY, Element.C);
            List<Element> longestCC = new List<Element>();
            longestCC.Add(new Element(startX, startY, Element.C));
            for(int i = 0; i < mainChainLength; i++)
            {
                chemistryGrid.addElement(startX + i * 2 + 1, startY, Element.C);
                longestCC.Add(new Element(startX + i * 2 + 1 + 1, startY, Element.C));
            }
            List<int> generationList = new List<int>() { 0, 0, 0, 0, 0, 4, 8, 6, 7, 9 };
            for (int i = 0; i < longestCC.Count; i++)
            {
                int maxSubLength = Math.Abs(longestCC.Count / 2 - i);
                Element cc = longestCC[i];
                int generatedSub = generationList[rnd.Next(0, generationList.Count)];
                int generatedSubCount = rnd.Next(1, maxSubLength + 1);
                if (generatedSub != 0)
                {
                    for (int j = 0; j < generatedSubCount; j++)
                    {
                        chemistryGrid.addElement(cc.X, cc.Y + 1 + j * 2, generatedSub);
                    }
                }

                generatedSub = generationList[rnd.Next(0, generationList.Count)];
                generatedSubCount = rnd.Next(1, maxSubLength + 1);
                if(generatedSub != 0)
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
