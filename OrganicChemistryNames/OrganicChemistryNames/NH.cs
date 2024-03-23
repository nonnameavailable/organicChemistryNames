﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicChemistryNames
{
    class NH
    {
        public static List<Element> longestCarbonChain(int[][] grid)
        {
            List<Swarm> swarms = new List<Swarm>();
            foreach (Element ec in endCarbons(grid))
            {
                swarms.Add(new Swarm(ec.X, ec.Y, grid));
            }
            if (swarms.Count == 0) return new List<Element>();

            List<Element> result = swarms[0].LongestPath;
            foreach (Swarm sw in swarms)
            {
                if (sw.LongestPath.Count > result.Count) result = sw.LongestPath;
            }
            return result;
        }
        public static List<Element> longestCarbonChain(int[][] grid, Element startCarbon)
        {
            return new Swarm(startCarbon.X, startCarbon.Y, grid).LongestPath;
        }
        public static List<Element> endCarbons(int[][] grid)
        {
            List<Element> result = new List<Element>();
            List<Element> allCarbs = listOfElements(Element.C, grid);
            if (allCarbs.Count == 1) return allCarbs;
            foreach (Element c in allCarbs)
            {
                if (c.neighboringElements(grid, Element.C).Count == 1) result.Add(c);
            }
            return result;
        }

        public static List<Element> listOfElements(int type, int[][] grid)
        {
            int width = grid[0].Length;
            int height = grid.Length;
            List<Element> result = new List<Element>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int val = grid[j][i];
                    if (val == type || type == Element.ALL) result.Add(new Element(i, j, val));
                }
            }
            return result;
        }

        public static List<Element> longestCCBonds(List<Element> longestCC, int[][] grid)
        {
            List<Element> result = new List<Element>();
            if (longestCC.Count < 2) return result;
            for (int i = 0; i < longestCC.Count - 1; i++)
            {
                Element currentCarbon = longestCC[i];
                Element nextCarbon = longestCC[i + 1];
                Element bond = currentCarbon.bondBetween(nextCarbon, grid);
                bond.CarbonChainConnection = i + 1;
                result.Add(bond);
            }
            return result;
        }

        public static int[][] gridWithoutList(int[][] grid, List<Element> list)
        {
            int[][] result = IP.arrCopy(grid);
            foreach(Element e in list)
            {
                result[e.Y][e.X] = 0;
            }
            return result;
        }
    }
}