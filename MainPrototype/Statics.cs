using ClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Firebase.Database;
using Firebase.Database.Query;
using System.Diagnostics;
using System.Threading;

namespace MainPrototype
{
    public static class Statics
    {
        #region Properties
        public const string BaseUrl = "https://patricioclicker.firebaseio.com/";
        public static FirebaseClient Reference { get; set; }
        public static Player Player { get; private set; }
        public static Player ServerPlayer { get; set; }

        public static Color emptyTileColor = Color.FromArgb(80, 166, 166, 166);

        public static Color playerColor = Color.FromArgb(0, 77, 0);

        public static Color enemyColor = Color.FromArgb(130, 85, 162);

        public static Color MovColor = Color.FromArgb(255,188, 224, 182);

        public static Color AtkRangeColor = Color.FromArgb(255,182, 221, 218);

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


        private static Form1 bgScreen;

        public static Thread t;

        public static Form1 BgScreen
        {
            get
            {
                if (bgScreen == null)
                {
                    bgScreen = new Form1();
                }
                return bgScreen;
            }
        }

        #endregion


        #region Static Methods

        //Create

        public static Atributos GenerateModifiers()
        {
            Modificadores = new Atributos(0, 0, 0, 0, Player.Range, 0);
            Player.ItemAtual = new Item(null,"0", "Nadadeira", "A arma mais confiavel", -1, Modificadores);
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
            Player = new Player(p);
            return Player;
        }

        public static Player CreateNewPlayer(int Hp, int Atk, int Def, int X, int Y, int speed, int range, int luck)
        {
            Player = new Player(Hp, Hp, Atk, Def, X, Y, speed, range, luck);
            return Player;
        }



        //Update
        public static void UpdatePlayer(Player p)
        {
            Player = p;

            Player.Atk = Player.Atk <= 0 ? 1 : Player.Atk;

            if (Player.Def <= 0)
                Player.Def = 1;
            if (Player.Speed < 0)
                Player.Speed = 0;
            if (Player.Range <= 0)
                Player.Range = 1;
        }
        public static void UpdatePlayer(int X, int Y)
        {
            Player.X = X;
            Player.Y = Y;
        }
        public static void UpdatePlayer(int mod)
        {
            Player.Hp += mod;
            if (Player.Hp > Player.MaxHp + Player.ItemAtual.StatBonus.Hp)
                Player.Hp = Player.MaxHp + Player.ItemAtual.StatBonus.Hp;
        }
        public static void UpdatePlayer(bool v)
        {

            Player = new Player(ServerPlayer, v)
            {
                IsPlaying = true,
                R = 0
            };

        }
        public static void UpdatePlayer()
        {

            Player = new Player(ServerPlayer)
            {
                IsPlaying = true,
                R = 0
            };

        }

        public static void BreakWeapon()
        {
            Player.ItemAtual = new Item(null, "0", "Nadadeira", "A arma mais confiavel", -1, Modificadores);
        }
        /// <summary>
        /// Esta função salva o player.
        /// </summary>
        /// <param name="p">Player para salvar</param>
        public static void SavePlayer(Player p)
        {
            Player = p;
        }

        public async static void StartGame()
        {
            Reference = new FirebaseClient(BaseUrl);
            Player.IsPlaying = true;
            await Reference.Child("Gamedata").Child("Player").PutAsync<Player>(Player);
            StartListenServerData();
        }

        public static void StartListenServerData()
        {
            Reference.Child("Gamedata").AsObservable<Player>().Subscribe(i =>
            {
                try
                {
                    if (i.Object.IsPlaying)
                    {
                       
                       ServerPlayer = i.Object;
                       
                    }
                }
                catch{ }
                
            });
        }

        public static async Task<bool> UpdateGame()
        {
            await Reference.Child("Gamedata").Child("Player").PutAsync(Player).ContinueWith(r => { return r.IsFaulted == true ? false : true; });
            return false;
        }
        #endregion

    }
}
