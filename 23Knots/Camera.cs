using _23Knots.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _23Knots
{
    public class Camera
    {
        public Matrix Transformation { get; set; }
        public float Zoom { get; set; } = 1f;
        public Vector2 Position { get; private set; }
        public Vector2 DrawPosition { get; private set; }
        private readonly float _acceleration;
        private Viewport _view;
        private GameObject _focusedGameObject;
        private Vector2 _previousPosition;

        public Camera(Viewport newView)
        {
            _view = newView;
            _acceleration = .2f;
        }

        public GameObject FocusedGameObject
        {
            set => _focusedGameObject = value;
        }

        public void Update(GameTime gameTime)
        {
            _previousPosition = Position;
            var focusedObjectSize = _focusedGameObject.Size;
            var posX = _focusedGameObject.Position.X + (focusedObjectSize.Width / 2f) - (_view.Width / 2f / Zoom);
            var posY = _focusedGameObject.Position.Y + (focusedObjectSize.Height / 2f) - (_view.Height / 2f / Zoom);
            Position = Vector2.Lerp(_previousPosition, new Vector2(posX, posY), _acceleration);
        }

        public void Draw()
        {
            DrawPosition = Vector2.Lerp(_previousPosition, Position, MainGame.Instance.UpdateHandler.TimeCoefficient);
            Transformation = Matrix.CreateTranslation(new Vector3(-DrawPosition.X, -DrawPosition.Y, 0)) * Matrix.CreateScale(Zoom);
        }
    }
}
