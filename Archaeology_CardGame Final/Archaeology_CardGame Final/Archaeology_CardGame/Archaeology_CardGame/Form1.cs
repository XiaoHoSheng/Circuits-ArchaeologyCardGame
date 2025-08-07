using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archaeology_CardGame
{
    public partial class Form1 : Form
    {
        //NAME: Jason Yang
        //ID: 1614276
        private readonly Deck _deck;
        protected int discardAmountP1;
        protected int discardAmountP2;
        private bool _drawnCard;
        private bool _exploreMode;
        protected List<Card> marketPlace = new List<Card>();

        private bool _modeLock = false; // Lock to share between modes
        protected List<Card> player1Cards;
        protected int player1Gold;
        protected List<Card> player2Cards;
        protected int player2Gold;

        private readonly Dictionary<string, int[]> _priceChart = new Dictionary<string, int[]>
        {
            // cardName, sellingValue according to set number
            { "shard", new[] { 1, 2, 3, 4, 15 } },
            { "scrap", new[] { 1, 2, 3, 10, 10 } },
            { "coin", new[] { 2, 5, 10, 18, 30 } },
            { "talisman", new[] { 3, 7, 14, 24, 40 } },
            { "cup", new[] { 2, 15, 15, 15, 15 } },
            { "map", new[] { 3, 3, 3, 3, 3 } },
            { "mask", new[] { 4, 12, 26, 50, 50 } }
        };

        private bool _currentPlayer = true; // false -> player1, true -> player2
        private bool _sandstormMode = false;
        private bool _sellMode = false;
        private bool _start = false;
        private bool _stealMode = false;
        private bool _tradeMode = false;
        private int _totalTradeValue = 0;

        public Form1()
        {
            InitializeComponent();
            _deck = new Deck();
            player1Cards = new List<Card>();
            player2Cards = new List<Card>();
        }

        private void GiveCards(Graphics graphics, List<Card> playerList, int CardSize, bool cardType, bool flipped)
        {
            var xpos = 10;
            for (var i = 0; i < CardSize; i++)
            {
                var c = _deck.Dig();
                c.Flipped = flipped;
                playerList.Add(c);

                if (cardType)
                {
                    c.DrawCard(graphics, xpos);
                    xpos += c.GetWidth() + 10;
                }
            }

            labelLeftover.Text = _deck.Count.ToString();
        }

        private void GiveCardToPlayer(Graphics graphics, List<Card> playerList)
        {
            var count = playerList.Count;

            if (_deck.Count == 0)
            {
                labelGameStatus.Text = "Game Over";
                if (player1Gold > player2Gold)
                    MessageBox.Show("Player 1 won.");
                else if (player1Gold < player2Gold)
                    MessageBox.Show("Player 2 won.");
                else
                    MessageBox.Show("Draw.");
                // TODO add proper win condition. Successive passing..
                return;
            }

            var c = _deck.Dig();
            c.Flipped = true;
            var cardName = c.CardName;
            if (cardName == "thief")
            {
                labelGameStatus.Text = "Randomly stealing one card. Press confirm to continue.";
                _modeLock = true;
                _stealMode = true;
                // TODO Draw the thief card somewhere
            }
            else if (cardName == "sandstorm")
            {
                labelGameStatus.Text = "Sandstorm... Discard half your cards.";
                // Reset turn
                resetModes();
                _drawnCard = false;
                _modeLock = true;
                _sandstormMode = true;
                discardAmountP1 = player1Cards.Count / 2;
                discardAmountP2 = player2Cards.Count / 2;
                if (_currentPlayer)
                    labelGameStatus.Text = "P1: Num of cards to discard: " + discardAmountP1;
                else
                    labelGameStatus.Text = "P2: Num of cards to discard: " + discardAmountP2;
            }
            else
            {
                labelGameStatus.Text = "Digging... Dug up: " + c.CardName;
                var xpos = playerList.Count * (c.Image.Width / 4 + 10) + 10;
                playerList.Add(c);
                c.DrawCard(graphics, xpos);
            }


            labelLeftover.Text = _deck.Count.ToString();
        }

        private void FlipCards(List<Card> cards, PictureBox pb)
        {
            foreach (var c in cards)
                c.Flipped = !c.Flipped;
            reDraw(cards, pb);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var p1 = pictureBoxPlayer1.CreateGraphics();
            var p2 = pictureBoxPlayer2.CreateGraphics();
            var p3 = pictureBoxMarketPlace.CreateGraphics();
            _deck.Shuffle();
            GiveCards(p1, player1Cards, 4, true, true);
            GiveCards(p2, player2Cards, 4, true, false);
            GiveCards(p3, marketPlace, 5, true, true);

            for(var i = 0; i < 6; i++) _deck.AddCard(new Map());
            for (var i = 0; i < 8; i++) _deck.AddCard(new Thief());
            _deck.AddCard(new SandStorm());

            _deck.Shuffle();
            _start = true;

            buttonStart.Enabled = false; // TODO Add restart
            labelLeftover.Text = _deck.Count.ToString();
            labelPlayer1Gold.Text = "Player 1 Gold: 0";
            labelPlayer2Gold.Text = "Player 2 Gold: 0";
        }

        private void buttonDrawCard_Click(object sender, EventArgs e)
        {
            if (_start)
            {
                if (_drawnCard)
                {
                    MessageBox.Show("You have already drawn a card.");
                    return;

                }
                _drawnCard = true;
                if (_currentPlayer)
                {
                    GiveCardToPlayer(pictureBoxPlayer1.CreateGraphics(), player1Cards);
                }
                else
                {
                    GiveCardToPlayer(pictureBoxPlayer2.CreateGraphics(), player2Cards);
                }
            }
        }

        private void buttonTrade_Click(object sender, EventArgs e)
        {
            _tradeMode = true;
            _modeLock = true;
            labelGameStatus.Text = "Select cards from hand to be traded";
            buttonTrade.Enabled = false;
        }


        private void pictureBoxPlayer1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_modeLock || _stealMode) return;
            // Player1 can only sell from player1's hand. Ignore
            if ((_sellMode || _tradeMode) && !_currentPlayer) return;
            // Discard current player's hand only or maximum num has been selected
            if ((_sandstormMode && !_currentPlayer) || (_sandstormMode && discardAmountP1 == 0)) return;

            pictureBoxPlayer1.Refresh();
            foreach (var card in player1Cards)
            {
                var clicked = card.CardClicked(pictureBoxPlayer1.CreateGraphics(), e.X, e.Y);
                if (_sandstormMode && clicked) discardAmountP1--;
                if (_tradeMode && clicked) _totalTradeValue += card.TradeValue;
                card.DrawCard(pictureBoxPlayer1.CreateGraphics(), card.XPos);
            }
        }

        private void pictureBoxPlayer2_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_modeLock || _stealMode) return;
            // Player2 can only sell from player2's hand. Ignore
            if ((_sellMode || _tradeMode) && _currentPlayer) return;
            // Discard current player's hand only or maximum num has been selected
            if ((_sandstormMode && _currentPlayer) || (_sandstormMode && discardAmountP2 == 0)) return;


            pictureBoxPlayer2.Refresh();
            foreach (var card in player2Cards)
            {
                var clicked = card.CardClicked(pictureBoxPlayer2.CreateGraphics(), e.X, e.Y);
                if (_sandstormMode && clicked) discardAmountP2--;
                if (_tradeMode && clicked) _totalTradeValue += card.TradeValue;
                card.DrawCard(pictureBoxPlayer2.CreateGraphics(), card.XPos);
            }
        }

        private bool marketSelect;
        private bool marketFull = false;
        private void pictureBoxMarketPlace_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_modeLock || !marketSelect || marketFull) return;

            pictureBoxMarketPlace.Refresh();
            foreach (var card in marketPlace)
            {
                var clicked = card.CardClicked(pictureBoxMarketPlace.CreateGraphics(), e.X, e.Y);
                if (clicked)
                {
                    if (!card.Selected)
                    {
                        _totalTradeValue += card.TradeValue;
                        continue;
                    }

                    int diff = _totalTradeValue - card.TradeValue;
                    if (0 <= diff)
                    {
                        _totalTradeValue -= card.TradeValue;

                    }
                    else
                    {
                        card.Selected = false; // Deselect
                        labelGameStatus.Text =
                            ("Warning: Trade value left: " + _totalTradeValue.ToString() +
                             " Curr card value: " + card.TradeValue.ToString());
                    }

                }
                card.DrawCard(pictureBoxMarketPlace.CreateGraphics(), card.XPos);
            }
        }
        private int SellCards(List<Card> cards)
        {
            var salesList = new Dictionary<string, int>();
            foreach (var c in cards.ToArray())
                if (c.Selected)
                {
                    if (salesList.ContainsKey(c.CardName))
                    {
                        if (salesList[c.CardName] == 5)
                        {
                            c.Selected = false;
                            continue; // Ignore cards
                        }

                        salesList[c.CardName]++;
                    }
                    else
                    {
                        salesList.Add(c.CardName, 1);
                    }

                    cards.Remove(c);
                }

            var totalSale = 0;
            foreach (var entry in salesList) totalSale += _priceChart[entry.Key][entry.Value];
            return totalSale;
        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            if (_modeLock)
            {
                MessageBox.Show("Currently not in sell mode. Cannot sell.");
                return;
            }

            _modeLock = true;
            _sellMode = true;
            buttonSell.Enabled = false;
            labelGameStatus.Text = "Currently selling... Press confirm after selection.";
        }

        private void resetModes()
        {
            _stealMode = false;
            _tradeMode = false;
            _sellMode = false;
        }

        private void endTurnButton_Click(object sender, EventArgs e)
        {
            if (_modeLock)
            {
                MessageBox.Show("Player must take action");
                return;
            }

            _drawnCard = false;
            buttonSell.Enabled = true;
            buttonTrade.Enabled = true;
            _currentPlayer = !_currentPlayer;

            FlipCards(player1Cards, pictureBoxPlayer1);
            FlipCards(player2Cards, pictureBoxPlayer2);

            labelGameStatus.Text = _currentPlayer ? "Player 1's Turn" : "Player 2's Turn";
        }

        private void buttonExplore_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented");
            _exploreMode = true;
            _modeLock = true;
        }

        private void reDraw(List<Card> cards, PictureBox pb)
        {
            pb.Refresh();
            var xpos = 10;
            foreach (var c in cards)
            {
                c.DrawCard(pb.CreateGraphics(), xpos);
                xpos += c.GetWidth() + 10;
            }
        }

        private void StealCard(List<Card> src, List<Card> dst)
        {
            if (src.Count == 0) return; // Nothing to steal

            var random = new Random();
            var index = random.Next(src.Count);
            var tmp = src[index];
            labelGameStatus.Text = "Stolen: " + tmp.CardName;
            tmp.Flipped = true;
            dst.Add(tmp);
            src.Remove(tmp);
        }

        private void CompleteTrade(List<Card> cards)
        {
            var tmp = new List<Card>();
            foreach (var c in marketPlace.ToArray())
            {
                if (!c.Selected) continue;
                
                c.Selected = false;
                tmp.Add(c);
                marketPlace.Remove(c);
            }
            cards.AddRange(tmp);
            tmp.Clear();
            foreach (var c in cards.ToArray())
            {
                if (!c.Selected) continue;
                
                c.Selected = false;
                tmp.Add(c);
                cards.Remove(c);
            }

            marketPlace.AddRange(tmp);
            reDraw(marketPlace, pictureBoxMarketPlace);
        }
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (_sellMode)
            {
                if (_currentPlayer)
                {
                    player1Gold += SellCards(player1Cards);
                    labelPlayer1Gold.Text = "Player 1 Gold: " + player1Gold;
                }
                else
                {
                    player2Gold += SellCards(player2Cards);
                    labelPlayer2Gold.Text = "Player 2 Gold: " + player2Gold;
                }

                labelGameStatus.Text = "Sold...";
                _sellMode = false;
            }
            else if (_stealMode)
            {
                if (_currentPlayer)
                    StealCard(player2Cards, player1Cards);
                else
                    StealCard(player1Cards, player2Cards);

                _stealMode = false;
            }
            else if (_tradeMode)
            {
                if (!marketSelect)
                {
                    labelGameStatus.Text = "Now select cards from the marketplace. Total Trade Val: "
                                           + _totalTradeValue.ToString();
                    marketSelect = true;
                    return;
                }

                if (_currentPlayer)
                    CompleteTrade(player1Cards);
                else
                    CompleteTrade(player2Cards);

                labelGameStatus.Text = "Trading complete.";
                _tradeMode = false;
                marketSelect = false;
            }
            else if (_sandstormMode)
            {
                if (_currentPlayer)
                {
                    if (discardAmountP1 != 0)
                    {
                        MessageBox.Show("You have not selected enough cards.");
                        return;
                    }

                    player1Cards.RemoveAll(x => x.Selected);
                    reDraw(player1Cards, pictureBoxPlayer1);
                }
                else
                {
                    if (discardAmountP2 != 0)
                    {
                        MessageBox.Show("You have not selected enough cards.");
                        return;
                    }

                    player2Cards.RemoveAll(x => x.Selected);
                    reDraw(player2Cards, pictureBoxPlayer2);
                }

                _currentPlayer = !_currentPlayer;
                if (_currentPlayer)
                    labelGameStatus.Text = "P1: Num of cards to discard: " + discardAmountP1;
                else
                    labelGameStatus.Text = "P2: Num of cards to discard: " + discardAmountP2;

                FlipCards(player1Cards, pictureBoxPlayer1);
                FlipCards(player2Cards, pictureBoxPlayer2);

                if (discardAmountP1 != 0 || discardAmountP2 != 0) return;
                _sandstormMode = false;
                labelGameStatus.Text = "Player's turn again.";
            }
            else if (_exploreMode)
            {
                _exploreMode = false;
            }
            

            reDraw(player1Cards, pictureBoxPlayer1);
            reDraw(player2Cards, pictureBoxPlayer2);
            _modeLock = false;
        }
    }
}
