﻿using ClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MainPrototype
{
    public static class Statics
    {
        #region Properties
        public static Player Player { get; private set; }

        public static Color emptyTileColor = Color.FromArgb(80, 166, 166, 166);

        public static Color playerColor = Color.FromArgb(0, 77, 0);

        public static Color enemyColor = Color.FromArgb(130, 85, 162);

        public static Color MovColor = Color.FromArgb(51, 204, 51);

        public static Color AtkRangeColor = Color.FromArgb(51, 153, 255);

        public static Atributos Modificadores { get; private set; }

        private static MenuScreen menuScreen;

        public static MenuScreen MenuScreen
        {
            get
            {
                if (menuScreen == null)
                {
                    menuScreen = new MenuScreen();
                }
                return menuScreen;
            }
        }

        #endregion


        #region Static Methods

        //Create

        public static Atributos GenerateModifiers()
        {
            Modificadores = new Atributos(0, 0, 0, 0, Player.Range, 0);

            return Modificadores;
        }




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

        public static Player CreateNewPlayer(int Hp,int Atk, int Def, int X, int Y, int speed, int range, int luck)
        {
            Player = new Player(Hp,Hp,Atk,Def,X,Y, speed, range, luck);
            return Player;
        }



        //Update
        public static void UpdatePlayer(Player p)
        {
            Player = p;
            if (Player.Atk <= 0)
                Player.Atk = 1;
            if (Player.Def <= 0)
                Player.Def = 1;
            if (Player.Speed < 0)
                Player.Speed = 0;
            if (Player.Range <= 0)
                Player.Range = 1;
        }
        public static void UpdatePlayer(int X,int Y)
        {
            Player.X = X;
            Player.Y = Y;
        }
        public static void UpdatePlayer(int mod)
        {
            Player.Hp += mod;
            if (mod > Player.MaxHp)
                Player.Hp = Player.MaxHp;           
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
