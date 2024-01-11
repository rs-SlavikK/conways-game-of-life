using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace V1
{
    partial class LifeForm
    {
        // aOld Matrix mit der n-ten Generation
        // aNew Matrix mit der n+1-ten Generation
        void CalcNextGeneration(bool[,] aOld, bool[,] aNew)
        {
            m_CC = aOld; // sicherstellen, daﬂ m_CC=aOld ist
            /*
                Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                Any live cell with two or three live neighbours lives on to the next generation.
                Any live cell with more than three live neighbours dies, as if by overpopulation.
                Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.            
             */

            for (int x = 0; x < MAX_CELLS; x++)
            {
                for (int y = 0; y < MAX_CELLS; y++)
                {
                    if ((aOld[x, y] == true) && GetNeighbourCount(x, y) < 2)
                    {
                        aNew[x, y] = false;
                        continue;
                    }


                    else if ((aOld[x, y] == true) && (GetNeighbourCount(x, y) == 2 || GetNeighbourCount(x, y) == 3))
                    {
                        aNew[x, y] = true;
                        continue;
                    }


                    else if ((aOld[x, y] == true) && GetNeighbourCount(x, y) > 3)
                    {
                        aNew[x, y] = false;
                        continue;
                    }


                    else if ((aOld[x, y] == false) && GetNeighbourCount(x, y) == 3)
                    {
                        aNew[x, y] = true;
                        continue;
                    }
 
                }
            }            
        }

        void ClearCells(bool[,] aCells)
        {
            // alle Zellen von aCells auf false

            for (int x = 0; x < MAX_CELLS; x++)
            {
                for (int y = 0; y < MAX_CELLS; y++)
                {
                    aCells[x, y] = false;
                }
            }
        }

        // cells of m_CC
        void TurnCellOnOff(int aX, int aY, MouseEventArgs e)
        {  
            // Cell an der Stelle aX,aY toggeln ( Umschalten )
            m_CA[e.Location.X / CELL_SIZE, e.Location.Y / CELL_SIZE] = !m_CA[e.Location.X / CELL_SIZE, e.Location.Y / CELL_SIZE];
        }

        // cells of m_CC
        int GetNeighbourCount(int x, int y)
        {
            int neighbours = 0;
            for (int i = -1; i <= 1; i++)
            {

                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    int dx = (x + i+MAX_CELLS)%MAX_CELLS, dy = (y + j + MAX_CELLS) % MAX_CELLS;
                    if (m_CC[dx,dy])
                        neighbours++;
                }
            }
            return neighbours;
        }

        // Ist Cell(i,j) von m_CC on oder off ?
        // mit richtiger Behandlung von i,j<0 und i,j>=MAX_CELLS
        bool ValOf(int i, int j)
        {
            return true;
        }
    }
}
