using Godot;
using System;

public partial class PNGTuberSprite : Node
{

    public Sprite2D sprite = null;
    Tween? SpriteJumpTween = null;

    public override void _Ready()
    {
        sprite = GetNode<Sprite2D>("Sprite2D");

    }

    public void SpriteSpeak()
    {
         
        sprite.Frame = 1;

      
        sprite.Modulate = Colors.White;

    }

    public void SpriteIdle()
    {
        sprite.Frame = 0;
        sprite.Modulate = Colors.Gray;
    }

    public void SpriteJump()
    {

        SpriteJumpTween = CreateTween();
        Vector2 SpriteOGPos = new Vector2(sprite.Position.X, sprite.Position.Y);
        Vector2 SpriteJumpsPos = new Vector2(sprite.Position.X, sprite.Position.Y - 30);


        SpriteJumpTween.TweenProperty(sprite, "position", SpriteJumpsPos, 0.25f);
        SpriteJumpTween.TweenProperty(sprite, "position", SpriteOGPos, 0.25f);
    }
}
