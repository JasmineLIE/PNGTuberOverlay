using Godot;
using System;

public partial class MainApp : Node
{
    PNGTuberSprite PNGTuberSprite = null;
    AudioInputCapture InputCapture = null;

    double inputGracePeriod = 3;

    bool tweenReset;
 
    public override void _Ready()
    {
        tweenReset = true;
        PNGTuberSprite = GetNode<PNGTuberSprite>("PNGTuberSprite");
        InputCapture = GetNode<AudioInputCapture>("AudioHandler");



        
    }

    public override void _Process(double delta)
    {
        
         
        if (Input.IsActionPressed("DragSprite"))
        {
            AdjustSpritePosition();
            GD.Print("We are moving sprite");
        } 

        if (InputCapture.ReturnMicVal() > AudioInputCapture.ClampMAX)
        {
            inputGracePeriod = 3;
            PNGTuberSprite.SpriteSpeak();
            if (tweenReset)
            {
                PNGTuberSprite.SpriteJump();
                tweenReset = false;
            }
           
        } else
        {
           
            inputGracePeriod -= 0.05;
        }

        if (inputGracePeriod <= 0)
        {
            PNGTuberSprite.SpriteIdle();
            tweenReset = true;
        }
      
    }
    public void AdjustSpritePosition()
    {
        Vector2 mousePosition = GetViewport().GetMousePosition();
      
        PNGTuberSprite.sprite.GlobalPosition = mousePosition;
    }

  
    
}
