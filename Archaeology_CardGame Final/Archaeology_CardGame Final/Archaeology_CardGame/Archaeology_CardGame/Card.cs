using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Archaeology_CardGame.Properties;

namespace Archaeology_CardGame
{
    public abstract class Card
    {
        private readonly Image _backImage = Properties.Resources.cardback;
        private Rectangle _bounds;
        private string _cardName;
        private int _cardNum;
        protected List<Deck> decks = new List<Deck>();
        private bool _flipped = false;
        private Image _image;
        protected ResourceManager re_manager = Resources.ResourceManager;
        private bool _selected = false;
        private int _tradeValue;
        private int _xPos;
        private readonly int _yPos = 10;

        public int GetHeight()
        {
            return Image.Height / 4;
        }

        public int GetWidth()
        {
            return Image.Width / 4;
        }

        public bool Flipped
        {
            get => _flipped;
            set => _flipped = value;
        }

        public bool Selected
        {
            get => _selected;
            set => _selected = value;
        }

        public int XPos
        {
            get => _xPos;
            set => _xPos = value;
        }

        public Image Image
        {
            get => (Image)re_manager.GetObject(CardName);
            set => _image = value;
        }

        public string CardName
        {
            get => _cardName;
            set => _cardName = value;
        }

        public int CardNum
        {
            get => _cardNum;
            set => _cardNum = value;
        }

        public int TradeValue
        {
            get => _tradeValue;
            set => _tradeValue = value;
        }

        protected void UpdateBounds(int x, int y)
        {
            _bounds = new Rectangle(x, y, GetWidth(), GetHeight());
        }

        public void DrawCard(Graphics g, int cardPos)
        {
            XPos = cardPos;
            var imageToDisplay = Flipped ? Image : _backImage;
            UpdateBounds(cardPos, _yPos);

            g.DrawImage(imageToDisplay, cardPos, _yPos, GetWidth(), GetHeight());
            if (Selected) g.DrawRectangle(new Pen(Color.Red, 4), _bounds);
        }

        public bool CardClicked(Graphics g, int x, int y)
        {
            var contains = _bounds.Contains(x, y);

            if (contains) Selected = !Selected;

            return contains;
        }
    }
}
