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
            this.chemistryGrid = new ChemistryGrid(chemistryGrid.Width, chemistryGrid.Height, chemistryGrid.SqSize, chemistryGrid.ParentForm);
            //this.chemistryGrid = chemistryGrid;
        }

        internal ChemistryGrid ChemistryGrid { get => chemistryGrid; set => chemistryGrid = value; }

        public void generatePractice()
        {
            chemistryGrid.clearGrid();
            Random rnd = new Random();
            Form1 f = chemistryGrid.ParentForm;

            int minMainChainLength = f.PracticeMinLCC;
            int maxMainChainLength = f.PracticeMaxLCC;
            int minSubLength = f.PracticeMinSubLength;
            int maxSubLength = f.PracticeMaxSubLength + 1;
            int startX = f.PracticeStartX;
            int startY = f.PracticeStartY;
            int subChance = f.PracticeSubChance;
            int bondChance = f.PracticeBondChance;
            int carbonCount = f.PracticeCarbonCount;

            bool includeCarbons = f.PracticeIncludeCarbons;
            bool includeHalogens = f.PracticeIncludeHalogens;
            bool includeOxygen = f.PracticeIncludeOxygen;
            bool guaranteeCAcid = f.PracticeGuaranteeCAcid;

            int mainChainLength = rnd.Next(minMainChainLength, maxMainChainLength);
            chemistryGrid.addElement(startX, startY, Element.C, Element.SINGLE_BOND);
            List<Element> longestCC = new List<Element>();
            longestCC.Add(new Element(startX, startY, Element.C));

            for (int i = 0; i < mainChainLength; i++)
            {
                int bond = Element.SINGLE_BOND;
                if(rnd.Next(0, 101) < bondChance)
                {
                    if(rnd.Next(0, 101) < 50)
                    {
                        bond = Element.DOUBLE_BOND;
                    } else
                    {
                        bond = Element.TRIPLE_BOND;
                    }
                }
                chemistryGrid.addElement(startX + i * 2 + 1, startY, Element.C, bond);
                longestCC.Add(new Element(startX + i * 2 + 1 + 1, startY, Element.C));
            }

            List<int> generationList = new List<int>();
            if (includeHalogens) generationList = generationList.Concat(new List<int>() { 7, 5, 6, 8 }).ToList();
            if (includeCarbons)
            {
                for(int i = 0; i < carbonCount; i++)
                {
                    generationList.Add(Element.C);
                }
            }
            if (includeOxygen) generationList.Add(Element.O);
            if (generationList.Count == 0) return;
            if (guaranteeCAcid)
            {
                chemistryGrid.addElement(longestCC[0].X, longestCC[0].Y + 1, Element.O, Element.SINGLE_BOND);
                chemistryGrid.addElement(longestCC[0].X, longestCC[0].Y - 1, Element.O, Element.DOUBLE_BOND);
            }
            for (int i = 0; i < longestCC.Count; i++)
            {
                int cmaxSubLength = Math.Abs(Math.Abs(longestCC.Count / 2 - i) - longestCC.Count / 2 - 1);
                Element cc = longestCC[i];
                if (rnd.Next(0, 101) < subChance)
                {
                    int generatedSub = generationList[rnd.Next(0, generationList.Count)];
                    int generatedSubCount = generatedSub == Element.C ? rnd.Next(IP.clamp(minSubLength, 0, cmaxSubLength), IP.clamp(cmaxSubLength, 0, maxSubLength)) : 1;
                    int bond = Element.SINGLE_BOND;
                    if (generatedSub == Element.O && rnd.Next(0, 101) < 50)
                    {
                        bond = Element.DOUBLE_BOND;
                    }
                    for (int j = 0; j < generatedSubCount; j++)
                    {
                        chemistryGrid.addElement(cc.X, cc.Y + 1 + j * 2, generatedSub, bond);
                    }
                }
                if (rnd.Next(0, 101) < subChance)
                {
                    int generatedSub = generationList[rnd.Next(0, generationList.Count)];
                    int generatedSubCount = rnd.Next(IP.clamp(minSubLength, 0, cmaxSubLength), IP.clamp(cmaxSubLength, 0, maxSubLength));
                    int bond = Element.SINGLE_BOND;
                    if (generatedSub == Element.O && rnd.Next(0, 101) < 50)
                    {
                        bond = Element.DOUBLE_BOND;
                    }
                    for (int j = 0; j < generatedSubCount; j++)
                    {
                        chemistryGrid.addElement(cc.X, cc.Y - 1 - j * 2, generatedSub, bond);
                    }
                }
            }
        }
    }
}
