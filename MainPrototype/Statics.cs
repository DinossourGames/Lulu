using ClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPrototype
{
    public static class Statics
    {
        #region Properties
        public static Player Player { get; private set; }

        #endregion


        #region Static Methods

        //Create

        /// <summary>
        /// Cria uma nova instancia de Player que irá persistir em tempo de execução
        /// </summary>
        /// <returns>Property player</returns>
        public static Player CreateNewPlayer()
        {
            Player = new Player();
            return Player;
        }

        public static Player CreateNewPlayer(Player p)
        {
            Player = new Player();
            return Player;
        }

        public static Player CreateNewPlayer(int Hp,int Atk, int Def, int X, int Y)
        {
            Player = new Player(Hp,Atk,Def,X,Y);
            return Player;
        }



        //Update
        public static void UpdatePlayer(Player p)
        {
            Player = p;
        }
        public static void UpdatePlayer(int X,int Y)
        {
            Player.X = X;
            Player.Y = Y;
        }
        /// <summary>
        /// Esta função salva o player.
        /// </summary>
        /// <param name="p">Player para salvar</param>
        public static void SavePlayer(Player p)
        {
            Player = p;
        }

        #endregion
    }
}
