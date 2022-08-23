using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class InputClassPC
    {
        int i = -1;
        int j = -1;
        Random random = new Random();        

        public void readKeyPC(Player pc, Handler handler)
        { 
            while(true)
            {
                i = random.Next(10);
                j = random.Next(10);                

                if (pc.getMyMoveElement(i,j) == 1 || pc.getMyMoveElement(i, j) == 2)
                {
                    continue;                    
                }
                else if (pc.getMyMoveElement(i, j) == 0)
                {
                    break;
                }
            }//end while

            handler.iPC = i;
            handler.jPC = j;

            i = -1;
            j = -1;                      
        }//end readKey 
    }
}
