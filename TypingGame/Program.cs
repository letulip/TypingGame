using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingGame
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// 
        /// TypingGame
        ///
        ///This is WindowsForms game.It is Awesome.
        ///
        ///The form displays random letters
        ///If the pleyer types one of them, it disapears and the accuracy rate goes up
        ///If the player an incorrect letter, the accuracy rate goes down
        ///As the player keeps typing letters, the game goes faster and faster, getting more difficult with each correct latter
        ///If the form fills up with letters, the game is over!
        ///
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
