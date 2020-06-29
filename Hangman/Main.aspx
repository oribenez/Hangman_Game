<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html>

<html dir="rtl" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>איש תלוי</title>
    <link href="Assets/Style/main.css" rel="stylesheet" />
    <link rel="shortcut icon" type="img/png" href="Assets/Images/favicon.png" />

    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-47277497-2', 'pixelart.org.il');
        ga('send', 'pageview');

</script>

</head>
<body>
    <div id="parent">
        <div id="sky">
            <div class="cloud" style="margin: 0;  opacity: 0.7;"></div>
            <div class="cloud" style="margin: 100px 1400px 0 0;  opacity: 0.4;"></div>
            <div class="cloud" style="margin: 300px 1100px 0 0;  opacity: 0.5;"></div>
            <div class="cloud" style="margin: 200px 400px 0 0;opacity: 0.8;"></div>
            <div class="cloud" style="margin: 0 600px 0 0;bottom:50px;opacity: 0.8;"></div>
        </div>
        <form id="form1" runat="server">
        
            <div class="main">
                <asp:Panel ID="pnlJumpMain" CssClass="btnStl" runat="server">
                    <asp:Button ID="jumpMain" runat="server" Text="> לתפריט הראשי" OnClick="jumpMain_Click" />
                </asp:Panel>
                <h1>איש תלוי</h1>
                <asp:Panel ID="menu" runat="server">

                    <div id="wrapImg">
                        <img src="Assets/Images/HangmanSit.png" />
                    </div>

                    <div id="wrapBtns">
                        <asp:Button ID="btnStart" runat="server" Text="התחל משחק" OnClick="btnStart_Click"  />
                        <br />
                        <asp:Button ID="btnRules" runat="server" Text="הוראות" OnClick="btnRules_Click" />
                        <br />
                        <asp:Button ID="btnScore" runat="server" Text="תוצאות" OnClick="btnScore_Click" />
                    </div>
      
                    <div style="clear:both;"></div>
                </asp:Panel>

                <asp:Panel ID="rules" runat="server">
                    <h2>איך משחקים?</h2>
                    <p><b>כולם בטח מכירים את המשחק איש תלוי אבל למי שלא, כך משחקים: </b><br />

    <b>המטרה:</b> לנחש את המילה<br />
    <b>הוראות: </b>אני כותב את נושא המילה (סרטים, קבוצות, שחקנים...) וכמה אותיות היא מכילה.<br />
    צריך לנחש אותיות מהמילה<br />
                        אם הצלחתם לנחש את המילה אז כל הכבוד!, והתור עובר לשחק השני
    המשחק נגמר כאשר ניחשתם 5 פעמים לא נכון, ואז עולה נקודה לשחקן השני</p>
                </asp:Panel>

                <asp:Panel ID="score" runat="server">
                    <div id="wrapScore">
                        <h2>תוצאות</h2>
                        <table id="tblScore">
                            <tr>
                                <th>כינוי</th>
                                <th>תוצאה</th>
                            </tr>

                            <tr>
                                <td><%=Session["player1"] %></td>
                                <td><%=Session["score1"] %></td>
                            </tr>
                            <tr>
                                <td><%=Session["player2"] %></td>
                                <td><%=Session["score2"] %></td>
                            </tr>
                        </table>
                    </div>
                    <div style="clear:both;"></div>
                </asp:Panel>

                <asp:Panel ID="game" runat="server">
                
                    <asp:Panel ID="pnlHangman" runat="server">
                        <div id="wrapImgHangman">
                            <asp:Image ID="imgHangman" ImageUrl="~/Assets/Images/Hangman1.png" runat="server" />
                        </div>
                        <asp:Panel ID="info" runat="server">
                            <asp:Panel ID="wrapPlayers" runat="server">
                                <b>שחקנים</b>
                                <asp:Panel ID="namePlaying" runat="server"><%=strNamePlaying %></asp:Panel>
                                <asp:Panel ID="name" runat="server"><%=strName %></asp:Panel>
                            </asp:Panel>
                            <asp:Panel ID="pnlNewGame" runat="server"><asp:Button ID="newGame" runat="server" Text="משחק חדש" OnClick="newGame_Click" /></asp:Panel>
                        </asp:Panel>
                    
                        <asp:Panel ID="pnlLetters" runat="server">
                            <div id="grass"><asp:Panel ID="wrapSubject" runat="server"><%=Session["subject"] %></asp:Panel></div>
                            <asp:Panel ID="pnlWord" runat="server" OnLoad="pnlWord_Load">
                                <asp:Table ID="tblWord" runat="server"></asp:Table>
                            </asp:Panel>
                            <asp:Panel ID="wrapLetters" runat="server" OnLoad="wrapLetters_Load"></asp:Panel>
                        </asp:Panel>
                    
                    </asp:Panel>
                    <%--<div id="gameOver">
                        המשחק הסתיים <br /> אופיר הפסיד
                    </div>--%>
                </asp:Panel>
            </div>
        </form>
        
    </div>
    <%=str %>
</body>
</html>
