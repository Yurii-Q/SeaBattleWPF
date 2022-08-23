using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class Handler
    {
        public int iPC { get; set; } = -1;
        public int jPC { get; set; } = -1;

        public int iPlayer { get; set; } = -1;
        public int jPlayer { get; set; } = -1;

        private Player player;
        private Player pc;
        public Handler(Player player, Player pc)
        {
            this.player = player;
            this.pc = pc;
        }

        public int handler()
        {
            //Player got to ship of PC
            if (pc.getFieldElement(iPlayer, jPlayer) == 1)
            {
                pc.setFieldElement(iPlayer, jPlayer, 2);
                pc.numberShips--;
                player.setMyMoveElement(iPlayer, jPlayer, 1);
                hundlerFunction(player, iPlayer, jPlayer);
            }
            //Player miss to ship of PC
            else if(pc.getFieldElement(iPlayer, jPlayer) == 0)
            {
                player.setMyMoveElement(iPlayer, jPlayer, 2);
            }

            if (pc.numberShips <= 0) return 1;

            //PC got to ship of player
            if(player.getFieldElement(iPC, jPC) == 1)
            {
                player.setFieldElement(iPC, jPC, 2);
                player.numberShips--;
                pc.setMyMoveElement(iPC, jPC, 1);
                hundlerFunction(pc, iPC, jPC);
            }
            //PC miss to ship of player
            else if(player.getFieldElement(iPC, jPC) == 0)
            {
                pc.setMyMoveElement(iPC,jPC, 2);
            }

            if (player.numberShips <= 0) return 2;

            return 0;
        }

        private void hundlerFunction(Player pl, int i, int j)
        {
            if (i > 0 && i < pl.getSizeField() - 1 && j > 0 && j < pl.getSizeField() - 1)
            {
                pl[i + 1, j] = 2;
                pl[i - 1, j] = 2;
                pl[i, j + 1] = 2;
                pl[i, j - 1] = 2;
                pl[i + 1, j + 1] = 2;
                pl[i - 1, j - 1] = 2;
                pl[i + 1, j - 1] = 2;
                pl[i - 1, j + 1] = 2;                
            }
            else if (i == 0 && j == 0)
            {
                pl[i + 1, j] = 2;
                pl[i, j + 1] = 2;
                pl[i + 1, j + 1] = 2;                
            }
            else if (i == pl.getSizeField() - 1 && j == pl.getSizeField() - 1)
            {
                pl[i - 1, j] = 2;
                pl[i, j - 1] = 2;
                pl[i - 1, j - 1] = 2;                
            }
            else if (i == pl.getSizeField() - 1 && j == 0)
            {
                pl[i - 1, j] = 2;
                pl[i, j + 1] = 2;
                pl[i - 1, j + 1] = 2;                
            }
            else if (i == 0 && j == pl.getSizeField() - 1)
            {
                pl[i + 1, j] = 2;
                pl[i, j - 1] = 2;
                pl[i + 1, j - 1] = 2;                
            }
            else if (i == 0)
            {
                pl[i, j + 1] = 2;
                pl[i, j - 1] = 2;
                pl[i + 1, j] = 2;
                pl[i + 1, j + 1] = 2;
                pl[i + 1, j - 1] = 2;                
            }
            else if (i == pl.getSizeField() - 1)
            {
                pl[i - 1, j] = 2;
                pl[i - 1, j + 1] = 2;
                pl[i, j - 1] = 2;
                pl[i, j + 1] = 2;
                pl[i - 1, j - 1] = 2;                
            }
            else if (j == 0)
            {
                pl[i + 1, j] = 2;
                pl[i - 1, j] = 2;
                pl[i, j + 1] = 2;
                pl[i - 1, j + 1] = 2;
                pl[i + 1, j + 1] = 2;                
            }
            else if (j == pl.getSizeField() - 1)
            {
                pl[i - 1, j] = 2;
                pl[i + 1, j] = 2;
                pl[i, j - 1] = 2;
                pl[i - 1, j - 1] = 2;
                pl[i + 1, j - 1] = 2;                
            }
        }
    }
}






