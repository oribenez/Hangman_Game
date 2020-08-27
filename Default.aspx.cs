using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Media;

public partial class Main : System.Web.UI.Page
{
    private char startChar = 'א';
    private char endChar = 'ת';

    public string strNamePlaying;
    public string strName;
    public string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["subject"] = Words.Subjects[0];
            Session["score1"] = 0;
            Session["score2"] = 0;
            Session["player1"] = "";
            Session["player2"] = "";
            Session["currentPlayer"] = Session["player1"];
            this.menu.Visible = true;
            this.players.Visible = false;
            this.score.Visible = false;
            this.rules.Visible = false;
            this.game.Visible = false;
            this.pnlJumpMain.Visible = false;
        }

        if (Session["currentPlayer"] == null)
            Response.Redirect(Request.Url.AbsoluteUri);

        

        /*strNamePlaying = "← " + Session["currentPlayer"];


        if (strCurrentPlayer == null || strPlayer1 == null || Session["player2"] == null)
            Response.Redirect(Request.Url.AbsoluteUri);
        strName = strCurrentPlayer.ToString() == strPlayer1.ToString() ? Session["player2"].ToString() : strPlayer1.ToString();*/

        //str = "<audio src='Assets/Audio/super_mario_ands_yos.mp3' autoplay='autoplay' loop='loop'/>";
    }
    protected void wrapLetters_Load(object sender, EventArgs e)
    {
        for (int i = startChar; i <= endChar; i++)
        {
            Button btnChar = new Button();
            btnChar.Text = ((char)i).ToString();
            btnChar.ID = "" + i;
            btnChar.Font.Size = 15;
            btnChar.Click += btnChar_Click;
            btnChar.Width = 50;
            btnChar.Height = 50;
            btnChar.Style.Add("font-size", "30px;");
            wrapLetters.Controls.Add(btnChar);
        }
        
    }
    protected void btnChar_Click(object sender, EventArgs e)
    {
        Button btnClicked = (Button)sender;
        btnClicked.Enabled = false;
        btnClicked.ForeColor = Color.Red;
        btnClicked.Style.Add("cursor", "auto;");
        if (Session["player"] == null)
            Response.Redirect(Request.Url.AbsoluteUri);

        Engine player = (Engine)Session["player"];

        player.CheckGuess(char.Parse(btnClicked.Text));
        this.imgHangman.ImageUrl = "~/Assets/Images/Hangman" + (player.WrongGuess + 1) + ".png";
        ShowWord(InitWordLabels());
        if (player.IsGameOver())
        {
            btnCharGameOver();

            if (Session["currentPlayer"] == null || Session["player1"] == null || Session["player2"] == null)
                Response.Redirect(Request.Url.AbsoluteUri);

            strName = Session["currentPlayer"].ToString() == Session["player1"].ToString() ? Session["player2"].ToString() : Session["player1"].ToString();

            str = @"<audio src='Assets/Audio/peter_griffin_laughing.wav' id='audioCon' autoplay='autoplay'/>";
        }
            str += @"<audio src='Assets/Audio/10211^RVBCLICK.mp3' id='audioCon' autoplay='autoplay'/>";
    }
    protected void pnlWord_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitGame();
        }
        ShowWord(EmptyWord());

       
    }
    private void btnCharGameOver()
    {
        foreach (Control c in wrapLetters.Controls)
        {
            if (c is Button)
            {
                ((Button)c).Enabled = false;
                ((Button)c).ForeColor = Color.Red;
                ((Button)c).Style.Add("cursor", "auto;");
            }
        }

        if (Session["currentPlayer"] == null || Session["player1"] == null)
            Response.Redirect(Request.Url.AbsoluteUri);

        if (Session["currentPlayer"] == Session["player1"].ToString())
        {
            Session["score2"] = (int)Session["score2"] + 1;
        }
        else
        {
            Session["score1"] = (int)Session["score1"] + 1;
        }

        strNamePlaying = strNamePlaying + " הפסיד";

        if (Session["player"] == null)
            Response.Redirect(Request.Url.AbsoluteUri);
        ShowWord(((Engine)Session["player"]).Word);
    }
    private string EmptyWord()
    {
        string startWord = "";
        if (Session["player"] == null)
            Response.Redirect(Request.Url.AbsoluteUri);
        for (int i = 0; i < ((Engine)Session["player"]).Word.Length; i++)
        {
            startWord += " ";
        }
        return startWord;
    }
    private void ShowWord(string word)
    {
        this.tblWord.Rows.Clear();

        TableRow row = new TableRow();
        this.tblWord.Rows.Add(row);

        for (int i = word.Length - 1; i >= 0; i--)
        {
            this.tblWord.Width = word.Length * 100;

            TableCell cell = new TableCell();
            cell.Visible = true;
            cell.Width = 200;
            cell.Height = 70;
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Text = word[i].ToString();

            this.tblWord.Rows[0].Cells.AddAt(0, cell);
        }
    }
    private void ResetChar()
    {
        foreach(Control c in wrapLetters.Controls)
        {
            if (c is Button)
            {
                ((Button)c).Enabled = true;
                ((Button)c).ForeColor = Color.White;
                ((Button)c).Style.Add("cursor", "pointer;");
            }
        }
    }
    private string RandomSubj()
    {
        Random rnd = new Random();
        return Words.Subjects[rnd.Next(Words.Subjects.Length)];
    }
    private void InitGame()
    {
        Words n = new Words();
        Session["subject"] = RandomSubj();
        Engine player = new Engine(n.GetWord(Session["subject"].ToString()));
        Session["player"] = player;
    }
    private string InitWordLabels()
    {
        if (Session["player"] == null)
            Response.Redirect(Request.Url.AbsoluteUri);
        Engine player = (Engine)Session["player"];
        char[] currentGuess = player.CurrentGuess;
        string word = player.Word;
        string finish = "";

        for (int i = 0; i < word.Length; i++)
        {
            bool flag = false;
            for (int j = 0; j < currentGuess.Length; j++)
            {
                if (word[i] == currentGuess[j])
                {
                    finish += word[i];
                    j = currentGuess.Length;
                    flag = true;
                }
            }
            if (!flag)
            {
                finish += " "; // add space
            }
        }

        if (finish == player.Word)
        {
            str = "<audio src='Assets/Audio/SMALL_CROWD_APPLAUSE-Yannick_Lemieux-1268806408.wav' autoplay='autoplay'/>";

            if (Session["currentPlayer"] == null || Session["player1"] == null || Session["player2"] == null)
                Response.Redirect(Request.Url.AbsoluteUri);
            Session["currentPlayer"] = Session["currentPlayer"].ToString() == Session["player1"].ToString() ? Session["player2"].ToString() : Session["player2"].ToString();
            strNamePlaying = "← " + Session["currentPlayer"].ToString();
            strName = Session["currentPlayer"].ToString() == Session["player2"].ToString() ? Session["player2"].ToString() : Session["player2"].ToString();

            this.imgHangman.ImageUrl = "~/Assets/Images/Hangman1.png";
            ResetChar();
            player.ResetEngine();
            InitGame();
            finish = EmptyWord();
        }
        return finish;
    }
    protected void newGame_Click(object sender, EventArgs e)
    {

        InitGame(); // New word
        ShowWord(EmptyWord()); // New placeholders 
        ResetChar(); // Reset char
        this.imgHangman.ImageUrl = "~/Assets/Images/Hangman1.png";
    }
    protected void btnPlayersNames_Click(object sender, EventArgs e) {
        this.menu.Visible = false;
        this.score.Visible = false;
        this.rules.Visible = false;
        this.game.Visible = false;
        this.pnlJumpMain.Visible = true;
        this.newGame.Visible = false;
    }
    protected void btnStartGame_Click(object sender, EventArgs e)
    {
        this.menu.Visible = false;
        this.players.Visible = false;
        this.score.Visible = false;
        this.rules.Visible = false;
        this.game.Visible = true;
        this.pnlJumpMain.Visible = true;
        this.newGame.Visible = true;

        Session["player1"] = this.txtPlayerName1.Text.Trim() == "" ? "שחקן 1" : this.txtPlayerName1.Text.Trim();
        Session["player2"] = this.txtPlayerName2.Text.Trim() == "" ? "שחקן 2" : this.txtPlayerName2.Text.Trim();
        Session["currentPlayer"] = Session["player1"].ToString();

        strNamePlaying = "← " + Session["currentPlayer"];
        strName = Session["currentPlayer"].ToString() == Session["player1"].ToString() ? Session["player2"].ToString() : Session["player1"].ToString();
    }
    protected void btnScore_Click(object sender, EventArgs e)
    {
        this.menu.Visible = false;
        this.score.Visible = true;
        this.rules.Visible = false;
        this.game.Visible = false;
        this.pnlJumpMain.Visible = true;
    }
    protected void btnRules_Click(object sender, EventArgs e)
    {
        this.menu.Visible = false;
        this.score.Visible = false;
        this.rules.Visible = true;
        this.game.Visible = false;
        this.pnlJumpMain.Visible = true;
    }
    protected void jumpMain_Click(object sender, EventArgs e)
    {
        this.menu.Visible = true;
        this.score.Visible = false;
        this.rules.Visible = false;
        this.game.Visible = false;
        this.pnlJumpMain.Visible = false;

        InitGame(); // New word
        if (Session["player"] == null)
            Response.Redirect(Request.Url.AbsoluteUri);

        string word = ((Engine)Session["player"]).Word; // The HOLY word
        ShowWord(EmptyWord()); // New placeholders 
        ResetChar(); // Reset char
        this.imgHangman.ImageUrl = "~/Assets/Images/Hangman1.png";
    }

    
}
