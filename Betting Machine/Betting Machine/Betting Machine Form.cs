using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Betting_Machine
{
    public partial class EditField : Form
    {
        public EditField()
        {
            InitializeComponent();
            exitButton.MouseEnter += OnMouseEnterExit;
            exitButton.MouseLeave += OnMouseLeaveExit;
            minimizeButton.MouseEnter += OnMouseEnterMin;
            minimizeButton.MouseLeave += OnMouseLeaveMin;
            playButton.MouseEnter += OnMouseEnterPlay;
            playButton.MouseLeave += OnMouseLeavePlay;
            settingsButton.MouseEnter += OnMouseEnterSetting;
            settingsButton.MouseLeave += OnMouseLeaveSetting;
            rulesButton.MouseEnter += OnMouseEnterRules;
            rulesButton.MouseLeave += OnMouseLeaveRules;
            aboutButton.MouseEnter += OnMouseEnterAbout;
            aboutButton.MouseLeave += OnMouseLeaveAbout;

        }
        #region Variables
        int mouseX = 0, mouseY = 0, NumOfPlayers = 0, moneyInTheBank = 0, ante = 0, NumOfBettingRounds = 0, bankSize = 0, anteSize = 0;

        bool mouseDown, fileSettings = false;
        #endregion
        #region Mouse Hovers
        private void OnMouseEnterExit(object sender, EventArgs e)
        {
            exitButton.BackColor = System.Drawing.Color.SlateGray;
        }
        private void OnMouseLeaveExit(object sender, EventArgs e)
        {
            exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(168)))), ((int)(((byte)(189)))));
        }
        private void OnMouseEnterMin(object sender, EventArgs e)
        {
            minimizeButton.BackColor = System.Drawing.Color.SlateGray;
        }
        private void OnMouseLeaveMin(object sender, EventArgs e)
        {
            minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(168)))), ((int)(((byte)(189)))));
        }
        private void OnMouseEnterPlay(object sender, EventArgs e)
        {
            playButtonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(202)))), ((int)(((byte)(44)))));

        }
        private void OnMouseLeavePlay(object sender, EventArgs e)
        {
            playButtonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(50)))));

        }
        private void OnMouseEnterSetting(object sender, EventArgs e)
        {
            settingsButtonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(202)))), ((int)(((byte)(44)))));

        }
        private void OnMouseLeaveSetting(object sender, EventArgs e)
        {
            settingsButtonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(50)))));

        }
        private void OnMouseEnterRules(object sender, EventArgs e)
        {
            rulesButtonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(202)))), ((int)(((byte)(44)))));

        }
        private void OnMouseLeaveRules(object sender, EventArgs e)
        {
            rulesButtonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(50)))));

        }
        private void OnMouseEnterAbout(object sender, EventArgs e)
        {
            aboutButtonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(202)))), ((int)(((byte)(44)))));

        }
        private void OnMouseLeaveAbout(object sender, EventArgs e)
        {
            aboutButtonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(50)))));

        }
        #endregion
        #region Button Clicks
        #region Form Interactions
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
        #region Banner move
        private void Banner_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 600;
                mouseY = MousePosition.Y - 20;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }
        private void Banner_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void Banner_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }
        #endregion
        #region Image Clicks
        private void playButtonImage_Click(object sender, EventArgs e)
        {
            playButton_Click(sender, e);
        }
        private void settingsButtonImage_Click(object sender, EventArgs e)
        {
            settingsButton_Click(sender, e);
        }
        private void rulesButtonImage_Click(object sender, EventArgs e)
        {
            rulesButton_Click(sender, e);
        }
        private void aboutButtonImage_Click(object sender, EventArgs e)
        {
            aboutButton_Click(sender, e);
        }
        #endregion
        #region Menu Clicks
        private void playButton_Click(object sender, EventArgs e)
        {
            dispelMenuIndicators();
            playMenuActive.Visible = true;
            dispelTitleScreen();

            if (fileSettings == false)
            {
                settingsButton_Click(sender, e);
            }
            else
            {
                
            }
        }
        private void settingsButton_Click(object sender, EventArgs e)
        {
            dispelMenuIndicators();
            settingsMenuActive.Visible = true;
            dispelTitleScreen();

            SettingsPanel.Visible = true;
        }
        private void rulesButton_Click(object sender, EventArgs e)
        {
            dispelMenuIndicators();
            rulesMenuActive.Visible = true;
            dispelTitleScreen();

        }
        private void aboutButton_Click(object sender, EventArgs e)
        {
            dispelMenuIndicators();
            aboutMenuActive.Visible = true;
            dispelTitleScreen();
        }
        #endregion
        #region Settings Menu Interactions
        private void TwoPlayersButton_Click(object sender, EventArgs e)
        {
            NumOfPlayers = 2;
            activeNumberOfPlayers();
            this.TwoPlayersButton.BackColor = System.Drawing.Color.DimGray;
        }
        private void ThreePlayersButton_Click(object sender, EventArgs e)
        {
            NumOfPlayers = 3;
            activeNumberOfPlayers();
            this.ThreePlayersButton.BackColor = System.Drawing.Color.DimGray;
        }
        private void FourPlayersButton_Click(object sender, EventArgs e)
        {
            NumOfPlayers = 4;
            activeNumberOfPlayers();
            this.FourPlayersButton.BackColor = System.Drawing.Color.DimGray;
        }
        private void FivePlayersButton_Click(object sender, EventArgs e)
        {
            NumOfPlayers = 5;
            activeNumberOfPlayers();
            this.FivePlayersButton.BackColor = System.Drawing.Color.DimGray;
        }
        private void SixPlayersButton_Click(object sender, EventArgs e)
        {
            NumOfPlayers = 6;
            activeNumberOfPlayers();
            this.SixPlayersButton.BackColor = System.Drawing.Color.DimGray;
        }
        private void bankCheckButton_Click(object sender, EventArgs e)
        {
            errorImageMitB.Visible = false;
            if (int.TryParse(bankTextBox.Text, out bankSize))
                return;
            else
                errorImageMitB.Visible = true;
        }
        private void anteCheckButton_Click(object sender, EventArgs e)
        {
            errorImageA.Visible = false;
            if (int.TryParse(anteTextBox.Text, out anteSize))
                return;
            else
                errorImageA.Visible = true;
        }
        private void oneBettingRoundButton_Click(object sender, EventArgs e)
        {
            NumOfBettingRounds = 1;
            activeBettingRounds();
            this.oneBettingRoundButton.BackColor = System.Drawing.Color.DimGray;
        }

        private void Banner_Click(object sender, EventArgs e)
        {

        }

        private void twoBettingRoundsButton_Click(object sender, EventArgs e)
        {
            NumOfBettingRounds = 2;
            activeBettingRounds();
            this.twoBettingRoundsButton.BackColor = System.Drawing.Color.DimGray;
        }
        private void threeBettingRoundsButton_Click(object sender, EventArgs e)
        {
            NumOfBettingRounds = 2;
            activeBettingRounds();
            this.threeBettingRoundsButton.BackColor = System.Drawing.Color.DimGray;
        }
        private void fourBettingRoundsButton_Click(object sender, EventArgs e)
        {
            NumOfBettingRounds = 2;
            activeBettingRounds();
            this.fourBettingRoundsButton.BackColor = System.Drawing.Color.DimGray;
        }
        private void continueToPlayMenu_Click(object sender, EventArgs e)
        {
            errorImageNoP.Visible = false;
            errorImageMitB.Visible = false;
            errorImageA.Visible = false;
            errorImageNoBR.Visible = false;

            if (NumOfPlayers == 0)
                errorImageNoP.Visible = true;
            if (string.IsNullOrWhiteSpace(bankTextBox.Text) == true)
                errorImageMitB.Visible = true;
            if (string.IsNullOrWhiteSpace(anteTextBox.Text) == true)
                errorImageA.Visible = true;
            if (NumOfBettingRounds == 0)
                errorImageNoBR.Visible = true;
        }
        #endregion
        #endregion
        #region Functions
        void dispelMenuIndicators()
        {
            playMenuActive.Visible = false;
            settingsMenuActive.Visible = false;
            rulesMenuActive.Visible = false;
            aboutMenuActive.Visible = false;
        }
        void activeNumberOfPlayers()
        {
            this.TwoPlayersButton.BackColor = System.Drawing.Color.SlateGray;
            this.ThreePlayersButton.BackColor = System.Drawing.Color.SlateGray;
            this.FourPlayersButton.BackColor = System.Drawing.Color.SlateGray;
            this.FivePlayersButton.BackColor = System.Drawing.Color.SlateGray;
            this.SixPlayersButton.BackColor = System.Drawing.Color.SlateGray;
        }
        void activeBettingRounds()
        {
            this.oneBettingRoundButton.BackColor = System.Drawing.Color.SlateGray;
            this.twoBettingRoundsButton.BackColor = System.Drawing.Color.SlateGray;
            this.threeBettingRoundsButton.BackColor = System.Drawing.Color.SlateGray;
            this.fourBettingRoundsButton.BackColor = System.Drawing.Color.SlateGray;
        }
        void dispelTitleScreen()
        {
            FDLogoMain.Dispose();
            BetTitleScreen.Dispose();
            machineTitleScreen.Dispose();
        }
        #endregion
    }
}
