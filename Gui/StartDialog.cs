using System;
using System.Windows.Forms;

namespace ChessEngine
{
    public partial class StartDialog : Form
    {
        public static string whitePlayerName = null;
        public static string blackPlayerName = null;

        public StartDialog()
        {
            InitializeComponent();
        }

        private void play_Button_Click(object sender, EventArgs e)
        {
            string wpn = white_TextBox.Text.Trim();
            string bpn = black_TextBox.Text.Trim();

            if (wpn != "" && bpn != "")
            {
                whitePlayerName = wpn;
                blackPlayerName = bpn;

                Close();
            }
            else
            {
                MessageBox.Show("You must enter WHITE and BLACK player names!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
